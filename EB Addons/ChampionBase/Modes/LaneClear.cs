using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using Lib;

using static Lib.Utils;
using static ChampionTemplate.Helper;
using static ChampionTemplate.SpellManager;
using static ChampionTemplate.ModeManager;

namespace ChampionTemplate.Modes
{
    internal class LaneClear : ModeBase
    {
        public override bool CanRun()
        {
            var anyMinion = EntityCache.EnemyMinions.FirstOrDefault(m => m.IsValidTarget(Me.GetHighestSpellRange() + 500));

            return anyMinion != null && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {

        }
    }
}
