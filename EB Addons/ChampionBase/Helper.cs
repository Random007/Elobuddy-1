using EloBuddy;
using Lib;
using Lib.Databases;

namespace ChampionTemplate
{
    public static class Helper
    {

        public static Cache EntityCache;

        public static AIHeroClient Me => Player.Instance;

        public static void Load()
        {
            EntityCache = new Cache();
        }
    }
}
