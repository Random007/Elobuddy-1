using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;

// ReSharper disable VirtualMemberCallInConstructor

namespace Activator.ItemBases
{
    internal class DefensiveItem : ItemBase
    {
        public override Item ItemSDK { get; }

        public override string Name { get; }
        public override int ID { get; }
        public override int Range { get; }

        public override ItemPriority Priority { get; set; }
        
        public override bool CanCast()
        {
            return ItemSDK.IsReady();
        }

        public DefensiveItem(int id, int range = 0, ItemPriority priority = ItemPriority.Low)
        {
            ItemSDK = new Item(id, range);

            Name = ItemSDK.Id.ToString().Replace('_', ' ');
            ID = (int)ItemSDK.Id;
            Range = range;

            Priority = priority;
        }

        public DefensiveItem(ItemId itemid, int range = 0, ItemPriority priority = ItemPriority.Low)
        {
            ItemSDK = new Item(itemid, range);

            Name = ItemSDK.Id.ToString().Replace('_', ' ');
            ID = (int)ItemSDK.Id;
            Range = range;

            Priority = priority;
        }
    }
}
