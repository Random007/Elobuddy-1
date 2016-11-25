using EloBuddy;

namespace Mario_s_Activator.ItemsTick
{
    internal class TickManager
    {
        public static void Initialize()
        {
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(System.EventArgs args)
        {
            Offensive.OnTick();
        }
    }
}
