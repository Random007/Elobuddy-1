using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace Mario_s_Activator
{
    public class Items
    {
        public static List<Item>  OwnedItems = new List<Item>();

        public static void InitializeItemDetection()
        {
            Shop.OnBuyItem += Shop_OnBuyItem;
            Shop.OnSellItem += Shop_OnSellItem;

            foreach (var alreadyOwned in Player.Instance.InventoryItems.Where(i => (int)i.Id != 2001).Select(a => new Item(a.Id, GetItemRange((int)a.Id))))
            {
                OwnedItems.Add(alreadyOwned);
            }

            foreach (var i in OwnedItems)
            {
                Chat.Print(i.Id);
            }
        }

        private static void Shop_OnBuyItem(AIHeroClient sender, ShopActionEventArgs args)
        {
            if (!sender.IsMe) return;
            Chat.Print("Item " + args.Id + "Bought");
            var boughtItem = new Item(args.Id, GetItemRange(args.Id));
            OwnedItems.Add(boughtItem);
        }

        private static void Shop_OnSellItem(AIHeroClient sender, ShopActionEventArgs args)
        {
            if (!sender.IsMe) return;
            Chat.Print("Item " + args.Id + "Sold");
            var boughtItem = new Item(args.Id, GetItemRange(args.Id));
            OwnedItems.Remove(boughtItem);
        }

        public static int GetItemRange(int id)
        {
            var Item = ItemsRange.ItemsRangeDB.FirstOrDefault(item => (int) item.Id == id);
            if (Item == null) return 0;
            return (int)Item.Range;
        }
    }

    internal class ItemsRange
    {
        public static List<Item> ItemsRangeDB = new List<Item>
        {
            //Offensive
            new Item(ItemId.Bilgewater_Cutlass, 550),
            new Item(ItemId.Blade_of_the_Ruined_King, 550),
            new Item(ItemId.Tiamat, 380),
            new Item(ItemId.Ravenous_Hydra, 380),
            new Item(ItemId.Titanic_Hydra, Player.Instance.GetAutoAttackRange()),
            new Item(ItemId.Youmuus_Ghostblade, 1000),
            new Item(ItemId.Hextech_Gunblade, 700),
            new Item(ItemId.Frost_Queens_Claim),
            //Defensive
            new Item(ItemId.Zhonyas_Hourglass),
            new Item(ItemId.Seraphs_Embrace),
            new Item(ItemId.Face_of_the_Mountain, 1050),
            new Item(ItemId.Talisman_of_Ascension),
            new Item(ItemId.Locket_of_the_Iron_Solari, 600),
            new Item(ItemId.Randuins_Omen, 500),
            new Item(ItemId.Ohmwrecker, 850),
            //Cleansers
            new Item(ItemId.Mikaels_Crucible, 750),
            new Item(ItemId.Dervish_Blade),
            new Item(ItemId.Mercurial_Scimitar),
            new Item(ItemId.Quicksilver_Sash),
            //Consumables
            new Item(ItemId.Health_Potion),
            new Item(ItemId.Total_Biscuit_of_Rejuvenation),
            new Item(ItemId.Hunters_Potion),
            new Item(ItemId.Corrupting_Potion),
            new Item(ItemId.Refillable_Potion),
            new Item(ItemId.Elixir_of_Iron),
            new Item(ItemId.Elixir_of_Wrath),
            new Item(ItemId.Elixir_of_Sorcery),
            //Wards & Trinkets
            new Item(ItemId.Sweeping_Lens_Trinket, 650),
            new Item(ItemId.Oracle_Alteration, 650),
            new Item(ItemId.Vision_Ward, 650),
            new Item(ItemId.Greater_Stealth_Totem_Trinket, 650),
            new Item(ItemId.Warding_Totem_Trinket, 650),
            new Item(ItemId.Farsight_Alteration, 1000),
        };
    }
}
