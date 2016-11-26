using System.Linq;
using BrazilianLux.Misc;
using EloBuddy.SDK;

using static BrazilianLux.Managers.SpellManager;
using static BrazilianLux.Misc.Helper;
using static BrazilianLux.MenuVariables;

namespace BrazilianLux.Modes
{
    public class JungleClear : ModeBase
    {
        public override bool CanRun()
        {
            var anyJungleMinion = EntityManager.MinionsAndMonsters.GetJungleMonsters().Any(m => m.IsValidTarget(2000));
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear) && anyJungleMinion;
        }

        public override void Execute()
        {
            if (Orbwalker.IsAutoAttacking) return;

            if (UseQJungleClear)
            {
                Q.SmartCast();
            }

            if (UseEJungleClear)
            {
                E.SmartCast();
            }

            if (UseWJungleClear)
            {
                var minionGrande =
                    EntityManager.MinionsAndMonsters.GetJungleMonsters().OrderBy(m => m.MaxHealth).FirstOrDefault(m => m.IsValidTarget(250));

                if (minionGrande != null)
                {
                    W.Cast(Me);
                }
            }
        }
    }
}
