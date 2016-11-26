using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Utils;
using Nautilus.Modes;
using Nautilus.Modes.BlackYasuo.Modes;

namespace Nautilus
{
    public static class ModeManager
    {
        private static List<ModeBase> Modes;

        private static ModeBase Active;

        public static void LoadModeManager()
        {
            Active = new Active();

            Modes = new List<ModeBase>
            {
                new Combo(),
                new Harass(),
                new LastHit(),
                new LaneClear(),
                new JungleClear(),
                new KillSteal(),
                new Flee(),
            };

            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            if (AddonDisabler.CanDisable)
            {
                Game.OnTick -= Game_OnTick;
            }

            if (Helper.Me.IsDead) return;

            Active.Execute();

            if (!SpellManager.Q.IsReady() && !SpellManager.W.IsReady() && !SpellManager.E.IsReady() && !SpellManager.R.IsReady()) return;

            foreach (var mode in Modes.Where(m => m.CanRun()))
            {
                try
                {
                    mode.Execute();
                }
                catch (Exception e)
                {
                    Logger.Error("Error in mode [{0}] \n {1}", mode.GetType().Name, e);
                }
            }
        }
    }
}
