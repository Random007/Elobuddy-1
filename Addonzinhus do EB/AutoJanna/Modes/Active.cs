using System;
using System.Diagnostics;
using System.Linq;
using AutoJanna.Managers;
using AutoJanna.Misc;
using AutoJanna.Modes.BlackYasuo.Modes;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

using static AutoJanna.Misc.Helper;
using static AutoJanna.Misc.Utils;
using static AutoJanna.Managers.SpellManager;
using static AutoJanna.MenuVariables;

namespace AutoJanna.Modes
{
    public class Active : ModeBase
    {
        private int LastRun;

        public override bool CanRun()
        {
            if (LastRun > TickCount) return false;
            LastRun = TickCount + GetRandomNumber(200, 500);
            return true;
        }

        public override void Execute()
        {
            Target = TargetSelector.GetTarget(2000, DamageType.Physical);
            if (MyADC == null) return;

            if (!Me.IsRecalling())
            {
                PositionManager.Position = PositionManager.BestPosition();
                Orbwalker.OverrideOrbwalkPosition += OverrideOrbwalkPosition;
            }

            if (MyADC.IsAttacking())
            {
                E.Cast(MyADC);
            }

            if (MyADC.IsInDanger(300, 90))
            {
                E.Cast(MyADC);
            }

            if (Me.IsInDanger(300, 90))
            {
                E.Cast(Me);
            }

            #region Debug

            if(!DebugDanger)return;

            foreach (var hero in EntityManager.Heroes.AllHeroes)
            {
                if (hero.IsInDanger(350, 90))
                {
                    Console.WriteLine(hero.BaseSkinName + " Is In Danger");
                }
            }

            #endregion Debug
        }

        private static Vector3? OverrideOrbwalkPosition()
        {
            return PositionManager.Position;
        }
    }
}