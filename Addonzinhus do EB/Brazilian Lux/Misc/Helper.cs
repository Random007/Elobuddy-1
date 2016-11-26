using BrazilianLux.Bases;
using EloBuddy;

namespace BrazilianLux.Misc
{
    public static class Helper
    {
        public static AIHeroClient Target { get; set; }
        public static AIHeroClient Me => Player.Instance;

        public static Obj_GeneralParticleEmitter EObj;
        public static QObj QObj;

    }
}
