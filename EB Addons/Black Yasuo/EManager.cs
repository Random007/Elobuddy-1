using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

using static BlackYasuo.SpellManager;
using static BlackYasuo.Helper;

namespace BlackYasuo
{
   internal static class EManager
    {
        public static bool IsSafeToE(this Obj_AI_Base target)
        {
            var position = target.GetPosAfterE();

            if (position.IsUnderTower()) return false;

            //if (position.CountEnemiesInRange(900) >= 3) return false;

            if (position.CountEnemyChampionsInRange(900) >= 2 && Me.HealthPercent < 25) return false;

            return true;
        }


        public static Obj_AI_Base GetBestEnemyToE(this Obj_AI_Base target)
        {
            return
                EntityCache.AllEnemies
                    .Where(m => m.IsValidTarget(E.Range))
                    .OrderBy(m => m.Distance(target))
                    .ThenByDescending(m => m.Distance(Me))
                    .ThenBy(m => m.Distance(Game.CursorPos))
                    .FirstOrDefault(m => m.IsValidTarget(E.Range) && !m.HasEBuff() && m.GetPosAfterE().Distance(target) < Me.Distance(target) - 120);
        }


        internal static bool IsNearWallJump()
        {
            if (WallDashes.DashPositions.Any(pos => Me.Distance(pos.From) < 200))
            {
                return true;
            }
            return false;
        }

        /*
        public static void eBehindWall(AIHeroClient target)
        {
            if (!E.IsReady() || !enemyIsJumpable(target) || target.IsMelee) return;

            var dist = Me.Distance(target);
            var pPos = Me.Position.To2D();
            var dashPos = target.Position.To2D();
            if (!target.IsMoving || Me.Distance(dashPos) <= dist)
            {
                foreach (var enemy in ObjectManager.Get<Obj_AI_Base>().Where(enemy => !HasEBuff(enemy)))
                {
                    var posAfterE = pPos + (Vector2.Normalize(enemy.Position.To2D() - pPos) * E.Range);
                    if ((target.Distance(posAfterE) < dist
                        || target.Distance(posAfterE) < Me.GetAutoAttackRange() + 100)
                        && goesThroughWall(target.Position, posAfterE.To3D()))
                    {
                        if (E.CastOnUnit(target)) return;
                    }
                }
            }
        }

        public static bool goesThroughWall(Vector3 vec1, Vector3 vec2)
        {
            if (wall.endtime < Game.Time || wall.pointL == null || wall.pointL == null)
                return false;
            Vector2 inter = YasMath.LineIntersectionPoint(vec1.To2D(), vec2.To2D(), wall.pointL.Position.To2D(), wall.pointR.Position.To2D());
            float wallW = (300 + 50 * W.Level);
            if (wall.pointL.Position.To2D().Distance(inter) > wallW ||
                wall.pointR.Position.To2D().Distance(inter) > wallW)
                return false;
            var dist = vec1.Distance(vec2);
            if (vec1.To2D().Distance(inter) + vec2.To2D().Distance(inter) - 30 > dist)
                return false;

            return true;
        }
        */
    }
}
