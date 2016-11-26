using EloBuddy;
using EloBuddy.SDK.Enumerations;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Lib.Bases
{
    public class SpellDataBase
    {
        public string DisplayName { get; set; }
        public string SpellName { get; set; }
        public string MissileSpellName { get; set; }
        public SpellSlot Slot { get; set; }
        public SkillShotType SkillShotType { get; set; }
        public int Delay { get; set; }
        public int Range { get; set; }
        public int Radius { get; set; }
        public float MissileSpeed { get; set; }
        public int DangerValue { get; set; }
        public bool IsDangerous { get; set; }
        public string ChampionName { get; set; }
        public string ToggleParticleName { get; set; }
        public bool AllowCrossing { get; set; }
        public bool AddHitbox { get; set; }
        public int ExtraMissiles { get; set; }

        public bool IsGlobal => Range > 10000;

        public SpellDataBase()
        {
            AddHitbox = true;
        }
    }
}
