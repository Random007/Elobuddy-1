using BrazilianLux.Managers;
using BrazilianLux.Misc;
using EloBuddy;
using EloBuddy.Sandbox;

namespace BrazilianLux
{
    public static class Loader
    {
        public static Champion Champ => Champion.Lux;
        public static string Name => "Brazilian Lux";
        public static bool HasMana = true;

        public static void LoadLoader()
        {
            if (!SandboxConfig.IsBuddy)
            {
                Chat.Print("Sorry you are not buddy :(");
                return;
            }
            AddonDisabler.LoadAddonDisabler();
            SpellManager.LoadSpells();
            MyMenu.LoadMyMenu();
            ModeManager.LoadModeManager();
            DamageIndicator.LoadDamageIndicator();
            DrawingManager.LoadDrawingManager();

            ObjManager.LoadObjManager();
        }
    }
}
