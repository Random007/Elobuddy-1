using System.Linq;
using AutoJanna.Modes.BlackYasuo.Modes;
using EloBuddy.SDK;

using static AutoJanna.Managers.SpellManager;

namespace AutoJanna.Modes
{
    public class LaneClear :ModeBase
    {
        public override bool CanRun()
        {
            var anyMinion = EntityManager.MinionsAndMonsters.GetLaneMinions().Any(m => m.IsEnemy && m.IsValidTarget(2000));
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear) && anyMinion;
        }

        public override void Execute()
        {
            if (Q.IsReady())
            {
                Q.CastOnBestFarmPosition(5);
            }
        }
    }
}
