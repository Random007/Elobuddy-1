using BrazilianLux.Misc;
using EloBuddy;
using EloBuddy.SDK;

using static BrazilianLux.Managers.SpellManager;
using static BrazilianLux.Misc.Helper;
using static BrazilianLux.MenuVariables;

namespace BrazilianLux.Modes
{
   public class Harass : ModeBase
    {
        public override bool CanRun()
        {
            Target = TargetSelector.GetTarget(2000, DamageType.Magical);
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass) && Target != null;
        }

        public override void Execute()
        {
            if (Orbwalker.IsAutoAttacking) return;

            if (UseQCombo)
            {
                Q.SmartCast();
            }
            if (UseECombo)
            {
                E.SmartCast(80);
            }
        }
    }
}
