using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using static Nautilus.MyMenu;

namespace Nautilus
{
    class Mastery
    {
        public static void LoadMastery()
        {
            Obj_AI_Base.OnPlayAnimation += Obj_AI_Base_OnPlayAnimation;
        }

        private static void Obj_AI_Base_OnPlayAnimation(Obj_AI_Base sender, GameObjectPlayAnimationEventArgs args)
        {
            if (!MiscMenu.GetCheckBoxValue("Mastery")) return;

            var hero = sender as AIHeroClient;
            if (hero == null) return;
            if (args.Animation.ToLower().Contains("death") && hero.IsEnemy && hero.IsInRange(Player.Instance, 1000))
            {
                Chat.Say("/masterybadge");
            }
        }
    }
}
