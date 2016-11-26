using AutoJanna.Managers;
using AutoJanna.Misc;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using static AutoJanna.Misc.Helper;

namespace AutoJanna
{
    public static class Loader
    {
        public static Champion Champ => Champion.Janna;
        public static string Name => "AutoJanna";
        public static bool HasMana = true;

        public static void LoadLoader()
        {
            //Common Load
            AddonDisabler.LoadAddonDisabler();
            SpellManager.LoadSpells();
            MyMenu.LoadMyMenu();
            ModeManager.LoadModeManager();
            DamageIndicator.LoadDamageIndicator();
            DrawingManager.LoadDrawingManager();
            //Common Load

            //Custom Stuff for AutoJanna
            Map.LoadMap();
            PreventUltCancel.LoadPreventUltCancel();
            DangerManager.LoadDangerHandler();
            InterrupterManager.LoadInterrupterManager();
            AntiGapcloserManager.LoadAntiGapcloserManager();
            RecallManager.LoadRecallManager();
            AutoAttackManager.LoadAutoAttackManager();

            BuildItemsManager.LoadBuildItemsManager();
            AutoLevelSpellManager.LoadAutoLevelSpellManager();
            //Custom stuff for AutoJanna
            MYAdcSelectionManager.LoadMyAdcSelectionManager();

            Orbwalker.ActiveModesFlags = Orbwalker.ActiveModes.Combo;
        }
    }
}
