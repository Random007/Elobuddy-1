using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using SharpDX;

using static BlackYasuo.SpellManager;

namespace BlackYasuo
{
    public static class DashManager
    {
        private static int startTime;
        private static int endTime;
        private static Vector3 startPosition;
        private static Vector3 endPosition;
        private static int startTick;

        public static void Load()
        {
            Dash.OnDash += Dash_OnDash;
        }

        private static void Dash_OnDash(Obj_AI_Base sender, Dash.DashEventArgs e)
        {
            var hero = sender as AIHeroClient;
            if (hero == null || !hero.IsMe) return;

            startTime = e.StartTick;
            endTime = e.EndTick;
            startPosition = e.StartPos;
            endPosition = e.EndPos;
            startTick = Environment.TickCount;
        }

        public static Vector3 GetPlayerPosition()
        {
            if (Player.Instance.Dashing() && endTime < Environment.TickCount + EDelay)
            {
                return
                    startPosition.Extend(endPosition,
                        475 *
                        ((endTime - (Environment.TickCount + EDelay)) /
                         ((startTime - endTime) == 0 ? 1 : startTime - endTime))).To3D();
            }
            return Player.Instance.Position;
        }

        public static bool Dashing(this AIHeroClient target)
        {
            var endTick = Environment.TickCount - startTick;
            var delay = endTime - startTime;

            return endTick < delay - 60;
        }

        public static Vector3 GetPosAfterE(this Obj_AI_Base target)
        {
            return Player.Instance.Position.Extend(Prediction.Position.PredictUnitPosition(target, 300), 475).To3D();
        }
    }
}