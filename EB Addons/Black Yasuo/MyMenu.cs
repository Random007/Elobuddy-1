using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using Lib;
using Lib.MenuControls;

using static BlackYasuo.Helper;
using static BlackYasuo.SpellManager;

namespace BlackYasuo
{
    internal static class MyMenu
    {
        internal static Menu ChampMenu;

        internal static Menu ComboMenu;
        internal static Menu FarmMenu;
        internal static Menu MiscMenu;
        internal static Menu DrawMenu;

        internal static ColorSlider QColor;
        internal static ColorSlider WColor;
        internal static ColorSlider EColor;
        internal static ColorSlider RColor;
        internal static ColorSlider DamageIndicatorColor;

        internal static CheckBox DrawReady;

        internal static void Load()
        {
            ChampMenu = MainMenu.AddMenu(Loader.Name, Loader.Name + Me.ChampionName);

            ComboMenu = ChampMenu.AddSubMenu("Combo Menu", "comboMenu");
            ComboMenu.AddGroupLabel("Combo");
            ComboMenu.CreateCheckbox(Q, "combo");
            ComboMenu.CreateCheckbox(E, "combo");
            ComboMenu.CreateCheckbox(R, "combo");
            ComboMenu.CreateSlider("rCount", "Minimum enemy to use R on combo", 3, 0, 5);
            ComboMenu.CreateCheckbox("rSmart", "Use Smart R 1x1");
            ComboMenu.AddGroupLabel("Harass");
            ComboMenu.CreateCheckbox(Q, "harass");
            //ComboMenu.CreateSlider("harassMana", "Mana% must be below [{0}%] to use harass spells", 40);

            FarmMenu = ChampMenu.AddSubMenu("Farm Menu", "farmMenu");
            FarmMenu.AddGroupLabel("LaneClear");
            FarmMenu.CreateCheckbox(Q, "lane");
            FarmMenu.CreateCheckbox(E, "lane");
            //FarmMenu.CreateSlider("laneMana", "Mana% must be below [{0}%] to use lane clear spells", 60);
            FarmMenu.AddGroupLabel("LastHit");
            FarmMenu.CreateCheckbox(Q, "last");
            FarmMenu.CreateCheckbox(E, "last");
            //FarmMenu.CreateSlider("lastMana", "Mana% must be below [{0}%] to use last hit spells", 40);
            FarmMenu.AddGroupLabel("JungleClear");
            FarmMenu.CreateCheckbox(Q, "jungle");
            FarmMenu.CreateCheckbox(E, "jungle");
            //FarmMenu.CreateSlider("jungleMana", "Mana% must be below [{0}%] to use jungle spells", 20);

            MiscMenu = ChampMenu.AddSubMenu("Misc Menu", "miscMenu");
            MiscMenu.AddGroupLabel("Flee E");
            MiscMenu.AddLabel("Will use E on the best minion to flee from the enemies");
            MiscMenu.CreateCheckbox(E, "flee");

            DrawMenu = ChampMenu.AddSubMenu("Drawings Menu", "drawMenu");

            #region DrawMenu

            DrawReady = DrawMenu.CreateCheckbox("drawReady", "Draw spells only if they are ready");

            DrawMenu.AddSeparator(10);

            if (Q != null)
            {
                QColor = new ColorSlider(SpellSlot.Q);
                DrawMenu.Add("qColorBox", QColor.BaseCheckBox);
                DrawMenu.Add("qColorSlider", QColor.BaseSlider);
            }

            if (W != null)
            {
                WColor = new ColorSlider(SpellSlot.W);
                DrawMenu.Add("wColorBox", WColor.BaseCheckBox);
                DrawMenu.Add("wColorSlider", WColor.BaseSlider);
            }

            if (E != null)
            {
                EColor = new ColorSlider(SpellSlot.E);
                DrawMenu.Add("eColorBox", EColor.BaseCheckBox);
                DrawMenu.Add("eColorSlider", EColor.BaseSlider);
            }

            if (R != null)
            {
                RColor = new ColorSlider(SpellSlot.R);
                DrawMenu.Add("rColorBox", RColor.BaseCheckBox);
                DrawMenu.Add("rColorSlider", RColor.BaseSlider);
            }

            DrawMenu.AddGroupLabel("Damage Indicator");
            DamageIndicatorColor = new ColorSlider("Damage Indicator");
            DrawMenu.Add("damageColorBox", DamageIndicatorColor.BaseCheckBox);
            DrawMenu.CreateCheckbox("statDraw", "Draw statistics");
            DrawMenu.CreateCheckbox("perDraw", "Draw percentage");
            DrawMenu.Add("damageColorSlider", DamageIndicatorColor.BaseSlider);
            
            #endregion DrawMenu
        }
    }
}
