using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using static AutoJanna.Misc.Helper;

namespace AutoJanna.Managers
{
    public static class UltManager
    {
        public static void LoadUltManager()
        {
            Player.OnIssueOrder += Player_OnIssueOrder;
        }

        private static void Player_OnIssueOrder(Obj_AI_Base sender, PlayerIssueOrderEventArgs args)
        {
            if (!IsChannelingUlt) return;

            var anyEnemyHero =
                EntityManager.Heroes.Enemies.Any(h => h.IsInRange(Me, h.AttackRange + (h.IsMelee ? 200 : 0)));

            if (anyEnemyHero)
            {
                return;
            }

            args.Process = false;
        }
    }
}
