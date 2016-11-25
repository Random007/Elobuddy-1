using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Mario_s_Lib;

namespace Mario_s_Activator.Misc
{
    public static class Extensions
    {
        public static bool HasCC(this Obj_AI_Base target)
        {
            if (target.HasBuffOfType(BuffType.Stun) && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "Stun"))
            {
                return true;
            }
            if (target.HasBuffOfType(BuffType.Blind) && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "Blind"))
            {
                return true;
            }
            if (target.HasBuffOfType(BuffType.Slow) && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "Slow"))
            {
                return true;
            }
            if (target.HasBuffOfType(BuffType.Snare) && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "Snare"))
            {
                return true;
            }
            if (target.HasBuffOfType(BuffType.Flee) && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "Flee"))
            {
                return true;
            }
            if (target.HasBuffOfType(BuffType.Suppression) && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "Supression"))
            {
                return true;
            }
            if (target.HasBuffOfType(BuffType.Taunt) && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "Taunt"))
            {
                return true;
            }
            if (target.HasBuffOfType(BuffType.Charm) && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "Charm"))
            {
                return true;
            }
            if (target.HasBuffOfType(BuffType.Polymorph) && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "Polymorph"))
            {
                return true;
            }
            return false;
        }

        public static AIHeroClient GetBestItemTarget(Item xItem)
        {
            var target =
                EntityManager.Heroes.Enemies.OrderBy(e => e.Health)
                    .ThenBy(e => e.FlatPhysicalDamageMod)
                    .ThenBy(e => e.FlatMagicDamageMod)
                    .FirstOrDefault(e => e.IsValidTarget(xItem.Range));
            return target;
        }
    }
}
