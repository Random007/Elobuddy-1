using EloBuddy;
using EloBuddy.SDK;

namespace Activator.ItemBases
{
    internal enum ItemPriority
    {
        Low = 0,
        Medium = 1,
        High = 2,
        VeryHigh = 3,
        Extreme = 4
    }

    internal abstract class ItemBase
    {
        public abstract Item ItemSDK { get; }

        public abstract string Name { get; }
        public abstract int ID { get; }
        public abstract int Range { get; }

        public abstract ItemPriority Priority { get; set; }

        public abstract bool CanCast();

        public virtual bool Cast(Obj_AI_Base target = null)
        {
            if (!CanCast()) return false;

            if (target != null)
            {
                ItemSDK.Cast(target);
                return true;
            }

            ItemSDK.Cast();
            return true;
        }
    }
}
