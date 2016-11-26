using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;

using static BrazilianLux.Managers.SpellManager;
using static BrazilianLux.Misc.Helper;

namespace BrazilianLux.Bases
{
    public class QObj
    {
        public Geometry.Polygon Poly;
        public MissileClient Miss;

        public QObj(MissileClient miss)
        {
            Miss = miss;
            Poly = new Geometry.Polygon.Rectangle(miss.StartPosition, miss.EndPosition, Q.Width);
        }

        public bool WillHit(AIHeroClient target, int range = 200)
        {
            return target.IsInRange(Miss.Position, target.BoundingRadius + range) && Poly.IsInside(target);
        }
    }
}
