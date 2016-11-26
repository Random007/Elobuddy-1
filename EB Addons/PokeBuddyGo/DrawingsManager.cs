using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;

namespace PokeBuddyGo
{
    internal class DrawingsManager
    {
        public static void Load()
        {
            //Drawing.OnEndScene += Drawing_OnEndScene;
        }

        private static void Drawing_OnEndScene(EventArgs args)
        {
            Loader.Teste.Draw(Game.CursorPos2D);
        }
    }
}
