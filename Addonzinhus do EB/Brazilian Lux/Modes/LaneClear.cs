using System.Collections.Generic;
using System.Linq;
using BrazilianLux.Managers;
using BrazilianLux.Misc;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using static BrazilianLux.Misc.Helper;
using static BrazilianLux.Managers.SpellManager;
using static BrazilianLux.MenuVariables;

namespace BrazilianLux.Modes
{
    public class LaneClear : ModeBase
    {
        public override bool CanRun()
        {
            var anyMinion = EntityManager.MinionsAndMonsters.GetLaneMinions().Any(m => m.IsEnemy && m.IsValidTarget(2000));
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear) && anyMinion;
        }

        public override void Execute()
        {
            if (Orbwalker.IsAutoAttacking || ManaLaneClear > Me.ManaPercent) return;

            if (UseQLaneClear)
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
                    Q.CastMinimumHitchance(minionsQ, 30);
                }
            }

            if (UseELaneClear)
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
                                Prediction.Health.GetPrediction(m, E.TravelTime(m)) > 10)
                        .ToArray();

                if (minionsE.Length >= CountELaneClear)
                {
                    var predE = E.GetBestCircularCastPosition(minionsE, 10);

                    if (predE.HitNumber >= CountELaneClear)
                    {
                        E.Cast(predE.CastPosition);
                    }
                }
            }
        }
    }
}
