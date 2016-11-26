using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;

using static BrazilianLux.Misc.Helper;
using static BrazilianLux.Managers.SpellManager;
using static BrazilianLux.MenuVariables;

namespace BrazilianLux.Managers
{
    public static class AutoAttackManager
    {
        public static void LoadAutoAttackManager()
        {
            Obj_AI_Base.OnBasicAttack += Obj_AI_Base_OnBasicAttack;
        }

        private static void Obj_AI_Base_OnBasicAttack(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var hero = sender as AIHeroClient;
            if(hero == null || hero.IsAlly)return;

            if (args.Target.IsMe && !Me.IsDead)
            {
                if (WDefendMe && Me.HealthPercent < WDefendMeLife && Me.ManaPercent >= WDefendMeMana)
                {
                    Chat.Print("Hu3");
                    Player.CastSpell(SpellSlot.W);
                }
            }
        }
    }
}
