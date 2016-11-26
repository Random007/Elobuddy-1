using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace BrazilianLux.Misc
{
    public static partial class Extensions
    {
        public static AIHeroClient GetTgt(this Spell.SpellBase spell, int extraRange = 200)
        {
            return TargetSelector.GetTarget(spell.Range + extraRange, spell.DamageType);
        }

        public static bool HasPassive(this Obj_AI_Base hero)
        {
            return hero.HasBuff("luxilluminatingfraulein");
        }

        public static int TravelTime(this Spell.Skillshot spell, Obj_AI_Base target)
        {
            return (int) ((target.Distance(Player.Instance.Position)/spell.Speed)*1000) + spell.CastDelay;
        }
    }

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

        #endregion ComboBo

    }
}
