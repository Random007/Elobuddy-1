using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy.SDK;

namespace Template.Modes
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
        }
    }
}
