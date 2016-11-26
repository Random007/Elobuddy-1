using AutoJanna.Bases;
using AutoJanna.Managers;
using AutoJanna.Misc;
using EloBuddy;
using EloBuddy.SDK.Menu;

namespace AutoJanna
{
    public static class MyMenu
    {
        public static Menu MyMainMenu;

        public static Menu ComboMenu;
        public static Menu FarmMenu;
        public static Menu MiscMenu;
        public static Menu DrawingsMenu;
        public static Menu DebugMenu;

        public static ColorSlider QColorSlider;
        public static ColorSlider WColorSlider;
        public static ColorSlider EColorSlider;
        public static ColorSlider RColorSlider;
        public static ColorSlider DamageIndicatorColorSlider;

        public static void LoadMyMenu()
        {
            MyMainMenu = MainMenu.AddMenu(Loader.Name, Loader.Name + "id");

            ComboMenu = MyMainMenu.AddSubMenu("Combo", "comboid" + Loader.Name);
            FarmMenu = MyMainMenu.AddSubMenu("Farm", "farmid" + Loader.Name);
            MiscMenu = MyMainMenu.AddSubMenu("Misc", "miscid" + Loader.Name);
            DrawingsMenu = MyMainMenu.AddSubMenu("Drawings", "drawid" + Loader.Name);
            DebugMenu = MyMainMenu.AddSubMenu("Debug", "debugid" + Loader.Name);

            MyMainMenu.AddGroupLabel("Hu3");
            MyMainMenu.AddLabel("Hu3Hu3");

            var mana = Loader.HasMana;

            #region Combo Menu

            ComboMenu.AddGroupLabel("Combo");
            ComboMenu.CreateCheckbox(SpellManager.Q, "combo");
            ComboMenu.CreateCheckbox(SpellManager.W, "combo");
            ComboMenu.CreateCheckbox(SpellManager.E, "combo");
            ComboMenu.CreateCheckbox(SpellManager.R, "combo");

            ComboMenu.AddGroupLabel("Harass");
            if (mana)
            {
                ComboMenu.CreateSlider("harass", "Mana must be higher than ({0}%) to cast any harass spell", 30);
            }
            ComboMenu.CreateCheckbox(SpellManager.Q, "harass");
            ComboMenu.CreateCheckbox(SpellManager.W, "harass");
            ComboMenu.CreateCheckbox(SpellManager.E, "harass");
            ComboMenu.CreateCheckbox(SpellManager.R, "harass");

            #endregion Combo Menu

            #region Farm Menu

            FarmMenu.AddGroupLabel("Last Hit");

            FarmMenu.CreateCheckbox(SpellManager.Q, "lasthit");
            FarmMenu.CreateCheckbox(SpellManager.W, "lasthit");
            FarmMenu.CreateCheckbox(SpellManager.E, "lasthit");
            FarmMenu.CreateCheckbox(SpellManager.R, "lasthit");

            if (mana)
            {
                ComboMenu.CreateSlider("lasthit", "Mana must be higher than ({0}%) to cast any last hit spell", 50);
            }

            FarmMenu.AddGroupLabel("Lane Clear");

            FarmMenu.CreateCheckbox(SpellManager.Q, "laneclear");
            FarmMenu.CreateCheckbox(SpellManager.W, "laneclear");
            FarmMenu.CreateCheckbox(SpellManager.E, "laneclear");
            FarmMenu.CreateCheckbox(SpellManager.R, "laneclear");

            if (mana)
            {
                FarmMenu.CreateSlider("laneclear", "Mana must be higher than ({0}%) to cast any lane clear spell", 60);
            }

            FarmMenu.AddGroupLabel("Jungle Clear");

            FarmMenu.CreateCheckbox(SpellManager.Q, "jungleclear");
            FarmMenu.CreateCheckbox(SpellManager.W, "jungleclear");
            FarmMenu.CreateCheckbox(SpellManager.E, "jungleclear");
            FarmMenu.CreateCheckbox(SpellManager.R, "jungleclear");

            if (mana)
            {
                FarmMenu.CreateSlider("jungleclear", "Mana must be higher than ({0}%) to cast any lane clear spell", 25);
            }

            #endregion Farm Menu

            #region Misc Menu

            MiscMenu.AddGroupLabel("Killsteal");

            MiscMenu.CreateCheckbox(SpellManager.Q, "killsteal");
            MiscMenu.CreateCheckbox(SpellManager.W, "killsteal");
            MiscMenu.CreateCheckbox(SpellManager.E, "killsteal");
            MiscMenu.CreateCheckbox(SpellManager.R, "killsteal");

            if (mana)
            {
                MiscMenu.CreateSlider("killsteal", "Mana must be higher than ({0}%) to cast any killsteal spell", 10);
            }

            MiscMenu.AddGroupLabel("Anti-Gapcloser");

            MiscMenu.CreateCheckbox(SpellManager.Q, "antigapcloser");
            MiscMenu.CreateCheckbox(SpellManager.W, "antigapcloser");
            MiscMenu.CreateCheckbox(SpellManager.E, "antigapcloser");
            MiscMenu.CreateCheckbox(SpellManager.R, "antigapcloser");

            if (mana)
            {
                MiscMenu.CreateSlider("antigapcloser", "Mana must be higher than ({0}%) to cast any antigapcloser spell", 10);
            }

            #endregion Misc Menu

            #region Drawing Menu

            DrawingsMenu.CreateCheckbox("drawReady", "Draw spells only if they are ready to use");
            DrawingsMenu.AddSeparator();
            QColorSlider = new ColorSlider(DrawingsMenu,SpellSlot.Q);
            WColorSlider = new ColorSlider(DrawingsMenu, SpellSlot.W);
            EColorSlider = new ColorSlider(DrawingsMenu, SpellSlot.E);
            RColorSlider = new ColorSlider(DrawingsMenu, SpellSlot.R);
            DamageIndicatorColorSlider = new ColorSlider(DrawingsMenu, "damageindicator");
            DrawingsMenu.CreateCheckbox("perDraw", "Draw Percentage");
            DrawingsMenu.CreateCheckbox("statDraw", "Draw statistics", false);

            #endregion Drawing Menu

            DebugMenu.CreateCheckbox("debugAA", "Debug AA", false);
            DebugMenu.AddLabel("Danger");
            DebugMenu.CreateCheckbox("debugDanger", "Debug Danger", false);
            DebugMenu.CreateCheckbox("debugMissiles", "Debug Missiles", false);
            //DebugMenu.CreateCheckbox("debug", "Debug AA", false);
            //DebugMenu.CreateCheckbox("debugAA", "Debug AA", false);
        }
    }
}
