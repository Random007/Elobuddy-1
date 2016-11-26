using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Lib;
using Lib.Databases;
using SharpDX;

using static BlackYasuo.SpellManager;

namespace BlackYasuo
{
    public static class Helper
    {
        public static Cache EntityCache;
        public static AddonDisabler AddonDisabler;
        //public static MissileDetection MissileDetection;

        public static AIHeroClient Me => Player.Instance;

        public static void Load()
        {
            EntityCache = new Cache();
            AddonDisabler = new AddonDisabler();
            //MissileDetection = new MissileDetection();
        }

        public static bool HasQ3()
        {
            return Me.HasBuff("yasuoq3w");
        }

        public static bool HasShield()
        {
            return Me.ManaPercent >= 100;
        }

        public static int ECount()
        {
            // ReSharper disable once StringLiteralTypo
            var count = Me.GetBuffCount("yasuodashscalar");
            return count > 0 ? count : 0;
        }

        public static bool HasEBuff(this Obj_AI_Base target)
        {
            // ReSharper disable once StringLiteralTypo
            return target.HasBuff("yasuodashwrapper");
        }

        public static bool IsKnockedUp(this Obj_AI_Base target)
        {
            return target.HasBuffOfType(BuffType.Knockup) || target.HasBuffOfType(BuffType.Knockback);
        }

        public static Obj_AI_Base GetNearestTower()
        {
            return EntityManager.Turrets.Enemies.FirstOrDefault(t => t.IsValid && !t.IsDead);
        }

        public static bool IsUnderTower(this Vector3 position)
        {
            return
                EntityManager.Turrets.Enemies.Where(a => a.Health > 0 && !a.IsDead).Any(a => a.Distance(position) <= 1120);
        }

        public static bool IsTowerNear(this Vector3 position)
        {
            return
                EntityManager.Turrets.Enemies.Where(a => a.Health > 0 && !a.IsDead).Any(a => a.Distance(position) <= 1500);
        }

        public static TargetR GetBestTargetToR()
        {
            var knockedEnemies = EntityCache.EnemyHeroes
                        .OrderByDescending(e => e.CountEnemiesInRange(600))
                        .ThenBy(e => e.HealthPercent)
                        .ThenByDescending(e => e.FlatPhysicalDamageMod)
                        .Where(h => h.IsKnockedUp() && h.IsValidTarget(R.Range) && !h.IsInvulnerable);

            foreach (var enemy in knockedEnemies.Where(e => e != null))
            {
                var buff = enemy.Buffs.OrderBy(b => (b.EndTime - Game.Time) * 1000).FirstOrDefault(b => b.IsKnockup || b.IsKnockback);
                if (buff == null) return new TargetR();

                return new TargetR
                {
                    Hero = enemy,
                    Time = (int)((buff.EndTime - Game.Time) * 1000),
                    EnemyCount = knockedEnemies.Count()
                };
            }
            return new TargetR();
        }

        public struct TargetR
        {
            public int Time { get; set; }
            public AIHeroClient Hero { get; set; }
            public int EnemyCount { get; set; }
        }
    }
}
