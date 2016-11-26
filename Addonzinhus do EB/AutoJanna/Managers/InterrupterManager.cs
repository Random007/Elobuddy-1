using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;

using static AutoJanna.Managers.SpellManager;
using static AutoJanna.Misc.Helper;
using static AutoJanna.MenuVariables;

namespace AutoJanna.Managers
{
    public static class InterrupterManager
    {
        private static int LastInterruptQ;

        public static void LoadInterrupterManager()
        {
            Interrupter.OnInterruptableSpell += Interrupter_OnInterruptableSpell;
        }

        private static void Interrupter_OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if(sender.IsAlly)return;

            if (e.EndTime >= 1600)
            {
                if (Q.IsReady() && e.DangerLevel <= DangerLevel.Medium && sender.IsEnemy && sender.IsValidTarget(Q.Range + 700))
                {
                    Q.Cast(sender);
                    LastInterruptQ = Environment.TickCount;
                    DelayQ = true;
                }
            }
            else
            {
                if (Q.IsReady() && e.DangerLevel <= DangerLevel.Medium && sender.IsEnemy && sender.IsValidTarget(Q.Range))
                {
                    Q.Cast(sender);
                    LastInterruptQ = Environment.TickCount;
                }
            }


            if (!Q.IsReady() && R.IsReady() && Environment.TickCount - LastInterruptQ > 1600 && sender.IsValidTarget(R.Range))
            {
                R.Cast();
            }
        }
    }
}
