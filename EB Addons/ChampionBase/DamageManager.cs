using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;

using static ChampionTemplate.SpellManager;

namespace ChampionTemplate
{
    internal static class DamageManager
    {
        internal static float GetQDamage(this Obj_AI_Base target)
        {
            if (!Q.IsReady()) return 0f;

            return 10f;
        }

        internal static float GetWDamage(this Obj_AI_Base target)
        {
            if (!W.IsReady()) return 0f;

            return 20f;
        }

        internal static float GetEDamage(this Obj_AI_Base target)
        {
            if (!E.IsReady()) return 0f;

            return 30f;
        }

        internal static float GetRDamage(this Obj_AI_Base target)
        {
            if (!R.IsReady()) return 0f;

            return 40f;
        }

        internal static float GetTotalDamage(this Obj_AI_Base target)
        {
            return target.GetQDamage() + target.GetWDamage() + target.GetEDamage() + target.GetRDamage();
        }
    }
}
