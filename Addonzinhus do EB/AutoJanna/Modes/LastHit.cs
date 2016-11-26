using System.Linq;
using AutoJanna.Modes.BlackYasuo.Modes;
using EloBuddy.SDK;

namespace AutoJanna.Modes
{
    public class LastHit : ModeBase
    {
        public override bool CanRun()
        {
            var anyMinion = EntityManager.MinionsAndMonsters.GetLaneMinions().Any(m => m.IsEnemy && m.IsValidTarget(2000));
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit) && anyMinion;
        }

        public override void Execute()
        {
        }
    }
}
