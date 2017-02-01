using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

using Version = System.Version;

namespace BlackYasuo
{
    public static class Loader
    {
        private static Champion Champ => Champion.Yasuo;
        public static string Name => "BlackYasuo";

        public static void Load()
        {
            if (Champ != Player.Instance.Hero) return;

            LoadFeatures();
        }


        private static void LoadFeatures()
        {
            Helper.Load();
            SpellManager.Load();

            MyMenu.Load();
            ModeManager.Load();
            DrawingManager.Load();

            DashManager.Load();
        }

    }
}
