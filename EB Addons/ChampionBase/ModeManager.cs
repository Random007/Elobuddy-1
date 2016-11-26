using System;
using System.Collections.Generic;
using System.Linq;
using ChampionTemplate.Modes;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Utils;

using static ChampionTemplate.Helper;
using static Lib.Utils;
using static ChampionTemplate.SpellManager;

namespace ChampionTemplate
{
    public static class ModeManager
    {
        private static List<ModeBase> Modes;

        private static ModeBase Active;

        public static void Load()
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
            if (Me.IsDead) return;

            Active.Execute();

            if(!Q.IsReady() && !W.IsReady() && !E.IsReady() && !R.IsReady())return;

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
