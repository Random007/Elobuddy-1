using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activator.ItemBases;
using EloBuddy;
using EloBuddy.SDK;

namespace Activator
{
   internal static class Items
    {
        public static List<OffensiveItem> OffensiveItems = new List<OffensiveItem>
        {
            new OffensiveItem(ItemId.Bilgewater_Cutlass, 550),
            new OffensiveItem(ItemId.Blade_of_the_Ruined_King, 550),
            new OffensiveItem(ItemId.Tiamat, 380),
            new OffensiveItem(ItemId.Ravenous_Hydra, 380),
            new OffensiveItem(ItemId.Titanic_Hydra, (int)Player.Instance.GetAutoAttackRange()),
            new OffensiveItem(ItemId.Youmuus_Ghostblade, 1000),
            new OffensiveItem(ItemId.Hextech_Gunblade, 700),
            new OffensiveItem(ItemId.Frost_Queens_Claim)
        };

        public static List<Item> DefensiveItems = new List<Item>
        {
            new Item(ItemId.Zhonyas_Hourglass),
            new Item(ItemId.Seraphs_Embrace),
            new Item(ItemId.Face_of_the_Mountain, 1050),
            new Item(ItemId.Talisman_of_Ascension),
            new Item(ItemId.Locket_of_the_Iron_Solari, 600),
            new Item(ItemId.Randuins_Omen, 500),
            new Item(ItemId.Ohmwrecker, 850)
        };

        public static List<Item> CleansersItems = new List<Item>
        {
            new Item(ItemId.Mikaels_Crucible, 750),
            new Item(ItemId.Dervish_Blade),
            new Item(ItemId.Mercurial_Scimitar),
            new Item(ItemId.Quicksilver_Sash),
        };

       public static List<ConsumableItem> ConsumableItems = new List<ConsumableItem>
       {
           new ConsumableItem(ItemId.Health_Potion),
           //Biscuit
           new ConsumableItem(2009),
           new ConsumableItem(2010),
           //Biscuit
           new ConsumableItem(ItemId.Hunters_Potion),
           new ConsumableItem(ItemId.Corrupting_Potion),
           new ConsumableItem(ItemId.Refillable_Potion),
           new ConsumableItem(ItemId.Elixir_of_Iron, ItemPriority.Medium),
           new ConsumableItem(ItemId.Elixir_of_Wrath, ItemPriority.Medium),
           new ConsumableItem(ItemId.Elixir_of_Sorcery, ItemPriority.Medium)
       };

        public static List<Item> Detectors = new List<Item>
        {
            new Item(ItemId.Sweeping_Lens_Trinket, 650),
            new Item(ItemId.Oracle_Alteration, 650)
        };

        public static List<Item> WardsAndTrinketsItems = new List<Item>
        {
            new Item(ItemId.Greater_Stealth_Totem_Trinket, 650),
            new Item(ItemId.Warding_Totem_Trinket, 650),
            new Item(ItemId.Farsight_Alteration, 1000),
        };
    }
}
