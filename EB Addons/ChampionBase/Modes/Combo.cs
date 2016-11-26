using EloBuddy;
using EloBuddy.SDK;

using static Lib.Utils;
using static ChampionTemplate.Helper;
using static ChampionTemplate.SpellManager;
using static ChampionTemplate.ModeManager;

namespace ChampionTemplate.Modes
{
    internal class Combo : ModeBase
    {
        internal static AIHeroClient Target;

        public override bool CanRun()
        {
            return Target != null && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {

        }
    }
}
