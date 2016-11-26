using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Spells;

namespace Nautilus
{
    public static class SpellManager
    {
        public static Spell.Skillshot Q;
        public static Spell.Active W;
        public static Spell.Active E;
        public static Spell.Targeted R;

        public static void LoadSpells()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 1000, SkillShotType.Linear, 250, 2000, 90, DamageType.Magical);
            W = new Spell.Active(SpellSlot.W, 20, DamageType.Magical);
            E = new Spell.Active(SpellSlot.E, 350, DamageType.Magical);
            R = new Spell.Targeted(SpellSlot.R, 825, DamageType.Magical);
        }
    }
}