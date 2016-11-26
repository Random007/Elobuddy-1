using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Nautilus.Modes.BlackYasuo.Modes;

using static Nautilus.SpellManager;
using static Nautilus.Helper;
using static Nautilus.MyMenu;

namespace Nautilus.Modes
{
    public class Flee : ModeBase
    {
        public override bool CanRun()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            if (!Q.IsReady()) return;

            var sourceGrid = Me.Position.ToNavMeshCell();
            var gridSize = 80;
            var startPos = new NavMeshCell(sourceGrid.GridX - (short) Math.Floor(gridSize/2f),
                sourceGrid.GridY - (short) Math.Floor(gridSize/2f));

            var cells = new List<NavMeshCell> {startPos};

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

            var walls = cells.Where(w => w.CollFlags.HasFlag(CollisionFlags.Wall) || w.CollFlags.HasFlag(CollisionFlags.Building));

            var bestWall =
                walls.Where(w => w.WorldPosition.IsInRange(Me, Q.Range)).OrderByDescending(w => w.WorldPosition.Distance(Me)).ThenBy(w => w.WorldPosition.Distance(Game.CursorPos))
                    .FirstOrDefault();
            if (bestWall == null) return;
            Q.Cast(bestWall.WorldPosition);
        }
    }
}
