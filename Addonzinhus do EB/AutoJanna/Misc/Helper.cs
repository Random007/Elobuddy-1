using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;

namespace AutoJanna.Misc
{
    public static class Helper
    {
        public static AIHeroClient Target { get; set; }
        public static AIHeroClient Me => Player.Instance;
        public static AIHeroClient MyADC;

        public static bool IsChargingQ => Me.HasBuff("howlinggale");
        public static bool IsChannelingUlt => Me.HasBuff("reapthewhirlwind") && Me.Spellbook.IsChanneling;
    }
}
