using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using Lib;

using static Lib.Utils;

namespace ChampionTemplate
{
    public static class SpellManager
    {
        public static Spell.Active Q;
        public static Spell.Active W;
        public static Spell.Active E;
        public static Spell.Active R;

        public static void Load()
        {
            Q = new Spell.Active(SpellSlot.Q, 100);
            W = new Spell.Active(SpellSlot.W, 200);
            E = new Spell.Active(SpellSlot.E, 300);
            R = new Spell.Active(SpellSlot.R, 400);
        }
    }
}
