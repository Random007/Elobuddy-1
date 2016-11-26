using System.Drawing;
using AutoJanna.Managers;
using AutoJanna.Misc;

using static AutoJanna.Managers.SpellManager;
using static AutoJanna.MyMenu;

namespace AutoJanna
{
    public static class MenuVariables
    {
        #region Combo
        public static bool UseQCombo => ComboMenu.GetCheckBoxValue(Q, "combo");
        public static bool UseWCombo => ComboMenu.GetCheckBoxValue(W, "combo");
        public static bool UseECombo => ComboMenu.GetCheckBoxValue(E, "combo");
        public static bool UseRCombo => ComboMenu.GetCheckBoxValue(R, "combo");
        #endregion Combo

        #region Harass
        public static bool UseQHarass => ComboMenu.GetCheckBoxValue(Q, "harass");
        public static bool UseWHarass => ComboMenu.GetCheckBoxValue(W, "harass");
        public static bool UseEHarass => ComboMenu.GetCheckBoxValue(E, "harass");
        public static bool UseRHarass => ComboMenu.GetCheckBoxValue(R, "harass");
        #endregion Harass

        #region LastHit
        public static bool UseQLastHit => FarmMenu.GetCheckBoxValue(Q, "lasthit");
        public static bool UseWLastHit => FarmMenu.GetCheckBoxValue(W, "lasthit");
        public static bool UseELastHit => FarmMenu.GetCheckBoxValue(E, "lasthit");
        public static bool UseRLastHit => FarmMenu.GetCheckBoxValue(R, "lasthit");
        #endregion LastHit

        #region LaneClear
        public static bool UseQLaneClear => FarmMenu.GetCheckBoxValue(Q, "laneclear");
        public static bool UseWLaneClear => FarmMenu.GetCheckBoxValue(W, "laneclear");
        public static bool UseELaneClear => FarmMenu.GetCheckBoxValue(E, "laneclear");
        public static bool UseRLaneClear => FarmMenu.GetCheckBoxValue(R, "laneclear");
        #endregion LaneClear

        #region JungleClear
        public static bool UseQJungleClear => FarmMenu.GetCheckBoxValue(Q, "jungleclear");
        public static bool UseWJungleClear => FarmMenu.GetCheckBoxValue(W, "jungleclear");
        public static bool UseEJungleClear => FarmMenu.GetCheckBoxValue(E, "jungleclear");
        public static bool UseRJungleClear => FarmMenu.GetCheckBoxValue(R, "jungleclear");
        #endregion JungleClear

        #region Misc

        public static bool DebugAA => DebugMenu.GetCheckBoxValue("debugAA");
        public static bool DebugDanger => DebugMenu.GetCheckBoxValue("debugDanger");
        public static bool DebugMissiles => DebugMenu.GetCheckBoxValue("debugMissiles");
        //KS
        public static bool UseQKillSteal => MiscMenu.GetCheckBoxValue(Q, "killsteal");
        public static bool UseWKillSteal => MiscMenu.GetCheckBoxValue(W, "killsteal");
        public static bool UseEKillSteal => MiscMenu.GetCheckBoxValue(E, "killsteal");
        public static bool UseRKillSteal => MiscMenu.GetCheckBoxValue(R, "killsteal");
        //GapCloser
        public static bool UseQGapCloser => MiscMenu.GetCheckBoxValue(Q, "gapcloser");
        public static bool UseWGapCloser => MiscMenu.GetCheckBoxValue(W, "gapcloser");
        public static bool UseEGapCloser => MiscMenu.GetCheckBoxValue(E, "gapcloser");
        public static bool UseRGapCloser => MiscMenu.GetCheckBoxValue(R, "gapcloser");
        #endregion Misc

        #region Drawings
        //Draw Booleans
        public static bool DrawReady => DrawingsMenu.GetCheckBoxValue("drawReady");
        public static bool DrawQ => QColorSlider.BoolValue;
        public static bool DrawW => WColorSlider.BoolValue;
        public static bool DrawE => EColorSlider.BoolValue;
        public static bool DrawR => RColorSlider.BoolValue;

        //Draw Color
        public static Color QColor => QColorSlider.CurrentColor;
        public static Color WColor => WColorSlider.CurrentColor;
        public static Color EColor => EColorSlider.CurrentColor;
        public static Color RColor => RColorSlider.CurrentColor;
        #endregion Drawings
    }
}
