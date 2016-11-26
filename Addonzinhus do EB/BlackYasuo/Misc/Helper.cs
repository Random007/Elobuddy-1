using EloBuddy;

namespace Template.Misc
{
    public static class Helper
    {
        public static AIHeroClient Target { get; set; }
        public static AIHeroClient Me => Player.Instance;


    }
}
