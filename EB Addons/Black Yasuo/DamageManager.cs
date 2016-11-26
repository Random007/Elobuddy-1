using System;
using EloBuddy;
using EloBuddy.SDK;
using static BlackYasuo.SpellManager;
using static BlackYasuo.Helper;

namespace BlackYasuo
{
    internal static class DamageManager
    {
        internal static float GetQDamage(this Obj_AI_Base target)
        {
            if (!Q.IsReady()) return 0f;
            #region ItemDamage
            var dmgItem = 0f;

            if (Item.HasItem((int)ItemId.Sheen) && (Item.CanUseItem((int)ItemId.Sheen) || Player.HasBuff("Sheen")))
            {
                dmgItem = Me.BaseAttackDamage;
            }
            if (Item.HasItem((int)ItemId.Trinity_Force)
                && (Item.CanUseItem((int)ItemId.Trinity_Force) || Player.HasBuff("Sheen")))
            {
                dmgItem = Me.BaseAttackDamage * 2;
            }
            if (dmgItem > 0)
            {
                dmgItem = Me.CalculateDamageOnUnit(target, DamageType.Physical, dmgItem);
            }
            #endregion ItemDamage

            #region QDamage
            var level = Me.Spellbook.GetSpell(SpellSlot.Q).Level - 1;
            var damage = new[] { 20f, 40f, 60f, 80f, 100f }[level] + Me.TotalAttackDamage;
            var dmgQ = Me.CalculateDamageOnUnit(target, DamageType.Physical, damage);
            #endregion QDamage

            //Calculating crit
            if (Math.Abs(Me.Crit - 1) < float.Epsilon)
            {
                dmgQ += Me.CalculateDamageOnUnit(
                    target,
                    DamageType.Physical,
                    (float)(Item.HasItem((int)ItemId.Infinity_Edge) ? 0.875 : 0.5) * Me.TotalAttackDamage);
            }

            return dmgQ + dmgItem - 10;
        }

        internal static float GetEDamage(this Obj_AI_Base target)
        {
            if (!E.IsReady()) return 0f;

            var level = Me.Spellbook.GetSpell(SpellSlot.E).Level - 1;

            var bonusDamage = new[] { 17.5f, 22.5f, 27.5f, 32.5f, 37.5f }[level] * ECount();

            var damage = new[] { 65f, 85f, 105f, 125f, 145f }[level] + Me.FlatMagicDamageMod * 0.6f + bonusDamage;

            return Me.CalculateDamageOnUnit(target, DamageType.Physical, damage - 15);
        }

        internal static float GetRDamage(this Obj_AI_Base target)
        {
            if (!R.IsReady()) return 0f;

            var level = Player.Instance.Spellbook.GetSpell(SpellSlot.R).Level - 1;

            var dmg = new[] {200f, 300f, 400f}[level] + Me.FlatPhysicalDamageMod*1.5f;

            return Me.CalculateDamageOnUnit(target, DamageType.Physical, dmg - 10);
        }

        internal static float GetTotalDamage(this Obj_AI_Base target)
        {
            return target.GetQDamage() + target.GetEDamage() + target.GetRDamage();
        }
    }
}
