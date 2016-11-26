using System.Linq;
using AutoJanna.Modes.BlackYasuo.Modes;
using EloBuddy.SDK;

namespace AutoJanna.Modes
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
