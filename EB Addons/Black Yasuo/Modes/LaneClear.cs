using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Lib;

using static BlackYasuo.Helper;
using static BlackYasuo.SpellManager;
using static BlackYasuo.MyMenu;

namespace BlackYasuo.Modes
{
    internal class LaneClear : ModeBase
    {
        public override bool CanRun()
        {
            var anyMinion =
                EntityCache.EnemyMinions.Where(m => m.IsValidTarget(Me.GetHighestSpellRange() + 500)).OrderByDescending(m => m.Health).FirstOrDefault();

            return anyMinion != null && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            if (Orbwalker.IsAutoAttacking) return;

            var canUseQ = FarmMenu.GetCheckBoxValue(Q, "lane");
            var canUseE = FarmMenu.GetCheckBoxValue(E, "lane");

            //Normal Laneclear(safer)
            if (Me.CountEnemiesInRange(1200) >= 1)
            {
                if (!Me.Dashing() && !HasQ3())
                {
                    if (canUseQ)
                    {
                        var minionQ =
                            EntityCache.EnemyMinions.Where(m => m.IsValidTarget(Q.Range)).OrderBy(m => m.Health)
                                .FirstOrDefault(
                                    m =>
                                        Prediction.Health.GetPrediction(m,
                                            Q.CastDelay + (E.IsReady() ? EDelay : 0) + Game.Ping) <=
                                        m.GetQDamage() + (E.IsReady() ? m.GetEDamage() : 0f));

                        if (!HasQ3()) Q.SmartCast(minionQ);
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
            //Faster Laneclear(faster, not safe)
            else
            {
                if (!Me.Dashing())
                {
                    if (canUseQ)
                    {
                        var minionQ =
                            EntityCache.EnemyMinions.Where(m => m.IsValidTarget(Q.Range)).OrderBy(m => m.Health)
                                .FirstOrDefault(
                                    m =>
                                        Prediction.Health.GetPrediction(m,
                                            Q.CastDelay + (E.IsReady() ? EDelay : 0) + Game.Ping) <=
                                        m.GetQDamage() + (E.IsReady() && m.IsSafeToE() ? m.GetEDamage() : 0f));

                        Q.SmartCast(minionQ);
                    }
                    if (canUseE)
                    {
                        var minionE =
                            EntityCache.EnemyMinions.Where(m => m.IsValidTarget(E.Range)).OrderByDescending(
                                m => m.GetPosAfterE().CountEnemyMinionsInRange(QCircleRange)).ThenBy(m => m.Health)
                                .FirstOrDefault(
                                    m =>
                                        Prediction.Health.GetPrediction(m, EDelay + Game.Ping) <= m.GetEDamage());
                        minionE.CastE();
                    }
                }

                if (Me.CountAllyMinionsInRange(700) >= 5)
                {

                    if (canUseE)
                    {
                        //Fast
                        var minionEKinda =
                            EntityCache.EnemyMinions.Where(m => m.IsValidTarget(E.Range)).OrderByDescending(
                                m => m.GetPosAfterE().CountEnemyMinionsInRange(QCircleRange)).ThenBy(m => m.Health)
                                .FirstOrDefault(
                                    m =>
                                        m.GetPosAfterE().CountEnemyMinionsInRange(QCircleRange) >= 1 &&
                                        Prediction.Health.GetPrediction(m, +EDelay + Game.Ping) <= m.GetEDamage());

                        minionEKinda.CastE();
                    }
                    if (canUseQ)
                    {
                        //Fast
                        var minionQFast =
                            EntityCache.EnemyMinions.Where(m => m.IsValidTarget(Me.Dashing() ? QCircleRange : (int)Q.Range)).OrderBy(m => m.Health)
                                .FirstOrDefault(
                                    m =>
                                        DashManager.GetPlayerPosition().CountEnemyMinionsInRange(QCircleRange) >= 1);
                        Q.SmartCast(minionQFast);
                    }
                }

                if (Me.CountAllyMinionsInRange(700) <= 1)
                {
                    if (canUseE)
                    {
                        //Fast
                        var minionEFast =
                            EntityCache.EnemyMinions.Where(m => m.IsValidTarget(E.Range)).OrderByDescending(
                                m => m.GetPosAfterE().CountEnemyMinionsInRange(QCircleRange)).ThenBy(m => m.Health)
                                .FirstOrDefault(
                                    m =>
                                        m.GetPosAfterE().CountEnemyMinionsInRange(QCircleRange) >= 1);

                        minionEFast.CastE();
                    }
                    if (canUseQ)
                    {
                        var minionQFast =
                            EntityCache.EnemyMinions.Where(m => m.IsValidTarget(Me.Dashing() ? QCircleRange : (int)Q.Range)).OrderBy(m => m.Health)
                                .FirstOrDefault(
                                    m =>
                                        DashManager.GetPlayerPosition().CountEnemyMinionsInRange(QCircleRange) >= 1);
                        Q.SmartCast(minionQFast);
                        //Fast
                    }
                }
            }
        }
    }
}
