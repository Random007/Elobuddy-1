using System;
using EloBuddy;

namespace Nautilus
{
    public static class Utils
    {
        public static int GameTimeTickCount => (int)(Game.Time * 1000);

        public static int TickCount => Environment.TickCount & int.MaxValue;

        private static readonly Random _random = new Random(TickCount);
        public static int GetRandomNumber(int min = 0, int max = 10)
        {
            return _random.Next(min, max);
        }
    }
}
