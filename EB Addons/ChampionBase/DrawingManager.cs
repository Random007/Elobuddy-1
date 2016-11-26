using System;
using System.Drawing;
using EloBuddy;
using Lib;

using static ChampionTemplate.Helper;
using static ChampionTemplate.SpellManager;
using static ChampionTemplate.MyMenu;

namespace ChampionTemplate
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
            if(Me.IsDead)return;
            if (DrawMenu.GetCheckBoxValue("drawReady"))
            {
                if (QColor.BoolValue && Q.IsReady())
                {
                    Q.DrawSpell(QColor.GetColor());
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
