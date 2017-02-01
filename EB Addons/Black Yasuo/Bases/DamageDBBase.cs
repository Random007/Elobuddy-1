using EloBuddy;

namespace BlackYasuo.Bases
{
    public class DamageDBBase
    {
        public Champion Champ;

        public DamageType DamageType;

        public DamageDBBase(Champion champ, DamageType dmgType)
        {
            Champ = champ;
            DamageType = dmgType;
        }
    }
}
