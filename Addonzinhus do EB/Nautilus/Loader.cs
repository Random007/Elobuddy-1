using EloBuddy;

namespace Nautilus
{
    public static class Loader
    {
        public static Champion Champ => Champion.Nautilus;
        public static string Name => "Nautilus";
        public static bool HasMana = true;

        public static void LoadLoader()
        {
            AddonDisabler.LoadAddonDisabler();
            SpellManager.LoadSpells();
            MyMenu.LoadMyMenu();
            ModeManager.LoadModeManager();
            //DamageIndicator.LoadDamageIndicator();
            Mastery.LoadMastery();
        }
    }
}
