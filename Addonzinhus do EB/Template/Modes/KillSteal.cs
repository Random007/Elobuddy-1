using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy.SDK;

namespace Template.Modes
{
    public class KillSteal:ModeBase
    {
        public override bool CanRun()
        {
            var anyEnemy = EntityManager.Heroes.Enemies.Any(e => e.IsValidTarget(2000));
            return anyEnemy;
        }

        public override void Execute()
        {
        }
    }
}
