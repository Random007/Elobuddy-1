using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using Nautilus.Modes.BlackYasuo.Modes;
using static Nautilus.SpellManager;
using static Nautilus.Helper;
using static Nautilus.MyMenu;

namespace Nautilus.Modes
{
    public class Combo : ModeBase
    {
        public override bool CanRun()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            var enemy = TargetSelector.GetTarget(1300, DamageType.Magical);
            if (enemy == null) return;
            if (ComboMenu.GetCheckBoxValue(Q, "combo") && Q.IsReady() && enemy.IsValidTarget(Q.Range) && !enemy.IsInRange(Me, 200))
            {
                Q.CastMinimumHitchance(enemy, 75);
            }

            if (ComboMenu.GetCheckBoxValue(W, "combo") && W.IsReady() && enemy.IsValidTarget(Me.AttackRange + 100))
            {
                W.Cast();
            }

            if (ComboMenu.GetCheckBoxValue(E, "combo") && E.IsReady() && enemy.IsValidTarget(E.Range) &&
                enemy.IsInRange(Me, E.Range))
            {
                E.Cast();
            }
            if (ComboMenu.GetCheckBoxValue(R, "combo") && R.IsReady() && enemy.IsValidTarget(R.Range))
            {
                if (enemy.Health < enemy.GetRDamage())
                {
                    R.Cast(enemy);
                }
            }
        }
    }
}
