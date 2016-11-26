using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;

using static Lib.Utils;

namespace Activator
{
    class TickManager
    {
        #region No Need to see this

        private static int LastTick;

        public static void Load()
        {
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            DefensiveTick();

            if (GameTimeTickCount + 500 >= GameTimeTickCount)
            {
                OffensiveTick();
            }

            if (GameTimeTickCount + 2000 >= GameTimeTickCount)
            {
                ConsumablesTick();
            }

            LastTick = GameTimeTickCount;
        }
        #endregion No Need to see this

        private static void DefensiveTick()
        {
            
        }

        private static void OffensiveTick()
        {
            
        }

        private static void ConsumablesTick()
        {
            var itemToUse =
                Items.ConsumableItems.OrderByDescending(item => item.Priority).FirstOrDefault(item => item.CanCast());

            itemToUse?.Cast();
        }
    }
}
