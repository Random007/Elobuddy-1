using System.Linq;
using EloBuddy.SDK;
using Nautilus.Modes.BlackYasuo.Modes;
using static Nautilus.SpellManager;
using static Nautilus.Helper;
using static Nautilus.MyMenu;

namespace Nautilus.Modes
{
    public class LaneClear : ModeBase
    {
        public override bool CanRun()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
            ;
        }

        public override void Execute()
        {

            var minions =
                EntityManager.MinionsAndMonsters.GetLaneMinions().FirstOrDefault(m => m.IsValidTarget(100) && true);

            if (minions == null) return;

            if (ComboMenu.GetCheckBoxValue(W, "combo") && W.IsReady() && Me.CountEnemyMinionsInRange(300) >= 6)
            {
                W.Cast();
            }

            if (ComboMenu.GetCheckBoxValue(E, "combo") && E.IsReady() && Me.CountEnemyMinionsInRange(E.Range + 50) >= 5)
            {
                E.Cast();
            }
        }
    }
}
