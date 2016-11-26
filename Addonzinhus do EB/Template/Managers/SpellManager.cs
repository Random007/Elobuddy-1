using EloBuddy;
using EloBuddy.SDK;

namespace Template.Managers
{
    public static class SpellManager
    {
        public static Spell.SpellBase Q { get; private set; }
        public static Spell.SpellBase W { get; private set; }
        public static Spell.SpellBase E { get; private set; }
        public static Spell.SpellBase R { get; private set; }

        public static void LoadSpells()
        {
            Q = new Spell.SimpleSkillshot(SpellSlot.Q, 100);
            W = new Spell.SimpleSkillshot(SpellSlot.W, 100);
            E = new Spell.SimpleSkillshot(SpellSlot.E, 100);
            R = new Spell.SimpleSkillshot(SpellSlot.R, 100);
        }
    }
}
