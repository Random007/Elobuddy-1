using BrazilianLux.Misc;
using EloBuddy;
using EloBuddy.SDK;

using static BrazilianLux.Misc.Helper;
using static BrazilianLux.Managers.SpellManager;
using static BrazilianLux.MenuVariables;

namespace BrazilianLux.Modes
{
    public class Flee : ModeBase
    {
        public override bool CanRun()
        {
            Target = TargetSelector.GetTarget(Q.Range + 200, DamageType.Magical);
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee) && Target != null;
        }

        public override void Execute()
        {
            if (UseQFlee)
            {
                Q.SmartCast();
            }
        }
    }
}
