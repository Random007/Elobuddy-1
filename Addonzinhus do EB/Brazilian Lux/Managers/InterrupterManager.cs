using EloBuddy;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;

using static BrazilianLux.Managers.SpellManager;
using static BrazilianLux.Misc.Helper;
using static BrazilianLux.MenuVariables;

namespace BrazilianLux.Managers
{
    public static class InterrupterManager
    {
        public static void LoadInterrupterManager()
        {
            Interrupter.OnInterruptableSpell += Interrupter_OnInterruptableSpell;
        }

        private static void Interrupter_OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (sender.IsAlly) return;

            if (InterrupterMana > Me.ManaPercent) return;

            if (e.DangerLevel >= DangerLevel.Medium)
            {
                if (UseQInterrupter && Q.CanCast(sender))
                {
                    Q.CastMinimumHitchance(sender, 20);
                }
            }
        }
    }
}
