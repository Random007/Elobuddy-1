using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using Nautilus.Modes.BlackYasuo.Modes;
using static Nautilus.SpellManager;
using static Nautilus.Helper;
using static Nautilus.MyMenu;

namespace Nautilus.Modes
{
    public class JungleClear : ModeBase
    {
        public override bool CanRun()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            var minions =
                EntityManager.MinionsAndMonsters.Monsters.FirstOrDefault(
                    m => m.IsValidTarget(1000) && !m.BaseSkinName.Contains("Mini"));
            if (minions == null) return;
            if (FarmMenu.GetCheckBoxValue(Q, "jungleclear") && Q.IsReady() && minions.IsValidTarget(Q.Range))
            {
                Q.CastMinimumHitchance(minions, 5);
            }

            if (FarmMenu.GetCheckBoxValue(W, "jungleclear") && W.IsReady() && minions.IsValidTarget(Me.AttackRange + 50))
            {
                W.Cast();
            }

            if (FarmMenu.GetCheckBoxValue(E, "jungleclear") && E.IsReady() && minions.IsValidTarget(E.Range) &&
                minions.IsInRange(Me, E.Range +50))
            {
                E.Cast();
            }
        }
    }
}
