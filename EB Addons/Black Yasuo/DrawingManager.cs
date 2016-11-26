using System;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;
using Lib;
using SharpDX.Direct3D9;
using static BlackYasuo.Helper;
using static BlackYasuo.SpellManager;
using static BlackYasuo.MyMenu;

namespace BlackYasuo
{
    internal class DrawingManager
    {
        internal static void Load()
        {
            DamageIndicator.Load();
            Drawing.OnDraw += Drawing_OnDraw;
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            if (Me.IsDead) return;

            var flash = EloBuddy.SDK.Spells.SummonerSpells.Flash;

            if (flash != null && flash.IsReady() && R.IsReady() && HasQ3())
            {
                Console.WriteLine("Trying");
                var targets = EntityCache.EnemyHeroes.Where(e => e.IsValidTarget(1000)).ToArray();

                var range = flash.Range + (QCircleRange / 2);
                var width = QCircleRange;
                var delay = EDelay + Q.CastDelay / 2 + Game.Ping;

                var predLocationCircular =
                    Prediction.Position.PredictCircularMissileAoe(targets, range, width, delay,
                        int.MaxValue)
                        .OrderByDescending(r => r.GetCollisionObjects<AIHeroClient>().Length)
                        .FirstOrDefault();

                if (predLocationCircular != null && predLocationCircular.HitChancePercent >= 75)
                {
                    predLocationCircular.CastPosition.DrawCircle(width, SharpDX.Color.Aqua, 5f);
                    var predictedMinion = predLocationCircular.GetCollisionObjects<AIHeroClient>();
                    if (predictedMinion.Length >= 1)
                    {
                        try
                        {
                            Console.WriteLine("Casting");
                            if (Me.Dashing())
                            {
                                //Q.Cast();
                                //flash.Cast(predLocationCircular.CastPosition);
                            }
                        }
                        catch (Exception)
                        {
                            //ignored
                        }
                    }
                }
            }

            if (DrawMenu.GetCheckBoxValue("drawReady"))
            {
                if (QColor.BoolValue && Q.IsReady())
                {
                    Q.DrawSpell(QColor.GetColor());

                    
                    var targets = EntityCache.EnemyHeroes.Where(m => Q.CanCast(m));
                    if (targets != null || targets.Any())
                    {
                        /*
                        var predPos = Q.GetBestLinearCastPosition(targets);
                        if (predPos.CastPosition != null)
                        {
                            var polygon = new Geometry.Polygon.Rectangle(Me.Position, Me.Position.Extend(predPos.CastPosition, Q.Range).To3D(), Q.Width);

                            if (polygon != null)
                            {
                                polygon.Draw(QColor.CurrentColor, 6);
                            }
                        }
                        */
                    }
                    
                }

                if (WColor.BoolValue && W.IsReady())
                {
                    W.DrawSpell(WColor.GetColor());
                }

                if (EColor.BoolValue && E.IsReady())
                {
                    E.DrawSpell(EColor.GetColor());
                }

                if (RColor.BoolValue && R.IsReady())
                {
                    R.DrawSpell(RColor.GetColor());
                }
            }
            else
            {
                if (QColor.BoolValue)
                {
                    Q.DrawSpell(Q.IsReady() ? QColor.GetColor() : Color.Red);
                }

                if (WColor.BoolValue)
                {
                    W.DrawSpell(W.IsReady() ? WColor.GetColor() : Color.Red);
                }

                if (EColor.BoolValue)
                {
                    E.DrawSpell(E.IsReady() ? EColor.GetColor() : Color.Red);
                }

                if (RColor.BoolValue)
                {
                    R.DrawSpell(R.IsReady() ? RColor.GetColor() : Color.Red);
                }
            }
        }
    }
}
