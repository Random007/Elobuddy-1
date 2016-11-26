using BrazilianLux.Bases;
using BrazilianLux.Managers;
using BrazilianLux.Misc;
using EloBuddy;
using EloBuddy.SDK;

using static BrazilianLux.Managers.SpellManager;
using static BrazilianLux.Misc.Helper;
using static BrazilianLux.MenuVariables;

namespace BrazilianLux.Modes
{
    public class Combo : ModeBase
    {
        public override bool CanRun()
        {
            Target = TargetSelector.GetTarget(E.Range + E.Width, DamageType.Magical);
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo) && Target != null;
        }

        public override void Execute()
        {
            if (Helper.QObj != null && (Helper.QObj.WillHit(Target, 375) || Target.IsStunned || Target.IsRooted) && UseECombo &&
                UseRCombo && E.IsReady() && R.IsReady() &&
                Prediction.Health.GetPrediction(Target, 350) <= Target.GetTotalDamage(true) &&
                Prediction.Health.GetPrediction(Target, 400) >= Target.GetPassiveDamage(true) + Target.GetEDamage())
            {
                E.Cast(Target.Position);
                R.Cast(Target.Position);
            }

            if (Helper.QObj != null && (Helper.QObj.WillHit(Target, 275) || Target.IsStunned || Target.IsRooted) && UseRCombo &&
                R.IsReady() &&
                Prediction.Health.GetPrediction(Target, 350) <= Target.GetTotalDamage(true) &&
                Prediction.Health.GetPrediction(Target, 400) >= Target.GetPassiveDamage(true) + Target.GetEDamage())
            {
                R.Cast(Target.Position);
            }

            var targetR = TargetSelector.GetTarget(R.Range + R.Width, DamageType.Magical);
            if (targetR != null && targetR.IsValidTarget() && R.IsReady() && UseRCombo &&
                Prediction.Health.GetPrediction(targetR, R.TravelTime(targetR)) <= targetR.GetRDamage(true) &
                targetR.CountAlliesInRange(1000) <= 1 &&
                Prediction.Health.GetPrediction(targetR, R.TravelTime(targetR)) >=
                targetR.GetPassiveDamage(true) + targetR.GetEDamage() + targetR.GetQDamage())
            {
                R.CastMinimumHitchance(targetR, MyMenu.RPredSlider.GetPredictionValue(ModesEnum.Combo));
            }

            if (Orbwalker.IsAutoAttacking) return;

            if (UseQCombo)
            {
                Q.SmartCast(MyMenu.QPredSlider.GetPredictionValue(ModesEnum.Combo));
            }
            if (UseECombo)
            {
                E.SmartCast(MyMenu.EPredSlider.GetPredictionValue(ModesEnum.Combo));
            }
        }
    }
}
