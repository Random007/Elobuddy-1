using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using Template.Modes.BlackYasuo.Modes;

using static Template.Misc.Helper;

namespace Template.Modes
{
   public class Harass : ModeBase
    {
        public override bool CanRun()
        {
            Target = TargetSelector.GetTarget(2000, DamageType.True);
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass) && Target != null;
        }

        public override void Execute()
        {
        }
    }
}
