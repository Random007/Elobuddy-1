using System;
using System.Linq;
using BlackYasuo.Databases;
using EloBuddy;
using EloBuddy.SDK;

namespace BlackYasuo
{
    public static class Utils
    {
        private static AIHeroClient Me => Player.Instance;

        public static int GameTimeTickCount => (int) (Game.Time*1000);

        public static int TickCount => Environment.TickCount & int.MaxValue;

        public static int GetRandomNumber(int min = 0, int max = 10)
        {
            return new Random(Environment.TickCount).Next(min, max);
        }

        #region GetTarget
        private static DamageType GetDamageType(Champion champ)
        {
            var info = DamageDB.DamageList.FirstOrDefault(d => d.Champ == champ);
            if (info != null) return info.DamageType;
            return DamageType.Mixed;
        }

        public static AIHeroClient GetTarget(this Spell.SpellBase spell, int plusRange = 0)
        {
            return TargetSelector.GetTarget(spell.Range + plusRange, GetDamageType(Me.Hero));
        }

        public static AIHeroClient GetTarget(int range)
        {
            return TargetSelector.GetTarget(range, GetDamageType(Me.Hero));
        }
        #endregion GetTarget

    }
}
