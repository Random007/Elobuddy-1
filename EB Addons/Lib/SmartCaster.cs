using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace Lib
{
    public static class SmartCaster
    {
        public static bool SmartCast(this Spell.SpellBase spell, Obj_AI_Base target)
        {
            return spell.SmartCast(50, target);
        }

        public static bool SmartCast(this Spell.SpellBase spell, int hitChance = 75, Obj_AI_Base target = null)
        {
            if (!spell.IsReady()) return false;

            var mode = Orbwalker.ActiveModesFlags;

            var skillShot = spell as Spell.Skillshot;

            #region Combo
            //Combo logic
            if (mode.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                //Get target if null
                if (target == null)
                {
                    target = spell.GetTarget(100);
                }

                if (target == null) return false;

                //IsSkillshot
                if (skillShot != null)
                {
                    if (skillShot.AllowedCollisionCount > 1)
                    {
                        var enemyCount = Player.Instance.CountEnemiesInRange(spell.Range + 100);
                        if (enemyCount >= 2)
                        {
                            skillShot.CastIfItWillHit(1, hitChance);
                            return true;
                        }

                        if (enemyCount >= 3)
                        {
                            skillShot.CastIfItWillHit(2, hitChance);
                            return true;
                        }
                    }
                    //Chat.Print("Hu3");
                    skillShot.CastMinimumHitchance(target, hitChance);
                    return true;
                }

                if (target != null && target.IsValidTarget(spell.Range))
                {
                    spell.Cast(target);
                    return true;
                }
            }
            #endregion Combo

            #region Harass
            //Harass logic
            if (mode.HasFlag(Orbwalker.ActiveModes.Harass))
            {
                //Get target if null
                if (target == null)
                {
                    target = spell.GetTarget(100);
                }

                if (target == null) return false;

                //IsSkillshot
                if (skillShot != null)
                {
                    if (skillShot.AllowedCollisionCount > 1)
                    {
                        if (Player.Instance.CountEnemiesInRange(spell.Range + 100) >= 2)
                        {
                            skillShot.CastIfItWillHit(1, hitChance);
                            return true;
                        }

                        if (Player.Instance.CountEnemiesInRange(spell.Range + 100) >= 3)
                        {
                            skillShot.CastIfItWillHit(2, hitChance);
                            return true;
                        }
                    }

                    skillShot.CastMinimumHitchance(target, hitChance);
                    return true;
                }

                if (target != null && target.IsValidTarget(spell.Range))
                {
                    spell.Cast(target);
                    return true;
                }

            }
            #endregion Harass

            #region JungleClear

            if (mode.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {
                if (target == null)
                {
                    target =
                        EntityManager.MinionsAndMonsters.GetJungleMonsters().OrderByDescending(m => m.MaxHealth)
                            .ThenBy(m => m.Distance(Player.Instance)).FirstOrDefault(
                                m => m.IsValidTarget(spell.Range));
                }

                if (target != null && target.IsValidTarget(spell.Range))
                {
                    //IsSkillshot
                    if (skillShot != null)
                    {
                        skillShot.CastMinimumHitchance(target, hitChance);
                    }
                    spell.Cast(target);
                }
            }

            #endregion JungleClear

            #region LaneClear
            if (mode.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                //IsSkillShot
                if (skillShot != null)
                { 
                    if (skillShot.AllowedCollisionCount > 1)
                    {
                        var minionCount = Player.Instance.CountEnemyMinionsInRange(spell.Range + 100);
                        if (minionCount >= 2)
                        {
                            skillShot.CastOnBestFarmPosition(1);
                            return true;
                        }

                        if (minionCount >= 3)
                        {
                            skillShot.CastOnBestFarmPosition(2);
                            return true;
                        }
                    }

                    if (target == null) return false;

                    skillShot.CastMinimumHitchance(target, hitChance);
                    return true;
                }
                if (target != null && target.IsValidTarget(spell.Range))
                {
                    spell.Cast(target);
                    return true;
                }
            }
            #endregion LaneClear

            return false;
        }
    }
}
