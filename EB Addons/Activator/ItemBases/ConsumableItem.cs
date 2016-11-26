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
    internal class ConsumableItem : ItemBase
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

        public ConsumableItem(int id, ItemPriority priority = ItemPriority.Low)
        {
            ItemSDK = new Item(id);

            Name = ItemSDK.Id.ToString().Replace('_', ' ');
            ID = (int)ItemSDK.Id;
            Range = 0;

            Priority = priority;
        }

        public ConsumableItem(ItemId itemid, ItemPriority priority = ItemPriority.Low)
        {
            ItemSDK = new Item(itemid);

            Name = ItemSDK.Id.ToString().Replace('_', ' ');
            ID = (int)ItemSDK.Id;
            Range = 0;

            Priority = priority;
        }
    }
}
