using EloBuddy.SDK;
using Lib;

using static BlackYasuo.SpellManager;
using static BlackYasuo.MyMenu;

namespace BlackYasuo.Modes
{
    internal class JungleClear : ModeBase
    {
        public override bool CanRun()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            if (Orbwalker.IsAutoAttacking) return;

            if (FarmMenu.GetCheckBoxValue(Q, "jungle"))
            {
                Q.SmartCast();
            }

            if (FarmMenu.GetCheckBoxValue(E, "jungle") && !EManager.IsNearWallJump())
            {
                E.SmartCast();
            }
        }
    }
}
