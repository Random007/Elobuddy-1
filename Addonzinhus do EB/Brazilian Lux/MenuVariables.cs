using System.Drawing;
using BrazilianLux.Managers;
using BrazilianLux.Misc;

using static BrazilianLux.MyMenu;
using static BrazilianLux.Managers.SpellManager;

namespace BrazilianLux
{
    public static class MenuVariables
    {
        #region Combo
        public static bool UseQCombo => ComboMenu.GetCheckBoxValue(Q, "combo");
        public static bool UseECombo => ComboMenu.GetCheckBoxValue(E, "combo");
        public static bool UseRCombo => ComboMenu.GetCheckBoxValue(R, "combo");
        #endregion Combo

        #region Harass
        public static bool UseQHarass => ComboMenu.GetCheckBoxValue(Q, "harass");
        public static bool UseEHarass => ComboMenu.GetCheckBoxValue(E, "harass");
        #endregion Harass

        #region LastHit
        public static bool UseQLastHit => FarmMenu.GetCheckBoxValue(Q, "lasthit");
        public static bool UseELastHit => FarmMenu.GetCheckBoxValue(E, "lasthit");
        public static int CountELastHit => FarmMenu.GetSliderValue("elasthit");
        public static int ManaLastHit => FarmMenu.GetSliderValue("lasthit");
        #endregion LastHit

        #region LaneClear
        public static bool UseQLaneClear => FarmMenu.GetCheckBoxValue(Q, "laneclear");
        public static bool UseELaneClear => FarmMenu.GetCheckBoxValue(E, "laneclear");
        public static int CountELaneClear => FarmMenu.GetSliderValue("elaneclear");
        public static int ManaLaneClear => FarmMenu.GetSliderValue("laneclear");
        #endregion LaneClear

        #region JungleClear
        public static bool UseQJungleClear => FarmMenu.GetCheckBoxValue(Q, "jungleclear");
        public static bool UseWJungleClear => FarmMenu.GetCheckBoxValue(W, "jungleclear");
        public static bool UseEJungleClear => FarmMenu.GetCheckBoxValue(E, "jungleclear");
        public static int ManaJungleClear => FarmMenu.GetSliderValue("jungleclear");
        #endregion JungleClear

        #region Misc
        //KS
        public static bool UseQKillSteal => MiscMenu.GetCheckBoxValue(Q, "killsteal");
        public static bool UseEKillSteal => MiscMenu.GetCheckBoxValue(E, "killsteal");
        public static bool UseRKillSteal => MiscMenu.GetCheckBoxValue(R, "killsteal");
        public static int KillstealMana => MiscMenu.GetSliderValue("killsteal");

        //W Defender
        public static bool WDefendMe => MiscMenu.GetCheckBoxValue("wdefendme");
        public static int WDefendMeLife => MiscMenu.GetSliderValue("wdefendlife");
        public static int WDefendMeMana => MiscMenu.GetSliderValue("defend");

        //GapCloser
        public static bool UseQGapCloser => MiscMenu.GetCheckBoxValue(Q, "gapcloser");
        public static bool UseWGapCloser => MiscMenu.GetCheckBoxValue(W, "gapcloser");
        public static int GapcloserMana => MiscMenu.GetSliderValue("gapcloser");

        //Interrupter
        public static bool UseQInterrupter => MiscMenu.GetCheckBoxValue(W, "interrupter");
        public static int InterrupterMana => MiscMenu.GetSliderValue("interrupter");

        public static bool UseQFlee => MiscMenu.GetCheckBoxValue(Q, "flee");
        public static int FleeMana => MiscMenu.GetSliderValue("flee");
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
