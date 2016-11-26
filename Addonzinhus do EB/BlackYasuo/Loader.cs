using EloBuddy;
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
            AddonDisabler.LoadAddonDisabler();
            SpellManager.LoadSpells();
            MyMenu.LoadMyMenu();
            ModeManager.LoadModeManager();
            DamageIndicator.LoadDamageIndicator();
            DrawingManager.LoadDrawingManager();
        }
    }
}
