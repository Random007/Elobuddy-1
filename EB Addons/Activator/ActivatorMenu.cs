using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy.SDK.Menu;

namespace Activator
{
    internal static class ActivatorMenu
    {
        public static Menu ActMenu;
        public static Menu OffensiveMenu;
        public static Menu DefensiveMenu;
        public static Menu ConsumablesMenu;
        public static Menu DangerHandlerMenu;
        public static Menu DrawingMenu;

        public static void Load()
        {
            MainMenu.AddMenu("HU3", "Hu3");
        }
    }
}
