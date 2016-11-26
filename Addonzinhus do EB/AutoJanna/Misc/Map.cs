using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

using static AutoJanna.Misc.Helper;

namespace AutoJanna.Misc
{
    public static class Map
    {
        public static Geometry.Polygon BotLane { get; private set; }

        public static List<GrassObject> Bushes { get; private set; }

        public static void LoadMap()
        {
            Bushes = new List<GrassObject>();
            Bushes.AddRange(ObjectManager.Get<GrassObject>());

            BotLane = new Geometry.Polygon();
            BotLane.Add(new Vector3(4870,1795,80));
            BotLane.Add(new Vector3(11440,1960,49));
            BotLane.Add(new Vector3(12095,3030,35));
            BotLane.Add(new Vector3(13000,4075,51));
            BotLane.Add(new Vector3(12855,10100,93));
            BotLane.Add(new Vector3(14185,10050,107));
            BotLane.Add(new Vector3(14265, 4590, 54));
            BotLane.Add(new Vector3(13970,3315,51));
            BotLane.Add(new Vector3(13100,1890,52));
            BotLane.Add(new Vector3(12140, 1156, 51));
            BotLane.Add(new Vector3(11430,900,50));
            BotLane.Add(new Vector3(4920,670,73));
        }
    }
}
