using EloBuddy;
using EloBuddy.SDK;
using Nautilus.Modes.BlackYasuo.Modes;
using static Nautilus.SpellManager;
using static Nautilus.Helper;
using static Nautilus.MyMenu;

namespace Nautilus.Modes
{
   public class Harass : ModeBase
    {
        public override bool CanRun()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            
            var enemy = TargetSelector.GetTarget(900, DamageType.Magical);
            if (enemy == null) return;
            if (ComboMenu.GetCheckBoxValue(Q, "harass") && Q.IsReady() && enemy.IsValidTarget(Q.Range))
            {
                Q.CastMinimumHitchance(enemy, 55);
            }

            if (ComboMenu.GetCheckBoxValue(E, "harass") && E.IsReady() && enemy.IsValidTarget(E.Range) &&
                enemy.IsInRange(Me, E.Range +50))
            {
                E.Cast();
            }
        }
    }
}
