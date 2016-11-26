using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

using static AutoJanna.Misc.Helper;
using static AutoJanna.Misc.Utils;
using static AutoJanna.Managers.ModeManager;

namespace AutoJanna.Managers
{
    public static class PositionManager
    {
        public static Vector3 Position;

        private const int MinChampDist = 250;
        private const int MaxChampDist = 400;

        private const int MinRandom = -250;
        private const int MaxRandom = 250;

        private static bool PreparingToRecall;
        private static bool Recalling;

        public static Vector3 BestPosition()
        {
            if (MyADC.IsDead)
            {
                return RecallManager.BestRecallPosition();
            }

            if (Recalling)
            {
                Orbwalker.DisableMovement = true;
                Orbwalker.DisableAttacking = true;

                if (!Me.IsRecalling())
                {
                    Recalling = false;
                    PreparingToRecall = false;
                    Orbwalker.DisableMovement = false;
                    Orbwalker.DisableAttacking = false;
                }

                return Vector3.Zero;
            }

            if (RecallManager.ShouldRecall() || PreparingToRecall)
            {
                Chat.Print("Should Recall");
                var bestRecallPos = RecallManager.BestRecallPosition();
                if (!PreparingToRecall)
                {
                    PreparingToRecall = true;
                    return bestRecallPos;
                }

                if (PreparingToRecall)
                {
                    if (Me.Distance(bestRecallPos) < 120)
                    {
                        PreparingToRecall = false;
                        Recalling = true;
                        Player.CastSpell(SpellSlot.Recall);
                    }
                    return bestRecallPos;
                }
            }

            if (WardManager.CanWard())
            {
                return WardManager.BestWardPostion();
            }

            if (MyADC.IsInRange(Me, 1000))
            {
                if (Target != null)
                {
                    var posTarget = Target.Position.Extend(MyADC.Position, Target.Distance(MyADC) + GetRandomNumber(MinChampDist, MaxChampDist));
                    posTarget.X += GetRandomNumber(MinRandom, MaxRandom);
                    posTarget.Y += GetRandomNumber(MinRandom, MaxRandom);
                    return posTarget.To3D((int) MyADC.Position.Y);
                }

                var minions = EntityManager.MinionsAndMonsters.GetLaneMinions().Where(m => m != null && m.IsValidTarget(1500) && m.IsEnemy);
                var minionBestPos = EntityManager.MinionsAndMonsters.GetCircularFarmLocation(minions, 800, 1500);
                if (minionBestPos.HitNumber > 0)
                {
                    var posMinion = minionBestPos.CastPosition.Extend(MyADC.Position,
                        GetRandomNumber((int)((MinChampDist * 1.3f) + MyADC.Distance(minionBestPos.CastPosition)),
                            (int)((MaxChampDist * 1.3f) + MyADC.Distance(minionBestPos.CastPosition))));
                    posMinion.X += GetRandomNumber(MinRandom, MaxRandom);
                    posMinion.Y += GetRandomNumber(MinRandom, MaxRandom);
                    return posMinion.To3D((int)MyADC.Position.Y);
                }

                
                var nearestTower =
                    EntityManager.Turrets.Allies.Where(t => t.Health > 10).OrderBy(t => t.Distance(Me)).FirstOrDefault(t => t.IsInRange(Me, 3000));
                if (nearestTower != null)
                {
                    var posTower = MyADC.Position.Extend(nearestTower.Position, GetRandomNumber(MinChampDist, MaxChampDist));
                    posTower.X += GetRandomNumber(MinRandom, MaxRandom);
                    posTower.Y += GetRandomNumber(MinRandom, MaxRandom);
                    return posTower.To3D((int) MyADC.Position.Y);
                }
                
                var nearestEnemyTower =
                    EntityManager.Turrets.Enemies.Where(t => t.Health > 10).OrderBy(t => t.Distance(Me)).FirstOrDefault(t => t.IsInRange(Me, 3000));
                if (nearestEnemyTower != null)
                {
                    var posEnemyTower = nearestEnemyTower.Position.Extend(MyADC.Position,
                        GetRandomNumber((int) ((MinChampDist*1.6f) + MyADC.Distance(nearestEnemyTower)),
                            (int) ((MaxChampDist*1.6f) + MyADC.Distance(nearestEnemyTower))));
                    posEnemyTower.X += GetRandomNumber(MinRandom, MaxRandom);
                    posEnemyTower.Y += GetRandomNumber(MinRandom, MaxRandom);
                    return posEnemyTower.To3D((int) MyADC.Position.Y);
                }
            }

            var pos = MyADC.Position.Extend(MyADC.Direction(), -GetRandomNumber(MinChampDist, MaxChampDist));
            pos.X += GetRandomNumber(-200, 200);
            pos.Y += GetRandomNumber(-200, 200);
            return pos.To3D((int)MyADC.Position.Y);
        }
    }
}
