using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoJanna.Misc;
using EloBuddy;
using EloBuddy.SDK;

using static AutoJanna.Misc.Helper;

namespace AutoJanna.Managers
{
    public static class BuildItemsManager
    {
        private static List<ItemId> ItemsToBuy = new List<ItemId>
        {
            ItemId.Ancient_Coin,
            ItemId.Warding_Totem_Trinket,

            ItemId.Boots_of_Speed,
            ItemId.Nomads_Medallion,
            ItemId.Boots_of_Mobility,
            ItemId.Sightstone,
            ItemId.Talisman_of_Ascension,
            (ItemId)00009
        };

        public static void LoadBuildItemsManager()
        {
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            if (!Me.IsInShopRange()) return;

            var count = Player.Instance.InventoryItems.Count(i => i.Id == ItemId.Health_Potion || i.Id == ItemId.Total_Biscuit_of_Rejuvenation);
            Chat.Print(count);
            if (count < 3)
            {
                BuyItem(ItemId.Health_Potion);
            }

            BuyNextItem();
        }

        private static void BuyItem(ItemId id)
        {
            Shop.BuyItem(id);
        }

        private static void BuyNextItem()
        {
            var item = ItemsToBuy.First();
            if((int)item == 00009) return;
            ItemsToBuy.Remove(item);

            BuyItem(item);
        }
    }
}
