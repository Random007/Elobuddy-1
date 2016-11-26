using AutoJanna.Misc;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;
using SharpDX;
using static AutoJanna.Misc.Helper;
using static AutoJanna.MenuVariables;
using static AutoJanna.Managers.SpellManager;
using Color = System.Drawing.Color;

namespace AutoJanna.Managers
{
    public static class DrawingManager
    {
        public static void LoadDrawingManager()
        {
            Drawing.OnDraw += Drawing_OnDraw;
        }

        private static void Drawing_OnDraw(System.EventArgs args)
        {
            if (DrawReady)
            {
                if (DrawQ && Q.IsReady())
                {
                    Me.DrawCircle((int)Q.Range, QColor);
                }
                if (DrawW && W.IsReady())
                {
                    Me.DrawCircle((int)W.Range, WColor);
                }
                if (DrawE && E.IsReady())
                {
                    Me.DrawCircle((int)E.Range, EColor);
                }
                if (DrawR && R.IsReady())
                {
                    Me.DrawCircle((int)R.Range, RColor);
                }
            }
            else
            {
                if (DrawQ)
                {
                    Me.DrawCircle((int)Q.Range, QColor);
                }
                if (DrawW)
                {
                    Me.DrawCircle((int)W.Range, WColor);
                }
                if (DrawE)
                {
                    Me.DrawCircle((int)E.Range, EColor);
                }
                if (DrawR)
                {
                    Me.DrawCircle((int)R.Range, RColor);
                }
            }

            if (MyADC.IsValidTarget())
            {
                MyADC.DrawCircle((int)MyADC.BoundingRadius + 50, Color.Aqua, 15f);

                //PositionManager.Position.DrawCircle(25, SharpDX.Color.AliceBlue, 10);

                DangerManager.DrawSpells(Color.Black);
            }

            foreach (var enemy in EntityManager.Heroes.AllHeroes)
            {
                enemy.DrawCircle((int)enemy.BoundingRadius, enemy.IsBeingAutoAttacked() ? Color.Red: Color.Green, 8f);
            }
        }
    }
}
