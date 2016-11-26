using EloBuddy;
using EloBuddy.SDK;

using static BrazilianLux.Managers.SpellManager;
using static BrazilianLux.Misc.Helper;

namespace BrazilianLux.Modes
{
   public class Active : ModeBase
    {
        public override bool CanRun()
        {
            return true;
        }

        public override void Execute()
        {
            if (EObj != null && E.IsReady() && E.ToggleState >= 2 && EObj.CountEnemyHeroesInRangeWithPrediction(375, 50) >= 1)
            {
                Player.CastSpell(SpellSlot.E);
            }



        }
    }
}
