using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy.SDK.Events;

namespace Template.Managers
{
    public static class InterrupterManager
    {
        public static void LoadInterrupterManager()
        {
            Interrupter.OnInterruptableSpell += Interrupter_OnInterruptableSpell;
        }

        private static void Interrupter_OnInterruptableSpell(EloBuddy.Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            
        }
    }
}
