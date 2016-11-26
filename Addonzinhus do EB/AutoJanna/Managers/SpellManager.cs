using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

using static AutoJanna.Misc.Helper;

namespace AutoJanna.Managers
{
    public static class SpellManager
    {
        public static Spell.Skillshot Q;
        public static Spell.Targeted W;
        public static Spell.Targeted E;
        public static Spell.Active R;

        public static bool DelayQ { get; set; }

        public static void LoadSpells()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 850, SkillShotType.Linear, 250, 800, 120, DamageType.Magical);
            W = new Spell.Targeted(SpellSlot.W, 600, DamageType.Magical);
            E = new Spell.Targeted(SpellSlot.E, 800);
            R = new Spell.Active(SpellSlot.R, 650);

            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var hero = sender as AIHeroClient;
            if (hero == null) return;

            if(!hero.IsMe)return;

            if (IsChargingQ)
            {
                if (DelayQ)
                {
                    return;
                }
                DelayQ = false;
                Player.CastSpell(SpellSlot.Q);
            }
        }
    }
}
