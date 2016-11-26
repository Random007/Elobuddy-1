using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace Lib
{
    /// <summary>
    /// Menu Extensions
    /// </summary>
    public static partial class Extensions
    {
        #region CheckBox

        public static CheckBox CreateCheckbox(this Menu menu, Spell.SpellBase spell, string extraId = "", bool defaultValue = true)
        {
            return menu.Add(menu.DisplayName + spell.Slot + extraId, new CheckBox("Use " + spell.Slot, defaultValue));
        }

        public static bool GetCheckBoxValue(this Menu menu, Spell.SpellBase spell, string extraId = "")
        {
            return menu.Get<CheckBox>(menu.DisplayName + spell.Slot + extraId).CurrentValue;
        }

        public static CheckBox CreateCheckbox(this Menu menu, string uniqueId, string displayName,
            bool defaultValue = true)
        {
            return menu.Add(uniqueId, new CheckBox(displayName, defaultValue));
        }

        public static bool GetCheckBoxValue(this Menu menu, string uniqueId)
        {
            return menu.Get<CheckBox>(uniqueId).CurrentValue;
        }

        #endregion CheckBox

        #region Slider

        public static Slider CreateSlider(this Menu menu, Spell.SpellBase spell, string name, int defaultValue = 0,
            int minValue = 0, int maxValue = 100)
        {
            return menu.Add(menu.DisplayName + spell.Slot, new Slider(name, defaultValue, minValue, maxValue));
        }

        public static int GetSliderValue(this Menu menu, Spell.SpellBase spell)
        {
            return menu.Get<Slider>(menu.DisplayName + spell.Slot).CurrentValue;
        }

        public static Slider CreateSlider(this Menu menu, string id, string name, int defaultValue = 0, int minValue = 0,
            int maxValue = 100)
        {
            return menu.Add(id, new Slider(name, defaultValue, minValue, maxValue));
        }

        public static int GetSliderValue(this Menu menu, string id)
        {
            return menu.Get<Slider>(id).CurrentValue;
        }

        #endregion Slider

        #region ComboBox

        public static ComboBox CreateComboBox(this Menu menu, string uniqueId, string displayName, List<string> options, int defaultValue = 0)
        {
            return menu.Add(uniqueId, new ComboBox(displayName, options, defaultValue));
        }

        #endregion ComboBox

    }

    /// <summary>
    /// Vectors
    /// </summary>
    public static partial class Extensions
    {
        public static Vector3 GetFixedYPosition(this GameObject target)
        {
            var pos = target.Position;
            return new Vector3(pos.X, pos.Y, pos.Z - 100);
        }

        public static Vector3 GetFixedYPosition(this Vector3 target)
        {
            return new Vector3(target.X, target.Y, target.Z - 100);
        }
    }
    
    /// <summary>
    /// Cache Extensions
    /// </summary>
    public static partial class Extensions
    {
        public enum MinionTypes
        {
            Normal,
            Melee,
            Ranged,
            Siege,
            Super,
            Ward,
            Unknown
        }

        private static readonly List<string> CloneList = new List<string> {"leblanc", "shaco", "monkeyking"};

        private static readonly List<string> NormalMinionList = new List<string>
        {
            "SRU_ChaosMinionMelee",
            "SRU_ChaosMinionRanged",
            "SRU_OrderMinionMelee",
            "SRU_OrderMinionRanged",
            "HA_ChaosMinionMelee",
            "HA_ChaosMinionRanged",
            "HA_OrderMinionMelee",
            "HA_OrderMinionRanged"
        };

        private static readonly List<string> PetList = new List<string>
        {
            "annietibbers",
            "elisespiderling",
            "heimertyellow",
            "heimertblue",
            "malzaharvoidling",
            "shacobox",
            "yorickspectralghoul",
            "yorickdecayedghoul",
            "yorickravenousghoul",
            "zyrathornplant",
            "zyragraspingplant"
        };


        private static readonly List<string> SiegeMinionList = new List<string>
        {
            "SRU_ChaosMinionSiege",
            "SRU_OrderMinionSiege",
            "HA_ChaosMinionSiege",
            "HA_OrderMinionSiege"
        };


        private static readonly List<string> SuperMinionList = new List<string>
        {
            "SRU_ChaosMinionSuper",
            "SRU_OrderMinionSuper",
            "HA_ChaosMinionSuper",
            "HA_OrderMinionSuper"
        };

        public static MinionTypes GetMinionType(this Obj_AI_Minion minion)
        {
            var baseSkinName = minion.CharData.BaseSkinName;

            if (NormalMinionList.Any(n => baseSkinName.Equals(n)))
            {
                return MinionTypes.Normal
                       | (minion.CharData.BaseSkinName.Contains("Melee") ? MinionTypes.Melee : MinionTypes.Ranged);
            }

            if (SiegeMinionList.Any(n => baseSkinName.Equals(n)))
            {
                return MinionTypes.Siege | MinionTypes.Ranged;
            }

            if (SuperMinionList.Any(n => baseSkinName.Equals(n)))
            {
                return MinionTypes.Super | MinionTypes.Melee;
            }

            if (baseSkinName.ToLower().Contains("ward") || baseSkinName.ToLower().Contains("trinket"))
            {
                return MinionTypes.Ward;
            }

            return MinionTypes.Unknown;
        }

        public static bool IsPet(this Obj_AI_Minion minion, bool includeClones = true)
        {
            var name = minion.CharData.BaseSkinName.ToLower();
            return PetList.Contains(name) || (includeClones && CloneList.Contains(name));
        }

        public enum JungleType
        {
            Small,
            Large,
            Epic,
            Legendary,
            Unknown
        }

        public static JungleType GetJungleType(this Obj_AI_Minion minion)
        {
            switch (Game.MapId)
            {
                case GameMapId.CrystalScar:
                    var legendaryJungleCS = new[] {"AscXerath"};

                    if (legendaryJungleCS.Contains(minion.BaseSkinName))
                    {
                        return JungleType.Legendary;
                    }

                    return JungleType.Small;

                case GameMapId.TwistedTreeline:
                    var largeJungleTT = new[] {"TT_NWraith", "TT_NWolf", "TT_NGolem"};
                    var legendaryJungleTT = new[] {"TT_Spiderboss"};
                    if (largeJungleTT.Contains(minion.BaseSkinName))
                    {
                        return JungleType.Large;
                    }

                    if (legendaryJungleTT.Contains(minion.BaseSkinName))
                    {
                        return JungleType.Legendary;
                    }

                    return JungleType.Small;

                case GameMapId.SummonersRift:
                    var largeJungleSR = new[]
                    {
                        "SRU_Gromp", "SRU_Krug", "SRU_Razorbeak",
                        "Sru_Crab", "SRU_Murkwolf"
                    };

                    var epicJungleSR = new[] {"SRU_Blue", "SRU_Red"};

                    var legendaryJungleSR = new[]
                    {
                        "SRU_Dragon_Air", "SRU_Dragon_Earth", "SRU_Dragon_Fire", "SRU_Dragon_Water", "SRU_Dragon_Elder",
                        "SRU_Baron", "SRU_RiftHerald"
                    };

                    if (largeJungleSR.Contains(minion.BaseSkinName))
                    {
                        return JungleType.Large;
                    }

                    if (epicJungleSR.Contains(minion.BaseSkinName))
                    {
                        return JungleType.Epic;
                    }

                    if (legendaryJungleSR.Contains(minion.BaseSkinName))
                    {
                        return JungleType.Legendary;
                    }

                    return JungleType.Small;

                case GameMapId.HowlingAbyss:
                    break;
            }

            return JungleType.Unknown;
        }
    }

    /// <summary>
    /// Drawings
    /// </summary>
    public static partial class Extensions
    {
        public static void DrawSpell(this Spell.SpellBase spell, System.Drawing.Color color)
        {
            Circle.Draw(color.ToSharpDX(), spell.Range, 3f, Player.Instance);
        }

        public static void DrawCircle(this Obj_AI_Base target, int radius, System.Drawing.Color color)
        {
            Circle.Draw(color.ToSharpDX(), radius, 3f, target);
        }
    }

    /// <summary>
    /// Hero Extensions
    /// </summary>
    public static partial class Extensions
    {
        public static int GetHighestSpellRange(this AIHeroClient target)
        {
            var spellQ = target.Spellbook.GetSpell(SpellSlot.Q);
            var spellW = target.Spellbook.GetSpell(SpellSlot.W);
            var spellE = target.Spellbook.GetSpell(SpellSlot.E);
            var spellR = target.Spellbook.GetSpell(SpellSlot.R);

            var spellList = new List<SpellDataInst>
            {
                spellQ,
                spellW,
                spellE,
                spellR
            };

            return (int)spellList.OrderByDescending(s => s.SData.CastRange).First().SData.CastRange;
        }
    }
}
