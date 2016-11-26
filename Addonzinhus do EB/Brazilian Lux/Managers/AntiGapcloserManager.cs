using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

using static BrazilianLux.Managers.SpellManager;
using static BrazilianLux.Misc.Helper;
using static BrazilianLux.MenuVariables;

namespace BrazilianLux.Managers
{
    public static class AntiGapcloserManager
    {
        public static void LoadAntiGapcloseManager()
        {
            Gapcloser.OnGapcloser += Gapcloser_OnGapcloser;
        }

        private static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if(sender.IsAlly)return;

            if(GapcloserMana > Me.ManaPercent)return;

            if (e.Target.IsMe || e.End.IsInRange(Me, 200))
            {
                if (UseQGapCloser && Q.CanCast(sender))
                {
                    Q.CastMinimumHitchance(sender, 20);
                }

                if (UseWGapCloser && W.IsReady())
                {
                    Player.CastSpell(SpellSlot.W);
                }
            }
        }
    }
}
