using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static BlackYasuo.Helper;
using static BlackYasuo.SpellManager;

namespace BlackYasuo.Modes
{
    public abstract class ModeBase
    {
        public abstract bool CanRun();

        public abstract void Execute();
    }
}
