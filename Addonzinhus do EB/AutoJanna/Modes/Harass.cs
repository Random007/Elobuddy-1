using AutoJanna.Modes.BlackYasuo.Modes;
using EloBuddy;
using EloBuddy.SDK;

using static AutoJanna.Misc.Helper;

namespace AutoJanna.Modes
{
   public class Harass : ModeBase
    {
        public override bool CanRun()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass) && Target != null;
        }

        public override void Execute()
        {
        }
    }
}
