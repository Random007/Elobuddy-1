using EloBuddy.SDK;
using Nautilus.Modes.BlackYasuo.Modes;

namespace Nautilus.Modes
{
    public class LastHit : ModeBase
    {
        public override bool CanRun()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit);
        }

        public override void Execute()
        {
        }
    }
}
