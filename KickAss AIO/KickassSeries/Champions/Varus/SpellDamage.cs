﻿using EloBuddy;
using EloBuddy.SDK;

namespace KickassSeries.Champions.Varus
{
    public static class SpellDamage
    {
        public static float GetTotalDamage(AIHeroClient target)
        {
            // Auto attack
            var damage = Player.Instance.GetAutoAttackDamage(target);

            // Q
            if (SpellManager.Q.IsReady())
            {
                damage += SpellManager.Q.GetRealDamage(target);
            }

            // W
            if (SpellManager.W.IsReady())
            {
                damage += SpellManager.W.GetRealDamage(target);
            }

            // E
            if (SpellManager.E.IsReady())
            {
                damage += SpellManager.E.GetRealDamage(target);
            }

            // R
            if (SpellManager.R.IsReady())
            {
                damage += SpellManager.R.GetRealDamage(target);
            }

            return damage;
        }

        public static float GetRealDamage(this Spell.SpellBase spell, Obj_AI_Base target)
        {
            return spell.Slot.GetRealDamage(target);
        }

        public static float GetRealDamage(this SpellSlot slot, Obj_AI_Base target)
        {
            // Helpers
            var spellLevel = Player.Instance.Spellbook.GetSpell(slot).Level;
            const DamageType damageType = DamageType.Magical;
            float damage = 0;

            // Validate spell level
            if (spellLevel == 0)
            {
                return 0;
            }
            spellLevel--;

            switch (slot)
            {
                case SpellSlot.Q:

                    damage = new float[] { 10, 46, 83, 120, 156 }[spellLevel] + 1.0f * Player.Instance.FlatPhysicalDamageMod;
                    break;

                case SpellSlot.W:

                    damage = new float[] { 10, 14, 18, 22, 26 }[spellLevel] + 0.25f * Player.Instance.FlatMagicDamageMod + new [] { 0.02f, 0.0275f, 0.035f,0.0425f, 0.05f }[spellLevel] * target.MaxHealth + 0.02f /100 * Player.Instance.FlatMagicDamageMod;
                    break;

                case SpellSlot.E:

                    damage = new float[] { 65, 100, 135, 170, 205 }[spellLevel] + 0.6f * Player.Instance.FlatPhysicalDamageMod;
                    break;

                case SpellSlot.R:

                    damage = new float[] { 100, 175, 250 }[spellLevel] + 1.0f * Player.Instance.FlatMagicDamageMod;
                    break;
            }

            if (damage <= 0)
            {
                return 0;
            }

            return Player.Instance.CalculateDamageOnUnit(target, damageType, damage) - 10;
        }
    }
}