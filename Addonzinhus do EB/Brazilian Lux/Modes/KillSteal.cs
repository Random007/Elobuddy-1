using System.Linq;
using BrazilianLux.Bases;
using BrazilianLux.Managers;
using BrazilianLux.Misc;
using EloBuddy.SDK;

using static BrazilianLux.Managers.SpellManager;
using static BrazilianLux.Misc.Helper;
using static BrazilianLux.MenuVariables;

namespace BrazilianLux.Modes
{
    public class KillSteal : ModeBase
    {
        public override bool CanRun()
        {
            var anyEnemy = EntityManager.Heroes.Enemies.Any(e => e.IsValidTarget(R.Range + 500));
            return anyEnemy;
        }

        public override void Execute()
        {
            var enemies = EntityManager.Heroes.Enemies;

            if (Q.IsReady() && UseQKillSteal)
            {
                var targetQ =
                    enemies.Where(e => e.IsValidTarget(Q.Range + 200))
                        .OrderBy(e => e.Health)
                        .FirstOrDefault(e => Prediction.Health.GetPrediction(e, Q.TravelTime(e)) <= e.GetQDamage(true));

                if (targetQ != null)
                {
                    Q.CastMinimumHitchance(targetQ, MyMenu.QPredSlider.GetPredictionValue(ModesEnum.Killsteal));
                }
            }

            if (E.IsReady() && UseEKillSteal)
            {
                var targetE =
                    enemies.Where(e => e.IsValidTarget(E.Range + 200))
                        .OrderBy(e => e.Health)
                        .FirstOrDefault(e => Prediction.Health.GetPrediction(e, E.TravelTime(e)) <= e.GetEDamage(true));

                if (targetE != null)
                {
                    E.CastMinimumHitchance(targetE, MyMenu.EPredSlider.GetPredictionValue(ModesEnum.Killsteal));
                }
            }

            if (R.IsReady() && UseRKillSteal)
            {
                var targetR =
                    enemies.Where(e => e.IsValidTarget(R.Range + 200) && !e.IsInRange(Me, E.Range))
                        .OrderBy(e => e.Health)
                        .FirstOrDefault(
                            e => Prediction.Health.GetPrediction(e, R.TravelTime(e)) <= e.GetRDamage(true) & e.CountAlliesInRange(1000) <= 1);

                if (targetR != null)
                {
                    R.CastMinimumHitchance(targetR, MyMenu.RPredSlider.GetPredictionValue(ModesEnum.Killsteal));
                }
            }

        }
    }
}
