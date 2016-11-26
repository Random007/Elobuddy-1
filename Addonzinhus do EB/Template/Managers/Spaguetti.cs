using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;

namespace Template.Managers
{
    public static class Spaguetti
    {
        private static int AttackCount;

        private static readonly Stopwatch Stahp = new Stopwatch();

        public static void Load()
        {
            Orbwalker.OnPreAttack += Orbwalker_OnPreAttack;
            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack;

            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            Console.WriteLine(Stahp.Elapsed.TotalSeconds);
            if(!Stahp.IsRunning)return;

            if (Stahp.Elapsed.TotalSeconds >= 10)
            {
                Chat.Print("Time Out");
                AttackCount = 0;
                Stahp.Reset();
                Stahp.Stop();
            }
        }

        private static void Orbwalker_OnPreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            if (AttackCount >= 3)
            {
                AttackCount = 0;
                Chat.Print("Much wow next attack will do tons of damage");
            }
        }

        private static void Orbwalker_OnPostAttack(AttackableUnit target, EventArgs args)
        {
            Chat.Print(AttackCount);
            AttackCount++;
            Stahp.Reset();
            if (!Stahp.IsRunning)
            {
                Stahp.Reset();
                Stahp.Start();
            }
        }
    }
}
