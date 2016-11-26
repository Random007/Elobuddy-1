using System.ComponentModel;
using EloBuddy;
using EloBuddy.SDK;

namespace AutoJanna.Managers
{
    public static class AutoLevelSpellManager
    {
        public static void LoadAutoLevelSpellManager()
        {
            Obj_AI_Base.OnLevelUp += Obj_AI_Base_OnLevelUp;

            LevelUp(SpellSlot.E);
        }

        private static void Obj_AI_Base_OnLevelUp(Obj_AI_Base sender, Obj_AI_BaseLevelUpEventArgs args)
        {
            var hero = sender as AIHeroClient;

            if(hero == null)return;

            if(!hero.IsMe)return;

            Core.DelayAction(OP, 500);
        }

        private static void OP()
        {
            if (!Player.GetSpell(SpellSlot.Q).IsLearned)
            {
                LevelUp(SpellSlot.Q);
            }

            if (!Player.GetSpell(SpellSlot.W).IsLearned)
            {
                LevelUp(SpellSlot.W);
            }

            LevelUp(SpellSlot.R);
            LevelUp(SpellSlot.E);
            LevelUp(SpellSlot.W);
            LevelUp(SpellSlot.Q);
        }

        private static void LevelUp(SpellSlot slot)
        {
            if (Player.Instance.Spellbook.CanSpellBeUpgraded(slot))
            {
                Player.LevelSpell(slot);
            }
        }
    }
}
