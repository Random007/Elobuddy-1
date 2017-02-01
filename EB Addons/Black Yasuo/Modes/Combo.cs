using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using static BlackYasuo.Helper;
using static BlackYasuo.SpellManager;
using static BlackYasuo.ModeManager;
using static BlackYasuo.MyMenu;

namespace BlackYasuo.Modes
{
    internal class Combo : ModeBase
    {
        public override bool CanRun()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        { 
            //SpellManager.CastOPCombo(1);
            if (Orbwalker.IsAutoAttacking) return;

            var target = TargetSelector.GetTarget(2000, DamageType.Physical);

            if (target == null) return;

            if (ComboMenu.GetCheckBoxValue(Q, "combo"))
            {
                if (!Me.Dashing())
                {
                    Q.CastMinimumHitchance(target, HasQ3() ? 71 : 51);
                }
                else
                {
                    if (DashManager.GetPlayerPosition().CountEnemyChampionsInRange(QCircleRange) >= 1)
                    {
                        Console.WriteLine("Q Dash COmbo");
                        Q.Cast();
                    }

                    if (!HasQ3() && DashManager.GetPlayerPosition().CountEnemyMinionsInRange(QCircleRange) >= 1)
                    {
                        Console.WriteLine("Q Dash COmbo");
                        Q.Cast();
                    } 
                }
            }

            if (ComboMenu.GetCheckBoxValue(E, "combo"))
            {
                if (!target.IsValidTarget(Me.GetAutoAttackRange() - 20) && E.IsReady())
                {
                    var targetToE = target.GetBestEnemyToE();

                    targetToE?.CastE();
                }

                if (!target.IsInRange(Me, Me.GetAutoAttackRange() + 220) && target.IsValidTarget(E.Range) && E.IsReady())
                {
                    target.CastE();
                }
            }

            #region Ult

            if (Me.CountEnemyChampionsInRange(1000) >= 2)
            {
                //TeamFight
                if (ComboMenu.GetCheckBoxValue(R, "combo"))
                {
                    var targetR = GetBestTargetToR();

                    if (targetR.Hero == null || targetR.EnemyCount < ComboMenu.GetSliderValue("rCount")) return;

                    if (targetR.Time <= 90 + Game.Ping)
                    {
                        R.Cast(targetR.Hero);
                    }
                }
            }
            else
            {
                //1v1
                if (ComboMenu.GetCheckBoxValue("rSmart"))
                {
                    var targetR = GetBestTargetToR();

                    if (targetR.Hero == null) return;

                    if (Prediction.Health.GetPrediction(targetR.Hero, 400) >= Me.GetAutoAttackDamage(targetR.Hero) + targetR.Hero.GetQDamage() + targetR.Hero.GetEDamage() && targetR.Hero.IsInRange(Me,550)) return;

                    if (targetR.Time <= 90 + Game.Ping)
                    {
                        R.Cast(targetR.Hero);
                    }
                }
            }

            #endregion Ult       
        }
    }
}
