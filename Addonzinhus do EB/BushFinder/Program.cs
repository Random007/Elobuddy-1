using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using SharpDX;

namespace BushFinder
{
    public class Program
    {
        private static AIHeroClient Me => Player.Instance;

        private static List<Vector3> Walls = new List<Vector3>();

        public static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += Drawing_OnDraw;
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            Game.CursorPos.DrawCircle(50, Color.BlanchedAlmond);
            Drawing.DrawText(Game.CursorPos2D + 80, System.Drawing.Color.Blue, Walls.Count.ToString(), 25);
            /*
            foreach (var bush in Walls)
            {
                bush.DrawCircle(10, Color.Chocolate, 8f);
            }*/
        }

        private static int LastRun;
        private static void Game_OnTick(EventArgs args)
        {
            //if(Environment.TickCount < LastRun + 5000)return;

            var sourceGrid = Game.CursorPos.ToNavMeshCell();
            var gridSize = 50;
            var startPos = new NavMeshCell(sourceGrid.GridX - (short)Math.Floor(gridSize / 2f),
                sourceGrid.GridY - (short)Math.Floor(gridSize / 2f));

            var cells = new List<NavMeshCell> { startPos };

            for (var y = startPos.GridY; y < startPos.GridY + gridSize; y++)
            {
                for (var x = startPos.GridX; x < startPos.GridX + gridSize; x++)
                {
                    if (x == startPos.GridX && y == startPos.GridY)
                    {
                        continue;
                    }
                    if (x == sourceGrid.GridX && y == sourceGrid.GridY)
                    {
                        cells.Add(sourceGrid);
                    }
                    else
                    {
                        cells.Add(new NavMeshCell(x, y));
                    }
                }
            }

            var walls = cells.Where(w => w.CollFlags.HasFlag(CollisionFlags.Wall)).Select(w => w.WorldPosition);

            var goodWalls = walls.Where(w => !Walls.Contains(w));

            Walls.AddRange(goodWalls);

            LastRun = Environment.TickCount;
        }
    }
}
