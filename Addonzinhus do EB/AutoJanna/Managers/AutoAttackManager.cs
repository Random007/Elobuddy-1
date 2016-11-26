using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoJanna.Bases;
using EloBuddy;
using EloBuddy.SDK;

using static AutoJanna.MenuVariables;

namespace AutoJanna.Managers
{
    public static class AutoAttackManager
    {
        private static List<MyAutoAttack> AutoAttacks;

        public static void LoadAutoAttackManager()
        {
            Obj_AI_Base.OnBasicAttack += Obj_AI_Base_OnBasicAttack;
            AutoAttacks = new List<MyAutoAttack>();
        }

        public static bool IsBeingAutoAttacked(this Obj_AI_Base target)
        {
            return AutoAttacks.Any(a => a.Target.Name == target.Name && a.Sender.IsEnemy);
        }

        public static bool IsAttacking(this Obj_AI_Base target)
        {
            return AutoAttacks.Any(a => a.Target.IsEnemy && a.Sender.Name == target.Name);
        }

        private static void Obj_AI_Base_OnBasicAttack(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var hero = args.Target as AIHeroClient;
            var ssender = sender as AIHeroClient;

            if (hero == null || ssender == null) return;

            var autoAttack = new MyAutoAttack(hero, ssender);
            AutoAttacks.Add(autoAttack);
            Core.DelayAction(() => AutoAttacks.Remove(autoAttack), (int) sender.AttackDelay);

            if (DebugAA)
            {
                Console.WriteLine(AutoAttacks.Count);
                Console.WriteLine(hero.BaseSkinName + " is being auto attacked by " + ssender.BaseSkinName);
            }
        }
    }
}
