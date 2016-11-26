using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;

using static Lib.Utils;
using static ChampionTemplate.Helper;
using static ChampionTemplate.SpellManager;
using static ChampionTemplate.ModeManager;

namespace ChampionTemplate.Modes
{
    internal class Flee : ModeBase
    {
        public override bool CanRun()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {

        }
    }
}
