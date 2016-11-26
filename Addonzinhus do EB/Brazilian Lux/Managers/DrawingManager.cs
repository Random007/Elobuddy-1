using System.Drawing;
using System.Linq;
using BrazilianLux.Misc;
using EloBuddy;
using EloBuddy.SDK;

using static BrazilianLux.MenuVariables;
using static BrazilianLux.Managers.SpellManager;
using static BrazilianLux.Misc.Helper;

namespace BrazilianLux.Managers
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
                    QObj?.Miss.DrawCircle(Q.Width, QColor);
                    QObj?.Poly.Draw(QColor, 5);
                }
                if (DrawW && W.IsReady())
                {
                    Me.DrawCircle((int)W.Range, WColor);
                }
                if (DrawE && E.IsReady())
                {
                    Me.DrawCircle((int)E.Range, EColor);
                    EObj?.DrawCircle(E.Width, EColor);
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
                    QObj?.Miss.DrawCircle(Q.Width, QColor);
                    QObj?.Poly.Draw(QColor, 5);
                }
                if (DrawW)
                {
                    Me.DrawCircle((int)W.Range, WColor);
                }
                if (DrawE)
                {
                    Me.DrawCircle((int)E.Range, EColor);
                    EObj?.DrawCircle(E.Width, EColor);
                }
                if (DrawR)
                {
                    Me.DrawCircle((int)R.Range, RColor);
                }
            }
        }
    }
}
