using System.Drawing;
using EloBuddy;
using EloBuddy.Sandbox;
using EloBuddy.SDK.Events;
using Template.Managers;
using Template.Misc;

namespace Template
{
    public static class Loader
    {
        public static Champion Champ => Champion.Kled;
        public static string Name => "Template";
        public static bool HasMana = true;

        public static void LoadLoader()
        {
            if (!SandboxConfig.IsBuddy)
            {
                Chat.Print("Sorry you are not buddy :(", Color.Purple);
                return;
            }

            AddonDisabler.LoadAddonDisabler();
            SpellManager.LoadSpells();
            MyMenu.LoadMyMenu();
            ModeManager.LoadModeManager();
            DamageIndicator.LoadDamageIndicator();
            DrawingManager.LoadDrawingManager();

            Spaguetti.Load();
        }
    }
}
