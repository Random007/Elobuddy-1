using EloBuddy;
using EloBuddy.SDK;

namespace Mario_s_Activator.ItemsTick
{
    internal class Offensive
    {
        private static readonly BilgewaterCutlass bilgewaterCutlass = new BilgewaterCutlass();
        private static readonly BladeOfTheRuinedKing bladeOfTheRuinedKing = new BladeOfTheRuinedKing();

        public static void OnTick()
        {
            bilgewaterCutlass.OnTick();
            bladeOfTheRuinedKing.OnTick();
        }
    }

    public class BilgewaterCutlass : ItemBase
    {
        public override void InitializeItem()
        {
            thisItem = new Item(ItemId.Bilgewater_Cutlass, Items.GetItemRange((int)ItemId.Bilgewater_Cutlass));
        }

        public override void Execute()
        {
            thisItem.Cast(thisTarget);
        }
    }

    public class BladeOfTheRuinedKing : ItemBase
    {
        public override void InitializeItem()
        {
            thisItem = new Item(ItemId.Bilgewater_Cutlass, Items.GetItemRange((int)ItemId.Bilgewater_Cutlass));
        }

        public override void Execute()
        {
            if (Player.Instance.HealthPercent <= 90)
            {
                thisItem.Cast(thisTarget);
            }
        }
    }
}
