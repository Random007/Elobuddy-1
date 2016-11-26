using EloBuddy;
using EloBuddy.SDK.Menu;
using Template.Bases;
using Template.Misc;
using static Template.Managers.SpellManager;

namespace Template
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
            MyMainMenu = MainMenu.AddMenu(Loader.Name, Loader.Name + "id");

            ComboMenu = MyMainMenu.AddSubMenu("Combo", "comoboid" + Loader.Name);
            FarmMenu = MyMainMenu.AddSubMenu("Farm", "farmid" + Loader.Name);
            MiscMenu = MyMainMenu.AddSubMenu("Misc", "miscid" + Loader.Name);
            DrawingsMenu = MyMainMenu.AddSubMenu("Drawings", "drawid" + Loader.Name);

            MyMainMenu.AddGroupLabel("Hu3");
            MyMainMenu.AddLabel("Hu3Hu3");

            var mana = Loader.HasMana;

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
            ComboMenu.CreateCheckbox(R, "harass");

            #endregion Combo Menu

            #region Farm Menu

            FarmMenu.AddGroupLabel("Last Hit");

            FarmMenu.CreateCheckbox(Q, "lasthit");
            FarmMenu.CreateCheckbox(W, "lasthit");
            FarmMenu.CreateCheckbox(E, "lasthit");
            FarmMenu.CreateCheckbox(R, "lasthit");

            if (mana)
            {
                ComboMenu.CreateSlider("lasthit", "Mana must be higher than ({0}%) to cast any last hit spell", 50);
            }

            FarmMenu.AddGroupLabel("Lane Clear");

            FarmMenu.CreateCheckbox(Q, "laneclear");
            FarmMenu.CreateCheckbox(W, "laneclear");
            FarmMenu.CreateCheckbox(E, "laneclear");
            FarmMenu.CreateCheckbox(R, "laneclear");

            if (mana)
            {
                FarmMenu.CreateSlider("laneclear", "Mana must be higher than ({0}%) to cast any lane clear spell", 60);
            }

            FarmMenu.AddGroupLabel("Jungle Clear");

            FarmMenu.CreateCheckbox(Q, "jungleclear");
            FarmMenu.CreateCheckbox(W, "jungleclear");
            FarmMenu.CreateCheckbox(E, "jungleclear");
            FarmMenu.CreateCheckbox(R, "jungleclear");

            if (mana)
            {
                FarmMenu.CreateSlider("jungleclear", "Mana must be higher than ({0}%) to cast any lane clear spell", 25);
            }

            #endregion Farm Menu

            #region Misc Menu

            MiscMenu.AddGroupLabel("Killsteal");

            MiscMenu.CreateCheckbox(Q, "killsteal");
            MiscMenu.CreateCheckbox(W, "killsteal");
            MiscMenu.CreateCheckbox(E, "killsteal");
            MiscMenu.CreateCheckbox(R, "killsteal");

            if (mana)
            {
                MiscMenu.CreateSlider("killsteal", "Mana must be higher than ({0}%) to cast any killsteal spell", 10);
            }

            MiscMenu.AddGroupLabel("Anti-Gapcloser");

            MiscMenu.CreateCheckbox(Q, "antigapcloser");
            MiscMenu.CreateCheckbox(W, "antigapcloser");
            MiscMenu.CreateCheckbox(E, "antigapcloser");
            MiscMenu.CreateCheckbox(R, "antigapcloser");

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
        }
    }
}
