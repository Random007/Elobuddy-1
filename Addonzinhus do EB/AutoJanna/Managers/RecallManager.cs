using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

using static AutoJanna.Misc.Helper;
using static AutoJanna.Misc.Map;

namespace AutoJanna.Managers
{
    public static class RecallManager
    {

        public static void LoadRecallManager()
        {
            Game.OnTick += Game_OnTick;
            Player.OnIssueOrder += Player_OnIssueOrder;
        }

        private static bool IsNearRecallPosition;

        private static void Game_OnTick(EventArgs args)
        {
            IsNearRecallPosition = Me.Distance(BestRecallPosition()) < 0;
        }

        private static void Player_OnIssueOrder(Obj_AI_Base sender, PlayerIssueOrderEventArgs args)
        {
            if (Me.IsRecalling() && IsNearRecallPosition)
            {
                args.Process = false;
            }
        }

        public static bool ShouldRecall()
        {
            if (Me.HealthPercent >= 80 && MyADC.HealthPercent >= 80)
            {
                return false;
            }

            if (MyADC.IsDead)
            {
                return true;
            }

            if (MyADC.IsRecalling() || MyADC.IsInShopRange())
            {
                return true;
            }

            if (Me.HealthPercent <= 25 && MyADC.HealthPercent <= 25)
            {
                return true;
            }

            if (Me.Gold >= 1500 && MyADC.HealthPercent >= 70 && Me.HealthPercent <= 50)
            {
                return true;
            }

            return false;
        }

        public static Vector3 BestRecallPosition()
        {
            var nearestEnemyTower =
                EntityManager.Turrets.Allies.Where(t => t.Health > 10).OrderBy(t => t.Distance(Me)).FirstOrDefault();

            /*
            var nearestAllyTower =
                EntityManager.Turrets.Allies.Where(t => t.Health > 10 && t.IsInRange(Me, 1500)).OrderBy(t => t.Distance(Me)).FirstOrDefault();



            if (nearestAllyTower != null && nearestEnemyTower != null)
            {
                return nearestEnemyTower.Position.Extend(nearestAllyTower, nearestEnemyTower.Distance(nearestAllyTower) + 250).To3D();
            }
            */

            if (MyADC.IsValidTarget(1000))
            {
                return MyADC.Position.Extend(nearestEnemyTower, 250f).To3DWorld();
            }

            var nearestEnemy = EntityManager.Heroes.Enemies.Where(e => e.IsValidTarget(1500)).OrderBy(e => e.Distance(Me)).FirstOrDefault();
            if (nearestEnemy != null)
            {
                var nearestBush = Bushes.OrderBy(b => b.Distance(Me)).ThenByDescending(b => b.Distance(nearestEnemy)).FirstOrDefault();

                if (nearestBush != null)
                {
                    return nearestBush.Position;
                }
            }
            else
            {
                var nearestBush = Bushes.OrderBy(b => b.Distance(Me)).FirstOrDefault();

                if (nearestBush != null)
                {
                    return nearestBush.Position;
                }
            }

            return Vector3.Zero;
        }
    }
}
