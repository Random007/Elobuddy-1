using EloBuddy;
using EloBuddy.SDK;
using Nautilus.Modes.BlackYasuo.Modes;
using static Nautilus.SpellManager;
using static Nautilus.Helper;
using static Nautilus.MyMenu;

namespace Nautilus.Modes
{
    public class KillSteal:ModeBase

    {
        public override bool CanRun()
        {
            return true;
        }

        public override void Execute()
        {
            var enemy = TargetSelector.GetTarget(1300, DamageType.Magical);
            if (enemy == null) return;
            if (MiscMenu.GetCheckBoxValue(R, "killsteal") && R.IsReady() && enemy.IsValidTarget(R.Range))
            {
                if (enemy.Health < enemy.GetRDamage())R.Cast(enemy);
            }
        }
    }
}
