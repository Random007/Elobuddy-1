using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using Lib;
using static BlackYasuo.Helper;
using static BlackYasuo.SpellManager;
using static BlackYasuo.ModeManager;
using static BlackYasuo.MyMenu;

namespace BlackYasuo.Modes
{
    internal class Flee : ModeBase
    {
        public override bool CanRun()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            if (!MiscMenu.GetCheckBoxValue(E, "flee")) return;

            var closestEnemy =
                EntityCache.EnemyHeroes.OrderBy(e => e.Distance(Me)).FirstOrDefault(e => e.IsValidTarget(1000));

            var objToE = EntityCache.AllEnemies
                .Where(m => m.IsValidTarget(E.Range))
                .OrderBy(m => m.Distance(Game.CursorPos))
                .ThenByDescending(m => m.Distance(closestEnemy))
                .ThenByDescending(m => m.Distance(Me))
                .FirstOrDefault(
                    m =>
                        m.IsValidTarget(E.Range) && !m.HasEBuff() &&
                        m.GetPosAfterE().Distance(closestEnemy) > Me.Distance(closestEnemy));

            objToE?.CastE();
        }
    }
}
