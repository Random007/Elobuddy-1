using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using static BlackYasuo.Helper;
using static BlackYasuo.SpellManager;
using static BlackYasuo.ModeManager;
using static BlackYasuo.MyMenu;

namespace BlackYasuo.Modes
{
    internal class LastHit : ModeBase
    {
        public override bool CanRun()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit);
        }

        public override void Execute()
        {
            if (Orbwalker.IsAutoAttacking || Me.Dashing()) return;

            var canUseQ = FarmMenu.GetCheckBoxValue(Q, "last");
            var canUseE = FarmMenu.GetCheckBoxValue(E, "last");

            if (canUseQ && Me.CountEnemiesInRange(1200) >= 1 ? HasQ3() : Q.IsReady())
            {
                var minionQ =
                    EntityCache.EnemyMinions.Where(m => m.IsValidTarget(Q.Range)).OrderBy(m => m.Health)
                        .FirstOrDefault(
                            m =>
                                Prediction.Health.GetPrediction(m,
                                    Q.CastDelay + (E.IsReady() ? EDelay : 0) + Game.Ping) <=
                                m.GetQDamage() + (E.IsReady() ? m.GetEDamage() : 0f));

                Q.CastMinimumHitchance(minionQ, 10);
            }

            if (canUseE)
            {
                var minionE =
                    EntityCache.EnemyMinions.Where(m => m.IsValidTarget(E.Range)).OrderBy(m => m.Health)
                        .FirstOrDefault(
                            m =>
                                Prediction.Health.GetPrediction(m, EDelay + Game.Ping) <= m.GetEDamage());
                minionE.CastE();
            }
        }
    }
}
