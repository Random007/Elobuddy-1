using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace AutoJanna.Misc
{
    public static class PreventUltCancel
    {
        public static void LoadPreventUltCancel()
        {
            Player.OnIssueOrder += Player_OnIssueOrder;
        }

        private static void Player_OnIssueOrder(Obj_AI_Base sender, PlayerIssueOrderEventArgs args)
        {

        }
    }
}
