using AutoJanna.Modes.BlackYasuo.Modes;
using EloBuddy;
using EloBuddy.SDK;

using static AutoJanna.Misc.Helper;
using static AutoJanna.Managers.SpellManager;

namespace AutoJanna.Modes
{
    public class Combo : ModeBase
    {
        public override bool CanRun()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo) && Target != null;
        }

        public override void Execute()
        {
            if (Q.CanCast(Target))
            {
                Q.CastIfItWillHit(1);
            }

            if (W.CanCast(Target))
            {
                W.Cast(Target);
            }
        }
    }
}
