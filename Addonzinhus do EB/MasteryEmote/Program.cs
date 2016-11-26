using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace MasteryEmote
{
    class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            Chat.Print("Spam Mastery after kill enemy");


            Obj_AI_Base.OnPlayAnimation += Obj_AI_Base_OnPlayAnimation;
        }

        private static void Obj_AI_Base_OnPlayAnimation(Obj_AI_Base sender, GameObjectPlayAnimationEventArgs args)
        {
            var hero = sender as AIHeroClient;
            if(hero == null)return;
            if (args.Animation.ToLower().Contains("death") && hero.IsEnemy && hero.IsInRange(Player.Instance, 1000))
            {
                Chat.Say("/masterybadge");
            }
        }
    }
}
