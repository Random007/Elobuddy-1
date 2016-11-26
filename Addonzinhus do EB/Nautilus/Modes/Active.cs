using EloBuddy;
using Nautilus.Modes.BlackYasuo.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Spells;
using static Nautilus.SpellManager;
using static Nautilus.Helper;
using static Nautilus.MyMenu;

namespace Nautilus.Modes
{
    public class Active : ModeBase
    {
        public override bool CanRun()
        {
            return true;
        }

        public override void Execute()
        {
            /* if (MiscMenu.GetCheckBoxValue("SmiteEnemyKS"))
            {
                var smite = SummonerSpells.Smite;
                var smiteRange = smite.Range;
                var smiteOnPlayer =
                    new int[] {0, 28, 36, 44, 52, 60, 68, 76, 84, 92, 100, 108, 116, 124, 132, 140, 148, 156, 166}[
                        Player.Instance.Level];
                var enemy =
                    EntityManager.Heroes.Enemies.FirstOrDefault(
                        e => e.IsValidTarget(smiteRange) && e.Health <= smiteOnPlayer);
                if (!smite.IsReady()) return;
                smite.Cast(enemy);
            }*/

            /* if (MiscMenu.GetCheckBoxValue("SmiteMobsJG"))
            {
                var smite = SummonerSpells.Smite;
                var smiteRange = smite.Range;
                var smiteOnMobs =
                    new int[]
                    {0, 390, 410, 430, 450, 380, 510, 540, 570, 600, 640, 680, 720, 760, 800, 850, 900, 950, 100}[
                        Player.Instance.Level];
                var minionsjg =
                    EntityManager.MinionsAndMonsters.Monsters.FirstOrDefault(
                        m => m.IsValidTarget(smiteRange) && m.Health <= smiteOnMobs && !m.BaseSkinName.Contains("Mini"));
                if (minionsjg == null) return;
                if (!smite.IsReady()) return;
                smite.Cast(minionsjg);*/
        }
    }
}