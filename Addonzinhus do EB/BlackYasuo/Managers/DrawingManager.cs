using EloBuddy;
using EloBuddy.SDK;
using static Template.MenuVariables;
using static Template.Managers.SpellManager;
using static Template.Misc.Helper;

namespace Template.Managers
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
        }
    }
}
