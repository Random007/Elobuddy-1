using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.Sandbox;
using EloBuddy.SDK.Utils;
using Template.Misc;
using Template.Modes;
using static Template.Misc.Helper;
using static Template.Managers.SpellManager;

namespace Template
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
            if (!SandboxConfig.IsBuddy)
            {
                Chat.Print("Sorry you are not buddy :(", Color.Purple);
                Game.OnTick -= Game_OnTick;
                return;
            }

            if (AddonDisabler.CanDisable)
            {
                Game.OnTick -= Game_OnTick;
            }

            if (Me.IsDead) return;

            if (Active.CanRun())
            {
                Active.Execute();
            }

            if (!Q.IsReady() && !W.IsReady() && !E.IsReady() && !R.IsReady()) return;

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
