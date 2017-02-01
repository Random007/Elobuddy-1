using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using static BlackYasuo.Helper;
using static BlackYasuo.SpellManager;
using static BlackYasuo.ModeManager;
using static BlackYasuo.MyMenu;

namespace BlackYasuo.Modes
{
    internal class Harass : ModeBase
    {
        public override bool CanRun()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            if (Orbwalker.IsAutoAttacking) return;

            var target = TargetSelector.GetTarget(Q.Range, DamageType.Physical);

            if(target == null || !ComboMenu.GetCheckBoxValue(Q, "harass"))return;

            Q.CastMinimumHitchance(target, HasQ3() ? 71 : 51);
        }
    }
}
