using BrazilianLux.Bases;
using BrazilianLux.Managers;
using BrazilianLux.Misc;
using EloBuddy;
using EloBuddy.Sandbox;
using EloBuddy.SDK.Menu;

using static BrazilianLux.Loader;
using static BrazilianLux.Managers.SpellManager;

namespace BrazilianLux
{
    public static class MyMenu
    {
        public static Menu MyMainMenu;

        public static Menu ComboMenu;
        public static Menu FarmMenu;
        public static Menu MiscMenu;
        public static Menu PredictionMenu;
        public static Menu DrawingsMenu;

        public static ColorSlider QColorSlider;
        public static ColorSlider WColorSlider;
        public static ColorSlider EColorSlider;
        public static ColorSlider RColorSlider;
        public static ColorSlider DamageIndicatorColorSlider;

        public static PredictionSlider QPredSlider;
        public static PredictionSlider EPredSlider;
        public static PredictionSlider RPredSlider;

        public static void LoadMyMenu()
        {
            if (!SandboxConfig.IsBuddy)
            {
                Chat.Print("Sorry you are not buddy :(");
                return;
            }
            MyMainMenu = MainMenu.AddMenu(Name, Name + "id");

            MyMainMenu.AddGroupLabel("Hu3");
            MyMainMenu.AddLabel("Hu3Hu3");

            ComboMenu = MyMainMenu.AddSubMenu("Combo", "comoboid" + Name);
            FarmMenu = MyMainMenu.AddSubMenu("Farm", "farmid" + Name);
            MiscMenu = MyMainMenu.AddSubMenu("Misc", "miscid" + Name);
            PredictionMenu = MyMainMenu.AddSubMenu("Prediction Rates", "prediction" + Name);
            DrawingsMenu = MyMainMenu.AddSubMenu("Drawings", "drawid" + Name);

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
            ComboMenu.CreateCheckbox(R, "harass");

            #endregion Combo Menu

            #region Farm Menu

            FarmMenu.AddGroupLabel("Last Hit");

            FarmMenu.CreateCheckbox(Q, "lasthit");
            FarmMenu.CreateCheckbox(E, "lasthit");
            FarmMenu.CreateSlider("elasthit", "Minimum minions required to hit to cast the spell E", 2, 1, 6);

            if (mana)
            {
                FarmMenu.CreateSlider("lasthit", "Mana must be higher than ({0}%) to cast any last hit spell", 50);
            }

            FarmMenu.AddGroupLabel("Lane Clear");

            FarmMenu.CreateCheckbox(Q, "laneclear");
            FarmMenu.CreateCheckbox(E, "laneclear");
            FarmMenu.CreateSlider("elaneclear", "Minimum minions required to hit to cast the spell E", 4, 1, 6);

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

            MiscMenu.CreateCheckbox(Q, "killsteal");
            MiscMenu.CreateCheckbox(E, "killsteal");
            MiscMenu.CreateCheckbox(R, "killsteal");

            if (mana)
            {
                MiscMenu.CreateSlider("killsteal", "Mana must be higher than ({0}%) to cast any killsteal spell", 30);
            }

            MiscMenu.AddGroupLabel("W Defender");

            MiscMenu.CreateCheckbox("wdefendme", "Use W if enemy is auto attacking the player");
            MiscMenu.CreateSlider("wdefendlife", "Player health must be lower than ({0}%) to cast W to defend the player", 60);
            MiscMenu.CreateSlider("defend", "Mana must be higher than ({0}%) to cast W to defend the player", 35);

            MiscMenu.AddGroupLabel("Anti-Gapcloser");

            MiscMenu.CreateCheckbox(Q, "antigapcloser");
            MiscMenu.CreateCheckbox(W, "antigapcloser");

            if (mana)
            {
                MiscMenu.CreateSlider("antigapcloser", "Mana must be higher than ({0}%) to cast any antigapcloser spell", 45);
            }

            MiscMenu.AddGroupLabel("Interrupter");
            MiscMenu.CreateCheckbox(Q, "interrupter");
            MiscMenu.CreateSlider("interrupter", "Mana must be higher than ({0}%) to cast any antigapcloser spell", 15);

            MiscMenu.AddGroupLabel("Flee");
            MiscMenu.CreateCheckbox(Q, "flee");

            MiscMenu.CreateSlider("flee", "Mana must be higher than ({0}%) to cast any flee spell", 5);

            #endregion Misc Menu

            #region PredictionMenu

            QPredSlider = new PredictionSlider(PredictionMenu, "predictionq", Q);
            EPredSlider = new PredictionSlider(PredictionMenu, "predictione", E);
            RPredSlider = new PredictionSlider(PredictionMenu, "predictionr", R);

            #endregion PredictionMenu

            #region Drawing Menu

            DrawingsMenu.CreateCheckbox("drawReady", "Draw spells only if they are ready to use");
            DrawingsMenu.AddSeparator();
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
