using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy.SDK;
using Template.Modes.BlackYasuo.Modes;
using static Template.Managers.SpellManager;

namespace Template.Modes
{
    public class JungleClear : ModeBase
    {
        public override bool CanRun()
        {
            var anyJungleMinion = EntityManager.MinionsAndMonsters.GetJungleMonsters().Any(m => m.IsValidTarget(2000));
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear) && anyJungleMinion;
        }

        public override void Execute()
        {
        }
    }
}
