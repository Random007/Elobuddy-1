using EloBuddy;
using EloBuddy.SDK;
using Mario_s_Lib;
using static Mario_s_Activator.Items;

namespace Mario_s_Activator
{
    public abstract class ItemBase
    {
        public Item thisItem;
        public AIHeroClient thisTarget;
        private bool Initialized;

        public abstract void InitializeItem();
        public abstract void Execute();

        public void OnTick()
        {
            if (!OwnedItems.Contains(thisItem)) return;
            Chat.Print("2");
            if (!Initialized)
            {
                Chat.Print("3");
                InitializeItem();
                Initialized = true;
            }
            Chat.Print("4");
            thisTarget = Misc.Extensions.GetBestItemTarget(thisItem);
            var menuValue = MyMenu.OffensiveMenu.GetCheckBoxValue("check" + (int) thisItem.Id);
            Chat.Print("5");
            if (!thisItem.IsReady() || !menuValue || thisTarget == null) return;
            Chat.Print("6");
            Execute();
        }
    }
}
