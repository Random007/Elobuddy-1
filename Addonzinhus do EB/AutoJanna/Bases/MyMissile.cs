using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Spells;

namespace AutoJanna.Bases
{
    public class MyMissile
    {
        public MissileClient Missile;
        public SpellInfo SpellInfo;
        public Geometry.Polygon Polygon;

        public MyMissile(MissileClient missile, SpellInfo info)
        {
            Missile = missile;
            SpellInfo = info;
        }
    }
}
