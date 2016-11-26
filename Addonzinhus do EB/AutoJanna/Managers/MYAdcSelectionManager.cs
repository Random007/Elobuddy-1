using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoJanna.Misc;
using EloBuddy;
using EloBuddy.SDK;

using static AutoJanna.Misc.Helper;

namespace AutoJanna.Managers
{
    public static class MYAdcSelectionManager
    {
        public static List<Champion> ADCs = new List<Champion>
        {
            Champion.Ashe,
            Champion.Caitlyn,
            Champion.Corki,
            Champion.Draven,
            Champion.Ezreal,
            Champion.Graves,
            Champion.Jhin,
            Champion.Jinx,
            Champion.Kalista,
            Champion.KogMaw,
            Champion.Lucian,
            Champion.MissFortune,
            Champion.Quinn,
            Champion.MissFortune,
            Champion.Quinn,
            Champion.Sivir,
            Champion.Tristana,
            Champion.Twitch,
            Champion.Urgot,
            Champion.Varus,
            Champion.Vayne,
            //Unusual Adcs
            Champion.TwistedFate,
            Champion.Kennen
        };

        public static void LoadMyAdcSelectionManager()
        {
            Core.DelayAction(Load, 30);
        }

        private static void Load()
        {
            Chat.Print("Selecting The ADC!");

            AdcSelection();
            Messages.OnMessage += Messages_OnMessage;

        }

        private static void AdcSelection()
        {
            if (MyADC == null)
            {
                var adc = EntityManager.Heroes.Allies.FirstOrDefault(a => Map.BotLane.IsInside(a) && ADCs.Contains(a.Hero));
                if (adc == null)
                {
                    Chat.Print("No ADC Found reloading and trying again");
                    Core.DelayAction(AdcSelection, 5000);
                    return;
                }
                MyADC = adc;
            }
        }

        private static void Messages_OnMessage(Messages.WindowMessage args)
        {
            if (args.Message != WindowMessages.LeftButtonUp) return;

            var targetNearMouse =
                EntityManager.Heroes.Allies.OrderBy(a => a.Distance(Game.CursorPos))
                    .FirstOrDefault(a => !a.IsMe && a.IsInRange(Game.CursorPos, 200));

            if (targetNearMouse == null) return;
            Chat.Print("Selected new ADC = " + targetNearMouse.ChampionName);
            MyADC = targetNearMouse;
        }
    }
}
