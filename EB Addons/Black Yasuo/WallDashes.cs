using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

using static BlackYasuo.Helper;

namespace BlackYasuo
{
    internal static class WallDashes
    {
        internal static List<DashPosition> DashPositions = new List<DashPosition>
        {
            new DashPosition(new Vector3(5997.00f, 5065.00f, 51.67f), new Vector3(6447.35f, 5216.45f, 56.11f)),
            new DashPosition(new Vector3(3582.00f, 7936.00f, 53.67f), new Vector3(3845.85f, 7376.56f, 51.56f)),
            new DashPosition(new Vector3(3880.00f, 7978.00f, 51.81f), new Vector3(3824.00f, 7356.00f, 51.50f)),
            new DashPosition(new Vector3(3724.00f, 7408.00f, 51.87f), new Vector3(3631.26f, 7824.56f, 53.78f)),
            new DashPosition(new Vector3(3850.00f, 7968.00f, 51.91f), new Vector3(4042.00f, 7376.00f, 51.00f)),
            new DashPosition(new Vector3(3894.00f, 6446.00f, 52.46f), new Vector3(4480.45f, 6432.95f, 50.77f)),
            new DashPosition(new Vector3(3732.00f, 6528.00f, 52.46f), new Vector3(3732.00f, 7154.00f, 50.53f)),
            new DashPosition(new Vector3(4374.00f, 6258.00f, 51.36f), new Vector3(3946.00f, 6462.00f, 52.46f)),
            new DashPosition(new Vector3(3674.00f, 7058.00f, 50.33f), new Vector3(3734.00f, 6588.00f, 52.46f)),
            new DashPosition(new Vector3(3786.00f, 6534.00f, 52.46f), new Vector3(3470.00f, 6888.00f, 51.15f)),
            new DashPosition(new Vector3(3890.00f, 6520.00f, 52.46f), new Vector3(4258.00f, 6218.00f, 51.94f)),
            new DashPosition(new Vector3(2124.00f, 8506.00f, 51.78f), new Vector3(1880.00f, 7930.00f, 51.43f)),
            new DashPosition(new Vector3(2148.00f, 8370.00f, 51.78f), new Vector3(1690.00f, 8688.00f, 52.66f)),
            new DashPosition(new Vector3(1724.00f, 8156.00f, 52.84f), new Vector3(2108.00f, 8436.00f, 51.78f)),
            new DashPosition(new Vector3(8370.00f, 2698.00f, 51.04f), new Vector3(7977.40f, 3171.12f, 51.58f)),
            new DashPosition(new Vector3(8314.00f, 2678.00f, 51.12f), new Vector3(8376.00f, 3300.00f, 52.56f)),
            new DashPosition(new Vector3(8272.00f, 3208.00f, 51.89f), new Vector3(8324.00f, 2736.00f, 51.13f)),
            new DashPosition(new Vector3(7858.00f, 3912.00f, 53.76f), new Vector3(8362.70f, 3652.84f, 54.42f)),
            new DashPosition(new Vector3(7564.00f, 4112.00f, 54.46f), new Vector3(7686.00f, 4726.00f, 49.53f)),
            new DashPosition(new Vector3(7030.00f, 5460.00f, 54.20f), new Vector3(7410.00f, 5954.00f, 52.48f)),
            new DashPosition(new Vector3(6972.00f, 5508.00f, 55.43f), new Vector3(6395.04f, 5313.03f, 48.53f)),
            new DashPosition(new Vector3(6924.00f, 5492.00f, 54.36f), new Vector3(6334.00f, 5292.00f, 48.53f)),
            new DashPosition(new Vector3(7372.00f, 5858.00f, 52.57f), new Vector3(7062.00f, 5500.00f, 55.03f)),
        };

        public static DashPosition GetClosestDash(float dist = 350)
        {
            var closestWall = DashPositions[0];
            for (var i = 1; i < DashPositions.Count; i++)
            {
                closestWall = ClosestDashToMouse(closestWall, DashPositions[i]);
            }
            if (closestWall.To.Distance(Game.CursorPos.To2D()) < dist)
                return closestWall;
            return null;
        }

        private static DashPosition ClosestDashToMouse(DashPosition w1, DashPosition w2)
        {
            return Vector3.DistanceSquared(w1.To, Game.CursorPos) + Vector3.DistanceSquared(w1.From, Me.Position) >
                   Vector3.DistanceSquared(w2.To, Game.CursorPos) + Vector3.DistanceSquared(w2.From, Me.Position)
                ? w2
                : w1;
        }

        public static List<Obj_AI_Base> CanGoThrough(DashPosition dash)
        {
            var jumps = ObjectManager.Get<Obj_AI_Base>().Where(enemy => !enemy.HasEBuff() && enemy.IsValidTarget(550, true, dash.To)).ToList();
            var canBejump = jumps.Where(jump => MyGeo.interCir(dash.From.To2D(), dash.To.To2D(), jump.Position.To2D(), 35)).ToList();
            return canBejump.OrderBy(jum => Me.Distance(jum)).ToList();
        }
    }
}
