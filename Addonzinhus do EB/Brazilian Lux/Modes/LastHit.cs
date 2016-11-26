using System.Linq;
using BrazilianLux.Managers;
using BrazilianLux.Misc;
using EloBuddy;
using EloBuddy.SDK;

using static BrazilianLux.Misc.Helper;
using static BrazilianLux.Managers.SpellManager;
using static BrazilianLux.MenuVariables;

namespace BrazilianLux.Modes
{
    public class LastHit : ModeBase
    {
        public override bool CanRun()
        {
            var anyMinion = EntityManager.MinionsAndMonsters.GetLaneMinions().Any(m => m.IsEnemy && m.IsValidTarget(2000));
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit) && anyMinion;
        }

        public override void Execute()
        {
            if (Orbwalker.IsAutoAttacking || ManaLastHit > Me.ManaPercent) return;

            if (UseQLastHit)
            {
                var minionsQ =
                    EntityManager.MinionsAndMonsters
                        .GetLaneMinions()
                        .OrderBy(
                            m =>
                                    m.Health)
                        .FirstOrDefault(m => m.IsValidTarget(Q.Range) &&
                                             Prediction.Health.GetPrediction(m, Q.TravelTime(m)) > Player.Instance.GetAutoAttackDamage(m) &&
                                             Prediction.Health.GetPrediction(m, Q.TravelTime(m)) < m.GetQDamage());

                if (minionsQ != null)
                {
                    Q.CastMinimumHitchance(minionsQ, 20);
                }
            }


            if (UseELastHit)
            {
                if (EObj != null && E.ToggleState >= 2 && EObj.CountEnemyMinionsInRangeWithPrediction(375, 50) >= 1)
                {
                    Player.CastSpell(SpellSlot.E);
                }

                var minionsE =
                    EntityManager.MinionsAndMonsters.GetLaneMinions()
                        .OrderBy(m => m.Health)
                        .Where(
                            m =>
                                m.IsValidTarget(E.Range + E.Width) &&
                                Prediction.Health.GetPrediction(m, E.TravelTime(m)) > Player.Instance.GetAutoAttackDamage(m) &&
                                Prediction.Health.GetPrediction(m, E.TravelTime(m)) < m.GetEDamage())
                        .ToArray();

                if (minionsE.Length >= CountELastHit)
                {
                    var predE = E.GetBestCircularCastPosition(minionsE);

                    if (predE.HitNumber >= CountELastHit)
                    {
                        E.Cast(predE.CastPosition);
                    }
                }
            }
        }
    }
}
