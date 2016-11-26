using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using Lib.Bases;

namespace Lib.Databases
{
    public static class DamageDB
    {
        public static DamageType GetDamageType(Champion champ)
        {
            var info = DamageList.FirstOrDefault(d => d.Champ == champ);
            return info?.DamageType ?? DamageType.Mixed;
        }

        public static List<DamageDBBase> DamageList = new List<DamageDBBase>
        {
            new DamageDBBase(Champion.Aatrox, DamageType.Physical),
            new DamageDBBase(Champion.Lux, DamageType.Magical),
            new DamageDBBase(Champion.Yasuo, DamageType.Physical),
        };
    }
}