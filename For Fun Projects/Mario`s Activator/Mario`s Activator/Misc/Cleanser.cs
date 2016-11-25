using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Mario_s_Activator.Spells;
using Mario_s_Lib;

namespace Mario_s_Activator.Misc
{
    public static class Cleanser
    {
        public static void Init()
        {
            Obj_AI_Base.OnBuffGain += Obj_AI_Base_OnBuffGain;
        }

        private static void Obj_AI_Base_OnBuffGain(Obj_AI_Base sender, Obj_AI_BaseBuffGainEventArgs args)
        {
            if (sender.IsEnemy) return;

            CleanseOnTick();
        }

        public static void CleanseOnTick()
        {
            /*
            var delay = MyMenu.CleansersMenu.GetSliderValue("delayCleanse");
            //Item
            var itemCleanse =
                Cleansers.CleansersItems.FirstOrDefault(
                    i => i.IsReady() && i.IsOwned() && MyMenu.CleansersMenu.GetCheckBoxValue("check" + (int) i.Id));

            if (itemCleanse == null) return;

            if (itemCleanse.Id == ItemId.Mikaels_Crucible)
            {
                var ally = EntityManager.Heroes.Allies.FirstOrDefault(a => a.HasCC());
                if (ally == null) return;

                Core.DelayAction(() => itemCleanse.Cast(ally), delay);
                return;
            }
            if (Player.Instance.HasCC())
            {
                Core.DelayAction(() => itemCleanse.Cast(), delay);
                return;
            }

            //SummonerSpell
            if (!SummonerSpells.PlayerHasCleanse) return;
            
            if (Player.Instance.HasCC() && MyMenu.CleansersMenu.GetCheckBoxValue("check" + "cleanse"))
            {
                Core.DelayAction(() => SummonerSpells.Cleanse.Cast(), delay);
            }
            */
        }
    }
}
