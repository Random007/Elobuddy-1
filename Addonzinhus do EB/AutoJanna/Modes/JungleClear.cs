using System.Linq;
using AutoJanna.Modes.BlackYasuo.Modes;
using EloBuddy.SDK;

namespace AutoJanna.Modes
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
        }
    }
}
