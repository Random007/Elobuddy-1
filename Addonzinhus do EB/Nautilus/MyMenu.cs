using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using Nautilus.Bases;

using static Nautilus.SpellManager;
using static Nautilus.Loader;

namespace Nautilus
{
    public static class MyMenu
    {
        public static Menu MyMainMenu;

        public static Menu ComboMenu;
        public static Menu FarmMenu;
        public static Menu MiscMenu;
        public static Menu DrawingsMenu;

        public static ColorSlider QColorSlider;
        public static ColorSlider WColorSlider;
        public static ColorSlider EColorSlider;
        public static ColorSlider RColorSlider;
        public static ColorSlider DamageIndicatorColorSlider;

        public static void LoadMyMenu()
        {
            MyMainMenu = MainMenu.AddMenu(Name, Name + "id");

            ComboMenu = MyMainMenu.AddSubMenu("Combo", "comoboid");
            FarmMenu = MyMainMenu.AddSubMenu("Farm", "farmid");
            MiscMenu = MyMainMenu.AddSubMenu("Misc", "miscid");
            DrawingsMenu = MyMainMenu.AddSubMenu("Drawings", "drawid");

            MyMainMenu.AddGroupLabel("Nautilus Addon");
            MyMainMenu.AddLabel("More features INC :)");

            var mana = HasMana;

            #region Combo Menu

            ComboMenu.AddGroupLabel("Combo");
            ComboMenu.CreateCheckbox(Q, "combo");
            ComboMenu.CreateCheckbox(W, "combo");
            ComboMenu.CreateCheckbox(E, "combo");
            ComboMenu.CreateCheckbox(R, "combo");

            ComboMenu.AddGroupLabel("Harass");
            if (mana)
            {
                ComboMenu.CreateSlider("harass", "Mana must be higher than ({0}%) to cast any harass spell", 30);
            }
            ComboMenu.CreateCheckbox(Q, "harass");
            ComboMenu.CreateCheckbox(W, "harass");
            ComboMenu.CreateCheckbox(E, "harass");

            #endregion Combo Menu

            #region Farm Menu

            FarmMenu.AddGroupLabel("Last Hit");

            FarmMenu.AddGroupLabel("Lane Clear");

            if (mana)
            {
                FarmMenu.CreateSlider("laneclear", "Mana must be higher than ({0}%) to cast any lane clear spell", 60);
            }

            FarmMenu.AddGroupLabel("Jungle Clear");

            FarmMenu.CreateCheckbox(Q, "jungleclear");
            FarmMenu.CreateCheckbox(W, "jungleclear");
            FarmMenu.CreateCheckbox(E, "jungleclear");

            if (mana)
            {
                FarmMenu.CreateSlider("jungleclear", "Mana must be higher than ({0}%) to cast any lane clear spell", 25);
            }

            #endregion Farm Menu

            #region Misc Menu

            MiscMenu.AddGroupLabel("Killsteal");

            MiscMenu.CreateCheckbox(R, "killsteal");

            if (mana)
            {
                MiscMenu.CreateSlider("killsteal", "Mana must be higher than ({0}%) to cast any killsteal spell", 10);
            }

            MiscMenu.AddGroupLabel("Anti-Gapcloser");

            if (mana)
            {
                MiscMenu.CreateSlider("antigapcloser", "Mana must be higher than ({0}%) to cast any antigapcloser spell", 10);
            }

            /*MiscMenu.CreateCheckbox("SmiteEnemyKS", "Ks with BlueSmite");*/
            MiscMenu.CreateCheckbox("Mastery", "Mastery after kill enemy?");
            /*MiscMenu.CreateCheckbox("SmiteMobsJG", "Allow Smite on JG Mobs");*/

            #endregion Misc Menu

            #region Drawing Menu

            QColorSlider = new ColorSlider(DrawingsMenu, SpellSlot.Q);
            WColorSlider = new ColorSlider(DrawingsMenu, SpellSlot.W);
            EColorSlider = new ColorSlider(DrawingsMenu, SpellSlot.E);
            RColorSlider = new ColorSlider(DrawingsMenu, SpellSlot.R);
            DamageIndicatorColorSlider = new ColorSlider(DrawingsMenu, "damageindicator");
            DrawingsMenu.CreateCheckbox("perDraw", "Draw Percentage");
            DrawingsMenu.CreateCheckbox("statDraw", "Draw statistics", false);

            #endregion Drawing Menu
        }
    }
}
