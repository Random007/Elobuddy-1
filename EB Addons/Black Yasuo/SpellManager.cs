using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using static BlackYasuo.Helper;

namespace BlackYasuo
{
    public static class SpellManager
    {
        public static Spell.Skillshot Q;
        public static Spell.Targeted W;
        public static Spell.Targeted E;
        public static Spell.Targeted R;

        public static int QCircleRange => 365;
        public static int EDelay => 150;

        public static void Load()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 475, SkillShotType.Linear, 250, int.MaxValue, 55);
            W = new Spell.Targeted(SpellSlot.W, 400);
            E = new Spell.Targeted(SpellSlot.E, 475);
            R = new Spell.Targeted(SpellSlot.R, 1200);

            Obj_AI_Base.OnBuffGain += Obj_AI_Base_OnBuffGain;
            Obj_AI_Base.OnBuffLose += Obj_AI_Base_OnBuffLose;
        }

        private static void Obj_AI_Base_OnBuffGain(Obj_AI_Base sender, Obj_AI_BaseBuffGainEventArgs args)
        {
            if (!sender.IsMe) return;

            if (args.Buff.Name.ToLower().Contains("yasuoeqcombosoundmiss") ||
                args.Buff.Name.ToLower().Contains("yasuoeqcombosoundhit"))
            {
                Core.DelayAction(
                    () =>
                        Player.IssueOrder(
                            GameObjectOrder.AttackTo,
                            Me.ServerPosition.Extend(Game.CursorPos, Me.BoundingRadius).To3D()), 40 + Game.Ping);
            }

            if(!args.Buff.Name.ToLower().Contains("yasuoq3w"))return;

            Q = new Spell.Skillshot(SpellSlot.Q, 1100, SkillShotType.Linear, 250, 1200, 90);

        }

        private static void Obj_AI_Base_OnBuffLose(Obj_AI_Base sender, Obj_AI_BaseBuffLoseEventArgs args)
        {
            if (!sender.IsMe || !args.Buff.Name.ToLower().Contains("yasuoq3w")) return;

            Q = new Spell.Skillshot(SpellSlot.Q, 475, SkillShotType.Linear, 250, int.MaxValue, 55);
        }

        /*
        private static float GetQDelay => 1 - Math.Min((Me.AttackSpeedMod - 1) * 0.0058552631578947f, 0.6675f);

        private static int GetQ1Delay => (int)(0.4f * GetQDelay * 1000);

        private static int GetQ2Delay => (int)(0.5f * GetQDelay * 1000);
        */

        public static void CastE(this Obj_AI_Base target)
        {
            if (!E.IsReady() || target == null || target.HasEBuff()) return;

            //Wont dive
            if (target.IsSafeToE())
            {
                E.Cast(target);
                return;
            }

            //Can Dive
            if (Me.CountEnemiesInRange(2000) <= 1 && Me.Position.IsTowerNear())
            {
                var TSTarget = TargetSelector.GetTarget(2000, DamageType.Physical);

                if(TSTarget == null)return;

                if (TSTarget.HealthPercent <= 40 && TSTarget.HealthPercent < Me.HealthPercent + (HasShield() ? 5 :0) && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                {
                    E.Cast(target);
                }
            }
        }

        public static void CastOPCombo(int minTargets = 2)
        {
            var flash = EloBuddy.SDK.Spells.SummonerSpells.Flash;

            if (flash != null && flash.IsReady() && R.IsReady() && HasQ3() && Me.Dashing())
            {
                Console.WriteLine("Trying");
                var targets = EntityCache.AllEnemies.Where(e => e.IsValidTarget(1000)).ToArray();

                var range = flash.Range + (QCircleRange/2);
                var width = QCircleRange;
                var delay = EDelay + Q.CastDelay/2 + Game.Ping;

                var predLocationCircular =
                    Prediction.Position.PredictCircularMissileAoe(targets, range, width, delay,
                        int.MaxValue)
                        .OrderByDescending(r => r.GetCollisionObjects<AIHeroClient>().Length)
                        .FirstOrDefault();

                if (predLocationCircular != null && predLocationCircular.HitChancePercent >= 75)
                {
                    var predictedMinion = predLocationCircular.GetCollisionObjects<AIHeroClient>();
                    if (predictedMinion.Length >= minTargets)
                    {
                        try
                        {
                            Console.WriteLine("Casting");
                            Q.Cast();
                            flash.Cast(predLocationCircular.CastPosition);
                        }
                        catch (Exception)
                        {
                            //ignored
                        }
                    }
                }
            }
        }
    }
}
