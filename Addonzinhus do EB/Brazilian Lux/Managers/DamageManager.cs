using BrazilianLux.Misc;
using EloBuddy;
using EloBuddy.SDK;

using static BrazilianLux.Misc.Helper;
using static BrazilianLux.Managers.SpellManager;

namespace BrazilianLux.Managers
{
    public static class DamageManager
    {
        private const int MinusDamage = 10;

        public static float GetPassiveDamage(this Obj_AI_Base target, bool ignoreCheck = false)
        {
            //Spaguetti
            if (ignoreCheck)
            {
                
            }
            else
            {
                if (!target.HasPassive()) return 0f;
            }
            
            var baseDamage = 10 +(Me.Level*10);

            var damage = baseDamage + Me.TotalMagicalDamage*0.2f;
            
            var dmgPassive = Me.CalculateDamageOnUnit(target, DamageType.Magical, damage);

            if (target.IsInAutoAttackRange(Me))
            {
                dmgPassive += Me.GetAutoAttackDamage(target);
            }

            return dmgPassive;
        }

        public static float GetQDamage(this Obj_AI_Base target, bool withPassive = false)
        {
            if (!Q.IsReady()) return 0f;

            var level = Me.Spellbook.GetSpell(SpellSlot.Q).Level - 1;
            var damage = new[] {50f, 100f, 150f, 200f, 250f}[level] + Me.TotalAttackDamage*0.7f;
            var dmgQ = Me.CalculateDamageOnUnit(target, DamageType.Magical, damage);

            if (withPassive && target.IsInAutoAttackRange(Me))
            {
                dmgQ += target.GetPassiveDamage();
            }

            return dmgQ - MinusDamage;
        }

        public static float GetEDamage(this Obj_AI_Base target, bool withPassive = false)
        {
            if (!E.IsReady()) return 0f;

            var level = Me.Spellbook.GetSpell(SpellSlot.E).Level - 1;
            var damage = new[] {60f, 105f, 150f, 195f, 240f}[level] + Me.TotalAttackDamage*0.6f;
            var dmgE = Me.CalculateDamageOnUnit(target, DamageType.Magical, damage);

            if (withPassive && target.IsInAutoAttackRange(Me))
            {
                dmgE += target.GetPassiveDamage();
            }

            return dmgE - MinusDamage;
        }

        public static float GetRDamage(this Obj_AI_Base target, bool withPassive = false)
        {
            if (!R.IsReady()) return 0f;

            var level = Me.Spellbook.GetSpell(SpellSlot.R).Level - 1;
            var damage = new[] {300f, 400f, 500f}[level] + Me.TotalAttackDamage*0.75f;
            var dmgR = Me.CalculateDamageOnUnit(target, DamageType.Magical, damage);

            if (withPassive)
            {
                dmgR += target.GetPassiveDamage();
            }

            return dmgR - MinusDamage;
        }

        public static float GetTotalDamage(this Obj_AI_Base target, bool ignoreCheck = false)
        {
            return target.GetQDamage() + target.GetEDamage() + target.GetRDamage() + target.GetPassiveDamage(ignoreCheck);
        }
    }
}
