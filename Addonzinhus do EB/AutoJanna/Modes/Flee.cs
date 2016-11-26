using AutoJanna.Modes.BlackYasuo.Modes;
using EloBuddy.SDK;

namespace AutoJanna.Modes
{
    public class Flee : ModeBase
    {
        public override bool CanRun()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
        }
    }
}
