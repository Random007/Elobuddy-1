using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ChampionTemplate.Helper;
using static Lib.Utils;
using static ChampionTemplate.SpellManager;

namespace ChampionTemplate.Modes
{
    public abstract class ModeBase
    {
        public abstract bool CanRun();

        public abstract void Execute();
    }
}
