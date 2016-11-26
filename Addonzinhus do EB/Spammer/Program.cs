using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Spammer
{
    class Program
    {
        public static Menu HotkeysMenu;
        public static bool spammer = false;
        public static float gameTime = 0;

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;

        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            HotkeysMenu = MainMenu.AddMenu("Hotkeys Hu3", "14514515");
            HotkeysMenu.Add("Spammer", new KeyBind("/all GG izi, feeda maix :)", false, KeyBind.BindTypes.HoldActive, 'Z'));
            HotkeysMenu.Add("Spammer2", new KeyBind("HU3H3U3H3UH3U3H3UH3U3HU3", false, KeyBind.BindTypes.HoldActive, 'X'));
            HotkeysMenu.Add("Spammer3", new KeyBind("?", false, KeyBind.BindTypes.HoldActive, 'C'));

            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            var keybind = HotkeysMenu.Get<KeyBind>("Spammer");
            var ativo = keybind.CurrentValue;
            if (ativo)
            {
                Chat.Say("/all GG izi, feeda maix :)");
            }

            var keybind2 = HotkeysMenu.Get<KeyBind>("Spammer2");
            var ativo2 = keybind2.CurrentValue;
            if (ativo2)
            {
                Chat.Say("/all www.twitch.tv/NITGamesOficial");
            }

            var keybind3 = HotkeysMenu.Get<KeyBind>("Spammer3");
            var ativo3 = keybind3.CurrentValue;
            if (ativo3)
            {
                Chat.Say("/all ?");
            }
        }
    }
} 
