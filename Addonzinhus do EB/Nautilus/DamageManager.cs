using EloBuddy;
using EloBuddy.SDK;
using static Nautilus.SpellManager;
using static Nautilus.Helper;

namespace Nautilus
{
    public static class DamageManager
    {
        public static float GetQDamage(this Obj_AI_Base target)
        {
            if (!Q.IsReady()) return 0f;

            var level = Me.Spellbook.GetSpell(SpellSlot.Q).Level - 1;
            var damage = new[] { 60f,105f,150f,195f,240f }[level] + Me.TotalMagicalDamage * 0.75f;
            var dmgQ = Me.CalculateDamageOnUnit(target, DamageType.Magical, damage);

            return dmgQ - 10;
        }

        public static float GetEDamage(this Obj_AI_Base target)
        {
            if (!E.IsReady()) return 0f;

            var level = Me.Spellbook.GetSpell(SpellSlot.E).Level - 1;
            var damage = new[] { 60f,100f,140f,180f,220f }[level] + Me.TotalMagicalDamage * 0.5f;
            var dmgE = Me.CalculateDamageOnUnit(target, DamageType.Magical, damage);

            return dmgE - 10;
        }

        public static float GetRDamage(this Obj_AI_Base target)
        {
            if (!R.IsReady()) return 0f;

            var level = Me.Spellbook.GetSpell(SpellSlot.R).Level - 1;
            var dmg = new[] { 200f,325f,450f }[level] + Me.TotalMagicalDamage * 0.8f;
            var dmgR = Me.CalculateDamageOnUnit(target, DamageType.Magical, dmg);

            return dmgR - 10;
        }

        public static float GetTotalDamage(this Obj_AI_Base target)
        {
            return target.GetQDamage() + target.GetEDamage() + target.GetRDamage();
        }
    }
}
