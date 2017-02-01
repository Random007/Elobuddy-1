using EloBuddy.SDK;
using Lib;

using static ChampionTemplate.Helper;
using static Lib.Utils;
using static ChampionTemplate.SpellManager;

namespace ChampionTemplate.Modes
{
    internal class Active : ModeBase
    {
        public override bool CanRun()
        {
            return true;
        }

        public override void Execute()
        {
            Combo.Target = GetTarget(Me.GetHighestSpellRange() + 250);
        }
    }
}
