using System.Collections.Generic;
using BlackYasuo.Bases;
using EloBuddy;
using EloBuddy.SDK.Enumerations;

// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo

namespace BlackYasuo.Databases
{
    public static class SpellDB
    {
        public static readonly List<SpellDataBase> Database = new List<SpellDataBase>
        {
            new SpellDataBase
            {
                DisplayName = "Mark",
                ChampionName = "AllChampions",
                SpellName = "summonersnowball",
                Slot = SpellSlot.Summoner1,
                SkillShotType = SkillShotType.Linear,
                Delay = 0,
                Range = 1600,
                Radius = 60,
                MissileSpeed = 1300,
                DangerValue = 1,
                IsDangerous = true,
                MissileSpellName = "disabled/TestCubeRender",
                ToggleParticleName = "Summoner_Snowball_Explosion_Sound.troy"
            },

            #region Aatrox
            new SpellDataBase
            {
                DisplayName = "Dark Flight",
                ChampionName = "Aatrox",
                SpellName = "AatroxQ",
                Slot = SpellSlot.Q,
                SkillShotType = SkillShotType.Circular,
                Delay = 250,
                Range = 650,
                Radius = 285,
                MissileSpeed = 450,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "AatroxQ"
            },
            new SpellDataBase
            {
                DisplayName = "Blades of Torment",
                ChampionName = "Aatrox",
                SpellName = "AatroxE",
                Slot = SpellSlot.E,
                SkillShotType = SkillShotType.Linear,
                Delay = 250,
                Range = 1075,
                Radius = 100,
                MissileSpeed = 1200,
                DangerValue = 3,
                IsDangerous = false,
                MissileSpellName = "AatroxE"

            },

            #endregion Aatrox

            //TODO ADD skillshottype
            #region Ahri
            new SpellDataBase
            {
                DisplayName = "Orb of Deception",
                ChampionName = "Ahri",
                SpellName = "AhriOrbofDeception",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 925,
                Radius = 100,
                MissileSpeed = 1750,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "AhriOrbMissile"

            },
            new SpellDataBase
            {
                DisplayName = "Charm",
                ChampionName = "Ahri",
                SpellName = "AhriSeduce",
                Slot = SpellSlot.E,
                Delay = 250,
                Range = 1000,
                Radius = 60,
                MissileSpeed = 1550,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "AhriSeduceMissile",

            },
            new SpellDataBase
            {
                DisplayName = "Orb of Deception - Back",
                ChampionName = "Ahri",
                SpellName = "AhriOrbofDeception2",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 925,
                Radius = 100,
                MissileSpeed = 915,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "AhriOrbofDeception2"

            },

            #endregion Ahri

            #region Alistar
            new SpellDataBase()
            {
                DisplayName = "Pulverize",
                ChampionName = "Alistar",
                SpellName = "Pulverize",
                Slot = SpellSlot.Q,
                Delay = 0,
                Range = 365,
                Radius = 365,
                MissileSpeed = 0,
                DangerValue = 2,
                IsDangerous = true,
                MissileSpellName = "Pulverize"

            },

            #endregion Alistar

            #region Amumu

            new SpellDataBase
            {
                DisplayName = "Bandage Toss",
                ChampionName = "Amumu",
                SpellName = "BandageToss",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1100,
                Radius = 80,
                MissileSpeed = 2000,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "SadMummyBandageToss"

            },
            new SpellDataBase
            {
                DisplayName = "Curse of the Sad Mummy",
                ChampionName = "Amumu",
                SpellName = "CurseoftheSadMummy",
                Slot = SpellSlot.R,
                Delay = 250,
                Range = 560,
                Radius = 560,
                MissileSpeed = 0,
                DangerValue = 5,
                MissileSpellName = "CurseoftheSadMummy",
                IsDangerous = true

            },

            #endregion Amumu

            #region Anivia
            new SpellDataBase
            {
                DisplayName = "Flash Frost",
                ChampionName = "Anivia",
                SpellName = "FlashFrostSpell",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1250,
                Radius = 110,
                MissileSpeed = 850,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "FlashFrostSpell"

            },

            #endregion Anivia

            #region Annie
            new SpellDataBase
            {
                ChampionName = "Annie",
                SpellName = "Incinerate",
                Slot = SpellSlot.W,
                Delay = 250,
                Range = 625,
                Radius = 80,
                MissileSpeed = 0,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "Incinerate"
            },
            new SpellDataBase
            {
                DisplayName = "Summon: Tibbers",
                ChampionName = "Annie",
                SpellName = "InfernalGuardian",
                Slot = SpellSlot.R,
                Delay = 250,
                Range = 600,
                Radius = 290,
                MissileSpeed = 0,
                DangerValue = 5,
                IsDangerous = true,
                MissileSpellName = "InfernalGuardian"
            },

            #endregion Annie

            #region Ashe
            new SpellDataBase
            {
                DisplayName = "Enchanted Crystal Arrow",
                ChampionName = "Ashe",
                SpellName = "EnchantedCrystalArrow",
                Slot = SpellSlot.R,
                Delay = 250,
                Range = 12500,
                Radius = 130,
                MissileSpeed = 1600,
                DangerValue = 5,
                IsDangerous = true,
                MissileSpellName = "EnchantedCrystalArrow"
            },
            new SpellDataBase
            {
                ChampionName = "Ashe",
                SpellName = "Volley",
                Slot = SpellSlot.W,
                Delay = 250,
                Range = 1150,
                Radius = 20,
                MissileSpeed = 1500,
                DangerValue = 3,
                MissileSpellName = "VolleyAttack",
                ExtraMissiles = 8
            },

            #endregion Ashe

            #region Azir
            new SpellDataBase
            {
                DisplayName = "Conquering Sands",
                ChampionName = "Azir",
                SpellName = "disabled/AzirQ",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 850,
                Radius = 80,
                MissileSpeed = 1000,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "azirsoldiermissile"
            },

            #endregion Azir

            #region Bard
            new SpellDataBase
            {
                DisplayName = "Cosmic Binding",
                ChampionName = "Bard",
                SpellName = "BardQ",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 950,
                Radius = 60,
                MissileSpeed = 1600,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "BardQMissile"
            },

            #endregion Bard

            #region Blitzcrank
            new SpellDataBase
            {
                DisplayName = "Rocket Grab",
                ChampionName = "Blitzcrank",
                SpellName = "RocketGrab",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1050,
                Radius = 70,
                MissileSpeed = 1800,
                DangerValue = 4,
                IsDangerous = true,
                MissileSpellName = "RocketGrabMissile"
            },

            #endregion Blitzcrank

            #region Brand
            new SpellDataBase
            {
                DisplayName = "Sear",
                ChampionName = "Brand",
                SpellName = "BrandQ",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1100,
                Radius = 60,
                MissileSpeed = 1600,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "BrandQMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Pillar of Flame",
                ChampionName = "Brand",
                SpellName = "BrandW",
                Slot = SpellSlot.W,
                Delay = 850,
                Range = 1100,
                Radius = 250,
                MissileSpeed = 0,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "BrandFissure"
            },

            #endregion Brand

            #region Braum
            new SpellDataBase
            {
                DisplayName = "Winter's Bite",
                ChampionName = "Braum",
                SpellName = "BraumQ",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1000,
                Radius = 100,
                MissileSpeed = 1200,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "BraumQMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Glacial Fissure",
                ChampionName = "Braum",
                SpellName = "BraumRWrapper",
                Slot = SpellSlot.R,
                Delay = 500,
                Range = 1250,
                Radius = 100,
                MissileSpeed = 1125,
                DangerValue = 4,
                IsDangerous = true,
                MissileSpellName = "braumrmissile"
            },

            #endregion Braum

            #region Caitlyn
            new SpellDataBase
            {
                DisplayName = "Piltover Peacemaker",
                ChampionName = "Caitlyn",
                SpellName = "CaitlynPiltoverPeacemaker",
                Slot = SpellSlot.Q,
                Delay = 625,
                Range = 1300,
                Radius = 90,
                MissileSpeed = 2200,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "CaitlynPiltoverPeacemaker"
            },
            new SpellDataBase
            {
                DisplayName = "90 Caliber Net",
                ChampionName = "Caitlyn",
                SpellName = "CaitlynEntrapment",
                Slot = SpellSlot.E,
                Delay = 125,
                Range = 950,
                Radius = 80,
                MissileSpeed = 2000,
                DangerValue = 1,
                IsDangerous = false,
                MissileSpellName = "CaitlynEntrapmentMissile"
            },

            #endregion Caitlyn

            #region Cassiopeia
            new SpellDataBase
            {
                DisplayName = "Noxious Blast",
                ChampionName = "Cassiopeia",
                SpellName = "CassiopeiaQ",
                Slot = SpellSlot.Q,
                Delay = 825,
                Range = 600,
                Radius = 200,
                MissileSpeed = 0,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "CassiopeiaQ"
            },
            new SpellDataBase
            {
                ChampionName = "Cassiopeia",
                SpellName = "CassiopeiaPetrifyingGaze",
                Slot = SpellSlot.R,
                Delay = 500,
                Range = 825,
                Radius = 20,
                MissileSpeed = 0,
                DangerValue = 3,
                MissileSpellName = "CassiopeiaPetrifyingGaze"
            },

            #endregion Cassiopeia

            #region Chogath
            new SpellDataBase
            {
                DisplayName = "Rupture",
                ChampionName = "Chogath",
                SpellName = "Rupture",
                Slot = SpellSlot.Q,
                Delay = 1200,
                Range = 950,
                Radius = 250,
                MissileSpeed = 0,
                DangerValue = 3,
                IsDangerous = false,
                MissileSpellName = "Rupture"
            },
            new SpellDataBase
            {
                ChampionName = "Chogath",
                SpellName = "FeralScream",
                Slot = SpellSlot.W,
                Delay = 250,
                Range = 650,
                Radius = 20,
                MissileSpeed = 0,
                DangerValue = 3,
                MissileSpellName = "FeralScream"
            },

            #endregion Chogath

            #region Corki
            new SpellDataBase
            {
                DisplayName = "Phosphorus Bomb",
                ChampionName = "Corki",
                SpellName = "PhosphorusBomb",
                Slot = SpellSlot.Q,
                Delay = 500,
                Range = 825,
                Radius = 270,
                MissileSpeed = 1125,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "PhosphorusBombMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Missile Barrage Big",
                ChampionName = "Corki",
                SpellName = "MissileBarrage2",
                Slot = SpellSlot.R,
                Delay = 175,
                Range = 1500,
                Radius = 40,
                MissileSpeed = 2000,
                DangerValue = 3,
                IsDangerous = false,
                MissileSpellName = "MissileBarrageMissile2"
            },

            #endregion Corki

            #region Diana
            #endregion Diana

            #region DrMundo
            new SpellDataBase
            {
                DisplayName = "Infected Cleaver",
                ChampionName = "DrMundo",
                SpellName = "InfectedCleaverMissileCast",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1050,
                Radius = 60,
                MissileSpeed = 2000,
                DangerValue = 3,
                IsDangerous = false,
                MissileSpellName = "InfectedCleaverMissile"
            },

            #endregion DrMundo

            #region Draven
            new SpellDataBase
            {
                DisplayName = "Stand Aside",
                ChampionName = "Draven",
                SpellName = "DravenDoubleShot",
                Slot = SpellSlot.E,
                Delay = 250,
                Range = 1100,
                Radius = 130,
                MissileSpeed = 1400,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "DravenDoubleShotMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Whirling Death",
                ChampionName = "Draven",
                SpellName = "DravenRCast",
                Slot = SpellSlot.R,
                Delay = 500,
                Range = 12500,
                Radius = 160,
                MissileSpeed = 2000,
                DangerValue = 5,
                IsDangerous = true,
                MissileSpellName = "DravenR"
            },

            #endregion Draven

            #region Ekko
            new SpellDataBase
            {
                DisplayName = "Timewinder",
                ChampionName = "Ekko",
                SpellName = "EkkoQ",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 950,
                Radius = 60,
                MissileSpeed = 1650,
                DangerValue = 4,
                IsDangerous = true,
                MissileSpellName = "ekkoqmis"
            },
            new SpellDataBase
            {
                DisplayName = "Parallel Convergence",
                ChampionName = "Ekko",
                SpellName = "EkkoW",
                Slot = SpellSlot.W,
                Delay = 3750,
                Range = 1600,
                Radius = 375,
                MissileSpeed = 1650,
                DangerValue = 3,
                IsDangerous = false,
                AddHitbox = false,
                MissileSpellName = "EkkoW"
            },
            new SpellDataBase
            {
                DisplayName = "Chronobreak",
                ChampionName = "Ekko",
                SpellName = "EkkoR",
                Slot = SpellSlot.R,
                Delay = 250,
                Range = 1600,
                Radius = 375,
                MissileSpeed = 1650,
                DangerValue = 3,
                IsDangerous = false,
                MissileSpellName = "EkkoR"
            },

            #endregion Ekko

            #region Elise
            new SpellDataBase
            {
                DisplayName = "Cocoon",
                ChampionName = "Elise",
                SpellName = "EliseHumanE",
                Slot = SpellSlot.E,
                Delay = 250,
                Range = 1100,
                Radius = 70,
                MissileSpeed = 1600,
                DangerValue = 4,
                IsDangerous = true,
                MissileSpellName = "EliseHumanE"
            },

            #endregion Elise

            #region Evelynn
            new SpellDataBase
            {
                DisplayName = "Agony's Embrace",
                ChampionName = "Evelynn",
                SpellName = "EvelynnR",
                Slot = SpellSlot.R,
                Delay = 250,
                Range = 650,
                Radius = 350,
                MissileSpeed = 0,
                DangerValue = 5,
                IsDangerous = true,
                MissileSpellName = "EvelynnR"
            },

            #endregion Evelynn

            #region Ezreal
            new SpellDataBase
            {
                DisplayName = "Mystic Shot",
                ChampionName = "Ezreal",
                SpellName = "EzrealMysticShot",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1200,
                Radius = 60,
                MissileSpeed = 2000,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "EzrealMysticShotMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Essence Flux",
                ChampionName = "Ezreal",
                SpellName = "EzrealEssenceFlux",
                Slot = SpellSlot.W,
                Delay = 250,
                Range = 1050,
                Radius = 80,
                MissileSpeed = 1600,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "EzrealEssenceFluxMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Trueshot Barrage",
                ChampionName = "Ezreal",
                SpellName = "EzrealTrueshotBarrage",
                Slot = SpellSlot.R,
                Delay = 1000,
                Range = 20000,
                Radius = 160,
                MissileSpeed = 2000,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "EzrealTrueshotBarrage"
            },

            #endregion Ezreal

            #region Fiora
            new SpellDataBase
            {
                DisplayName = "",
                ChampionName = "Fiora",
                SpellName = "",
                Slot = SpellSlot.W,
                SkillShotType = SkillShotType.Linear,
                Delay = 480,
                Range = 20000,
                Radius = 70,
                MissileSpeed = 3200,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = ""
            },

            #endregion Fiora

            #region Fizz
            new SpellDataBase
            {
                DisplayName = "Chum the Waters",
                ChampionName = "Fizz",
                SpellName = "FizzMarinerDoom",
                Slot = SpellSlot.R,
                Delay = 250,
                Range = 1275,
                Radius = 120,
                MissileSpeed = 1350,
                DangerValue = 5,
                IsDangerous = true,
                MissileSpellName = "FizzMarinerDoomMissile"
            },

            #endregion Fizz

            #region Galio
            new SpellDataBase
            {
                DisplayName = "Resolute Smite",
                ChampionName = "Galio",
                SpellName = "GalioResoluteSmite",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1040,
                Radius = 235,
                MissileSpeed = 1200,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "GalioResoluteSmite"
            },
            new SpellDataBase
            {
                DisplayName = "Righteous Gust",
                ChampionName = "Galio",
                SpellName = "GalioRighteousGust",
                Slot = SpellSlot.E,
                Delay = 250,
                Range = 1280,
                Radius = 120,
                MissileSpeed = 1300,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "GalioRighteousGust"
            },
            new SpellDataBase
            {
                DisplayName = "Idol of Durand",
                ChampionName = "Galio",
                SpellName = "GalioIdolOfDurand",
                Slot = SpellSlot.R,
                SkillShotType = SkillShotType.Circular,
                Delay = 250,
                Range = 600,
                Radius = 600,
                MissileSpeed = 0,
                DangerValue = 3,
                AddHitbox = false,
                MissileSpellName = ""
            },

            #endregion Galio

            #region Gnar
            new SpellDataBase
            {
                DisplayName = "Boomerang Throw",
                ChampionName = "Gnar",
                SpellName = "GnarQ",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1185,
                Radius = 60,
                MissileSpeed = 2400,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "GnarQ"

            },
            new SpellDataBase
            {
                DisplayName = "Boomerang Throw Return",
                ChampionName = "Gnar",
                SpellName = "GnarQReturn",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1185,
                Radius = 60,
                MissileSpeed = 2400,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "GnarQMissileReturn"

            },
            new SpellDataBase
            {
                DisplayName = "Hop",
                ChampionName = "Gnar",
                SpellName = "GnarE",
                Slot = SpellSlot.E,
                Delay = 0,
                Range = 475,
                Radius = 150,
                MissileSpeed = 900,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "GnarE"

            },
            new SpellDataBase
            {
                DisplayName = "Crunch",
                ChampionName = "Gnar",
                SpellName = "gnarbige",
                Slot = SpellSlot.E,
                Delay = 0,
                Range = 475,
                Radius = 100,
                MissileSpeed = 800,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "gnarbige"

            },
            new SpellDataBase
            {
                DisplayName = "Boulder Toss",
                ChampionName = "Gnar",
                SpellName = "gnarbigq",
                Slot = SpellSlot.Q,
                Delay = 500,
                Range = 1150,
                Radius = 90,
                MissileSpeed = 2100,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "gnarbigq"
            },
            new SpellDataBase
            {
                DisplayName = "Wallop",
                ChampionName = "Gnar",
                SpellName = "gnarbigw",
                Slot = SpellSlot.W,
                Delay = 600,
                Range = 600,
                Radius = 100,
                MissileSpeed = 0,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "gnarbigw"
            },
            new SpellDataBase
            {
                DisplayName = "GNAR!",
                ChampionName = "Gnar",
                SpellName = "GnarR",
                Slot = SpellSlot.R,
                Delay = 250,
                Range = 500,
                Radius = 500,
                MissileSpeed = 0,
                DangerValue = 5,
                IsDangerous = true,
                AddHitbox = false,
                MissileSpellName = "GnarR"
            },

            #endregion Gnar

            #region Gragas
            new SpellDataBase
            {
                DisplayName = "Barrel Roll",
                ChampionName = "Gragas",
                SpellName = "GragasQ",
                Slot = SpellSlot.Q,
                Delay = 500,
                Range = 975,
                Radius = 250,
                MissileSpeed = 1000,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "GragasQ",
                ToggleParticleName = "Gragas_.+_Q_(Enemy|Ally)"

            },

            new SpellDataBase
            {
                DisplayName = "Body Slam",
                ChampionName = "Gragas",
                SpellName = "GragasE",
                Slot = SpellSlot.E,
                Delay = 0,
                Range = 950,
                Radius = 200,
                MissileSpeed = 1200,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "GragasE"

            },

            new SpellDataBase
            {
                DisplayName = "Explosive Cask",
                ChampionName = "Gragas",
                SpellName = "GragasR",
                Slot = SpellSlot.R,
                Delay = 250,
                Range = 1050,
                Radius = 350,
                MissileSpeed = 1750,
                DangerValue = 5,
                IsDangerous = true,
                MissileSpellName = "GragasR"

            },

            #endregion Gragas

            #region Graves
            new SpellDataBase
            {
                DisplayName = "Collateral Damage",
                ChampionName = "Graves",
                SpellName = "GravesChargeShot",
                Slot = SpellSlot.R,
                Delay = 250,
                Range = 1000,
                Radius = 100,
                MissileSpeed = 2100,
                DangerValue = 5,
                IsDangerous = true,
                MissileSpellName = "GravesChargeShotShot"
            },

            #endregion Graves

            #region Hecarim
                    
            new SpellDataBase
            {
                DisplayName = "Onslaught of Shadows",
                ChampionName = "Hecarim",
                SpellName = "HecarimUlt",
                Slot = SpellSlot.R,
                Delay = 10,
                Range = 1500,
                Radius = 300,
                MissileSpeed = 1100,
                DangerValue = 5,
                IsDangerous = true,
                MissileSpellName = "HecarimUlt"
            },

            #endregion Hecarim

            #region Heimerdinger
            new SpellDataBase
            {
                DisplayName = "Hextech Micro-Rockets",
                ChampionName = "Heimerdinger",
                SpellName = "disabled/HeimerdingerW",
                Slot = SpellSlot.W,
                Delay = 250,
                Range = 1500,
                Radius = 70,
                MissileSpeed = 1800,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "HeimerdingerWAttack2"
            },
            new SpellDataBase
            {
                DisplayName = "Hextech Micro-Rockets Ult",
                ChampionName = "Heimerdinger",
                SpellName = "disabled/HeimerdingerW",
                Slot = SpellSlot.W,
                Delay = 250,
                Range = 1500,
                Radius = 70,
                MissileSpeed = 1800,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "HeimerdingerWAttack2Ult"
            },
            new SpellDataBase
            {
                DisplayName = "CH-2 Electron Storm Grenade",
                ChampionName = "Heimerdinger",
                SpellName = "HeimerdingerE",
                Slot = SpellSlot.E,
                Delay = 325,
                Range = 925,
                Radius = 135,
                MissileSpeed = 1750,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "HeimerdingerESpell"
            },
            new SpellDataBase
            {
                DisplayName = "CH-2 Electron Storm Grenade Ult",
                ChampionName = "Heimerdinger",
                SpellName = "disabled/HeimerdingerE",
                Slot = SpellSlot.E,
                Delay = 325,
                Range = 925,
                Radius = 135,
                MissileSpeed = 1750,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "heimerdingerespell_ult"
            },

            #endregion Heimerdinger

            #region Irelia
            new SpellDataBase
            {
                DisplayName = "ranscendent Blades",
                ChampionName = "Irelia",
                SpellName = "IreliaTranscendentBlades",
                Slot = SpellSlot.R,
                Delay = 0,
                Range = 1200,
                Radius = 65,
                MissileSpeed = 1600,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "ireliatranscendentbladesspell"
            },

            #endregion Irelia

            #region Janna
            new SpellDataBase
            {
                DisplayName = "Howling Gale",
                ChampionName = "Janna",
                SpellName = "//HowlingGale",
                Slot = SpellSlot.Q,
                Delay = 0,
                Range = 1700,
                Radius = 120,
                MissileSpeed = 900,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "HowlingGaleSpell"
            },

            #endregion Janna

            #region JarvanIV
            new SpellDataBase
            {
                DisplayName = "Dragon Strike",
                ChampionName = "JarvanIV",
                SpellName = "JarvanIVDragonStrike",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 845,
                Radius = 80,
                MissileSpeed = 2000,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "JarvanIVDragonStrike"
            },
            new SpellDataBase
            {
                DisplayName = "Dragon Strike EQ",
                ChampionName = "JarvanIVEQ",
                SpellName = "JarvanIVDragonStrike2",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 845,
                Radius = 120,
                MissileSpeed = 1800,
                DangerValue = 3,
                IsDangerous = false,
                MissileSpellName = "JarvanIVDragonStrike2"
            },

            #endregion JarvanIV

            #region Jayce

            new SpellDataBase
            {
                DisplayName = "Shock Blast",
                ChampionName = "Jayce",
                SpellName = "jayceshockblast",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1050,
                Radius = 70,
                MissileSpeed = 1450,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "JayceShockBlastMis"
            },
            new SpellDataBase
            {
                DisplayName = "Shock Blast Fast",
                ChampionName = "Jayce",
                SpellName = "JayceQAccel",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1170,
                Radius = 70,
                MissileSpeed = 2350,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "JayceShockBlastWallMis"
            },

            #endregion Jayce

            #region Jinx
            new SpellDataBase
            {
                DisplayName = "Zap!",
                ChampionName = "Jinx",
                SpellName = "JinxWMissile",
                Slot = SpellSlot.W,
                Delay = 600,
                Range = 1500,
                Radius = 60,
                MissileSpeed = 3300,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "JinxWMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Super Mega Death Rocket!",
                ChampionName = "Jinx",
                SpellName = "JinxR",
                Slot = SpellSlot.R,
                Delay = 600,
                Range = 25000,
                Radius = 120,
                MissileSpeed = 1700,
                DangerValue = 5,
                IsDangerous = true,
                MissileSpellName = "JinxR"
            },

            #endregion Jinx

            #region Kalista
            new SpellDataBase
            {
                DisplayName = "Pierce",
                ChampionName = "Kalista",
                SpellName = "KalistaMysticShot",
                Slot = SpellSlot.Q,
                Delay = 350,
                Range = 1200,
                Radius = 70,
                MissileSpeed = 2000,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "kalistamysticshotmistrue"
            },

            #endregion Kalista

            #region Karma
            new SpellDataBase
            {
                DisplayName = "Inner Flame",
                ChampionName = "Karma",
                SpellName = "KarmaQ",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1050,
                Radius = 90,
                MissileSpeed = 1700,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "KarmaQMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Soulflare (Mantra)",
                ChampionName = "Karma",
                SpellName = "KarmaQMissileMantra",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1050,
                Radius = 90,
                MissileSpeed = 1700,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "KarmaQMissileMantra"
            },

            #endregion Karma

            #region Karthus
            new SpellDataBase
            {
                DisplayName = "Lay Waste",
                ChampionName = "Karthus",
                SpellName = "KarthusLayWasteA1",
                Slot = SpellSlot.Q,
                Delay = 625,
                Range = 875,
                Radius = 190,
                MissileSpeed = 0,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "KarthusLayWasteA1"
            },

            #endregion Karthus

            #region Kassadin
            new SpellDataBase
            {
                DisplayName = "Riftwalk",
                ChampionName = "Kassadin",
                SpellName = "RiftWalk",
                Slot = SpellSlot.R,
                Delay = 250,
                Range = 700,
                Radius = 270,
                MissileSpeed = 0,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "RiftWalk"
            },

            #endregion Kassadin

            #region Kennen
            new SpellDataBase
            {
                DisplayName = "Thundering Shuriken",
                ChampionName = "Kennen",
                SpellName = "KennenShurikenHurlMissile1",
                Slot = SpellSlot.Q,
                Delay = 125,
                Range = 1175,
                Radius = 50,
                MissileSpeed = 1700,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "KennenShurikenHurlMissile1"
            },

            #endregion Kennen

            #region Khazix
            new SpellDataBase
            {
                DisplayName = "Void Spike",
                ChampionName = "Khazix",
                SpellName = "KhazixW",
                Slot = SpellSlot.W,
                Delay = 250,
                Range = 1100,
                Radius = 70,
                MissileSpeed = 1700,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "KhazixWMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Void Spike Evolved",
                ChampionName = "Khazix",
                SpellName = "khazixwlong",
                Slot = SpellSlot.W,
                Delay = 250,
                Range = 1025,
                Radius = 70,
                MissileSpeed = 1700,
                DangerValue = 2,
                IsDangerous = false,
                ExtraMissiles = 2,
                MissileSpellName = "khazixwlong"
            },

            #endregion Khazix

            #region KogMaw
            new SpellDataBase
            {
                DisplayName = "Caustic Spittle",
                ChampionName = "KogMaw",
                SpellName = "KogMawQ",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1125,
                Radius = 70,
                MissileSpeed = 1650,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "KogMawQMis"
            },
            new SpellDataBase
            {
                DisplayName = "Void Ooze",
                ChampionName = "KogMaw",
                SpellName = "KogMawVoidOoze",
                Slot = SpellSlot.E,
                Delay = 250,
                Range = 1360,
                Radius = 120,
                MissileSpeed = 1400,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "KogMawVoidOozeMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Living Artillery",
                ChampionName = "KogMaw",
                SpellName = "KogMawLivingArtillery",
                Slot = SpellSlot.R,
                Delay = 1100,
                Range = 2200,
                Radius = 235,
                MissileSpeed = 0,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "KogMawLivingArtillery"
            },

            #endregion KogMaw

            #region LeBlanc
            new SpellDataBase
            {
                DisplayName = "Distortion",
                ChampionName = "Leblanc",
                SpellName = "LeblancSlide",
                Slot = SpellSlot.W,
                Delay = 250,
                Range = 725,
                Radius = 250,
                MissileSpeed = 1600,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "LeblancSlide"
            },
            new SpellDataBase
            {
                DisplayName = "Ethereal Chains",
                ChampionName = "Leblanc",
                SpellName = "LeblancSoulShackle",
                Slot = SpellSlot.E,
                Delay = 250,
                Range = 960,
                Radius = 70,
                MissileSpeed = 1600,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "LeblancSoulShackle"
            },
            new SpellDataBase
            {
                DisplayName = "Distortion (Mimic)",
                ChampionName = "Leblanc",
                SpellName = "LeblancSlideM",
                Slot = SpellSlot.R,
                Delay = 250,
                Range = 725,
                Radius = 250,
                MissileSpeed = 1600,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "LeblancSlideM"
            },

            new SpellDataBase
            {
                DisplayName = "Ethereal Chains (Mimic)",
                ChampionName = "Leblanc",
                SpellName = "LeblancSoulShackleM",
                Slot = SpellSlot.R,
                Delay = 250,
                Range = 960,
                Radius = 70,
                MissileSpeed = 1600,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "LeblancSoulShackleM"
            },

            #endregion LeBlanc

            #region LeeSin
            new SpellDataBase
            {
                DisplayName = "Sonic Wave",
                ChampionName = "LeeSin",
                SpellName = "BlindMonkQOne",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1100,
                Radius = 60,
                MissileSpeed = 1800,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "BlindMonkQOne"
            },

            #endregion LeeSin

            #region Leona
            new SpellDataBase
            {
                DisplayName = "Zenith Blade",
                ChampionName = "Leona",
                SpellName = "LeonaZenithBlade",
                Slot = SpellSlot.E,
                Delay = 350,
                Range = 975,
                Radius = 70,
                MissileSpeed = 2000,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "FlashFrostSpell"
            },
            new SpellDataBase
            {
                DisplayName = "Solar Flare",
                ChampionName = "Leona",
                SpellName = "LeonaSolarFlare",
                Slot = SpellSlot.R,
                Delay = 625,
                Range = 1200,
                Radius = 250,
                MissileSpeed = 0,
                DangerValue = 5,
                IsDangerous = true,
                MissileSpellName = "LeonaSolarFlare"
            },

            #endregion Leona

            #region Lissandra
            new SpellDataBase
            {
                DisplayName = "Ice Shard",
                ChampionName = "Lissandra",
                SpellName = "LissandraQ",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 825,
                Radius = 75,
                MissileSpeed = 2200,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "LissandraQ"
            },

            #endregion Lissandra

            #region Lucian
            new SpellDataBase
            {
                DisplayName = "Piercing Light",
                ChampionName = "Lucian",
                SpellName = "LucianQ",
                Slot = SpellSlot.Q,
                Delay = 450,
                Range = 1140,
                Radius = 65,
                MissileSpeed = 0,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "LucianQ",
                AddHitbox = false
            },
            new SpellDataBase
            {
                DisplayName = "Ardent Blaze",
                ChampionName = "Lucian",
                SpellName = "LucianW",
                Slot = SpellSlot.W,
                Delay = 250,
                Range = 1000,
                Radius = 80,
                MissileSpeed = 1600,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "LucianW"
            },

            #endregion Lucian

            #region Lulu
            new SpellDataBase
            {
                DisplayName = "Glitterlance",
                ChampionName = "Lulu",
                SpellName = "LuluQ",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 925,
                Radius = 80,
                MissileSpeed = 1450,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "LuluQMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Glitterlance Pix",
                ChampionName = "Lulu",
                SpellName = "LuluQPix",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 925,
                Radius = 80,
                MissileSpeed = 1450,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "LuluQMissileTwo"
            },

            #endregion Lulu

            #region Lux
            new SpellDataBase
            {
                DisplayName = "Light Binding",
                ChampionName = "Lux",
                SpellName = "LuxLightBinding",
                Slot = SpellSlot.Q,
                SkillShotType = SkillShotType.Linear,
                Delay = 250,
                Range = 1300,
                Radius = 70,
                MissileSpeed = 1200,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "LuxLightBindingMis"
            },
            new SpellDataBase
            {
                DisplayName = "Lucent Singularity",
                ChampionName = "Lux",
                SpellName = "LuxLightStrikeKugel",
                Slot = SpellSlot.E,
                SkillShotType = SkillShotType.Circular,
                Delay = 250,
                Range = 1100,
                Radius = 340,
                MissileSpeed = 1400,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "LuxLightStrikeKugel",
                ToggleParticleName = "Lux_.+_E_tar_aoe_",
            },
            new SpellDataBase
            {
                DisplayName = "Final Spark",
                ChampionName = "Lux",
                SpellName = "LuxMaliceCannon",
                Slot = SpellSlot.R,
                Delay = 1000,
                Range = 3500,
                Radius = 110,
                MissileSpeed = 0,
                DangerValue = 5,
                IsDangerous = true,
                MissileSpellName = "LuxMaliceCannon"
            },

            #endregion Lux

            #region Malphite
            new SpellDataBase
            {
                DisplayName = "Unstoppable Force",
                ChampionName = "Malphite",
                SpellName = "UFSlash",
                Slot = SpellSlot.R,
                Delay = 0,
                Range = 1000,
                Radius = 270,
                MissileSpeed = 1500,
                DangerValue = 5,
                IsDangerous = true,
                MissileSpellName = "UFSlash"
            },

            #endregion Malphite

            #region Morgana
            new SpellDataBase
            {
                DisplayName = "Dark Binding",
                ChampionName = "Morgana",
                SpellName = "DarkBindingMissile",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1300,
                Radius = 80,
                MissileSpeed = 1200,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "DarkBindingMissile"
            },
            //TODO W
            #endregion Morgana

            #region Nami
            new SpellDataBase
            {
                DisplayName = "Aqua Prison",
                ChampionName = "Nami",
                SpellName = "NamiQ",
                Slot = SpellSlot.Q,
                Delay = 950,
                Range = 875,
                Radius = 200,
                MissileSpeed = 0,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "NamiQ"
            },
            new SpellDataBase
            {
                DisplayName = "Tidal Wave",
                ChampionName = "Nami",
                SpellName = "NamiR",
                Slot = SpellSlot.R,
                Delay = 500,
                Range = 2750,
                Radius = 250,
                MissileSpeed = 850,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "NamiRMissile"
            },

            #endregion Nami

            #region Nautilus
            new SpellDataBase
            {
                DisplayName = "Dredge Line",
                ChampionName = "Nautilus",
                SpellName = "NautilusAnchorDrag",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1080,
                Radius = 90,
                MissileSpeed = 2000,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "NautilusAnchorDragMissile"
            },

            #endregion Nautilus

            #region Nidalee
            new SpellDataBase
            {
                DisplayName = "Javelin Toss",
                ChampionName = "Nidalee",
                SpellName = "JavelinToss",
                Slot = SpellSlot.Q,
                SkillShotType = SkillShotType.Linear,
                Delay = 125,
                Range = 1500,
                Radius = 40,
                MissileSpeed = 1300,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "JavelinToss"
            },

            #endregion Nidalee

            #region Nocturne
            new SpellDataBase
            {
                DisplayName = "Duskbringer",
                ChampionName = "Nocturne",
                SpellName = "NocturneDuskbringer",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1125,
                Radius = 60,
                MissileSpeed = 1400,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "NocturneDuskbringer"
            },

            #endregion Nocturne

            #region Orianna
            new SpellDataBase
            {
                DisplayName = "Commnad: Attack",
                ChampionName = "Orianna",
                SpellName = "OrianaIzunaCommand",
                Slot = SpellSlot.Q,
                Delay = 0,
                Range = 2000,
                Radius = 80,
                MissileSpeed = 1200,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "OrianaIzunaCommand"
            },
            new SpellDataBase
            {
                DisplayName = "Command: Dissonance",
                ChampionName = "Orianna",
                SpellName = "OrianaDissonanceCommand",
                Slot = SpellSlot.W,
                Delay = 250,
                Range = 1825,
                Radius = 250,
                MissileSpeed = 0,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "OrianaDissonanceCommand"
            },
            new SpellDataBase
            {
                DisplayName = "Command: Shockwave",
                ChampionName = "Orianna",
                SpellName = "OrianaDetonateCommand",
                Slot = SpellSlot.R,
                Delay = 500,
                Range = 410,
                Radius = 410,
                MissileSpeed = 0,
                DangerValue = 5,
                IsDangerous = true,
                MissileSpellName = "OrianaDetonateCommand"
            },

            #endregion Orianna

            #region Quinn
            new SpellDataBase
            {
                DisplayName = "Blinding Assault",
                ChampionName = "Quinn",
                SpellName = "QuinnQ",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1050,
                Radius = 80,
                MissileSpeed = 1550,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "QuinnQMissile"
            },

            #endregion Quinn

            #region Rengar
            new SpellDataBase
            {
                DisplayName = "Bola Strike",
                ChampionName = "Rengar",
                SpellName = "RengarE",
                Slot = SpellSlot.E,
                Delay = 250,
                Range = 1000,
                Radius = 70,
                MissileSpeed = 1500,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "RengarEFinal"
            },

            #endregion Rengar

            #region Riven
            new SpellDataBase
            {
                DisplayName = "Ki Burst",
                ChampionName = "Riven",
                SpellName = "RivenMartyr",
                Slot = SpellSlot.W,
                Delay = 267,
                Range = 650,
                Radius = 280,
                MissileSpeed = 1500,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "RivenMartyr"
            },

            #endregion Riven

            #region Rumble
            new SpellDataBase
            {
                DisplayName = "Electro-Harpoon",
                ChampionName = "Rumble",
                SpellName = "RumbleGrenade",
                Slot = SpellSlot.E,
                Delay = 250,
                Range = 950,
                Radius = 90,
                MissileSpeed = 2000,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "RumbleGrenade"
            },

            #endregion Rumble

            #region Ryze
            new SpellDataBase
            {
                DisplayName = "Overload",
                ChampionName = "Ryze",
                SpellName = "RyzeQ",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 900,
                Radius = 60,
                MissileSpeed = 1700,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "RyzeQ"
            },

            #endregion Ryze

            #region Sejuani
            new SpellDataBase()
            {
                DisplayName = "Arctic Assault",
                ChampionName = "Sejuani",
                SpellName = "SejuaniArcticAssault",
                Slot = SpellSlot.Q,
                Delay = 0,
                Range = 900,
                Radius = 70,
                MissileSpeed = 1600,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = ""
            },
            new SpellDataBase
            {
                DisplayName = "Glacial Prison",
                ChampionName = "Sejuani",
                SpellName = "SejuaniGlacialPrisonCast",
                Slot = SpellSlot.R,
                Delay = 250,
                Range = 1200,
                Radius = 110,
                MissileSpeed = 1600,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "SejuaniGlacialPrison"
            },

            #endregion Sejuani

            #region Shen
            new SpellDataBase
            {
                DisplayName = "Shadow Dash",
                ChampionName = "Shen",
                SpellName = "ShenShadowDash",
                Slot = SpellSlot.E,
                Delay = 0,
                Range = 1600,
                Radius = 75,
                MissileSpeed = 1250,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "ShenShadowDash"
            },

            #endregion Shen

            #region Shyvana
            new SpellDataBase
            {
                DisplayName = "Flame Breath",
                ChampionName = "Shyvana",
                SpellName = "ShyvanaFireball",
                Slot = SpellSlot.E,
                Delay = 0,
                Range = 950,
                Radius = 60,
                MissileSpeed = 1700,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "ShyvanaFireball"
            },
            new SpellDataBase
            {
                DisplayName = "Dragon's Descent",
                ChampionName = "Shyvana",
                SpellName = "ShyvanaTransformCast",
                Slot = SpellSlot.R,
                Delay = 250,
                Range = 1000,
                Radius = 160,
                MissileSpeed = 1500,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "ShyvanaTransformCast"
            },

            #endregion Shyvana

            #region Sion
            new SpellDataBase
            {
                DisplayName = "Roar of the Slayer",
                ChampionName = "Sion",
                SpellName = "SionE",
                Slot = SpellSlot.E,
                Delay = 250,
                Range = 800,
                Radius = 80,
                MissileSpeed = 1800,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "SionEMissile"
            },

            #endregion Sion

            #region Sivir
            new SpellDataBase
            {
                DisplayName = "Boomerang Blade",
                ChampionName = "Sivir",
                SpellName = "SivirQ",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1275,
                Radius = 100,
                MissileSpeed = 1350,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "SivirQMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Boomerang Blade (return)",
                ChampionName = "Sivir",
                SpellName = "SivirQReturn",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1275,
                Radius = 100,
                MissileSpeed = 1350,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "SivirQMissileReturn"
            },

            #endregion Sivir

            #region Skarner
            new SpellDataBase
            {
                DisplayName = "Fracture",
                ChampionName = "Skarner",
                SpellName = "SkarnerFracture",
                Slot = SpellSlot.E,
                Delay = 250,
                Range = 1000,
                Radius = 60,
                MissileSpeed = 1400,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "SkarnerFractureMissile"
            },

            #endregion Skarner

            #region Sona
            new SpellDataBase
            {
                DisplayName = "Crescendo",
                ChampionName = "Sona",
                SpellName = "SonaR",
                Slot = SpellSlot.R,
                Delay = 250,
                Range = 1000,
                Radius = 150,
                MissileSpeed = 2400,
                DangerValue = 5,
                IsDangerous = true,
                MissileSpellName = "SonaR"
            },

            #endregion Sona

            #region Soraka
            new SpellDataBase
            {
                DisplayName = "Starcall",
                ChampionName = "Soraka",
                SpellName = "SorakaQ",
                Slot = SpellSlot.Q,
                Delay = 500,
                Range = 970,
                Radius = 260,
                MissileSpeed = 1100,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "SorakaQ"
            },

            #endregion Soraka

            #region Swain
            new SpellDataBase
            {
                DisplayName = "Nevermove",
                ChampionName = "Swain",
                SpellName = "SwainShadowGrasp",
                Slot = SpellSlot.W,
                Delay = 1100,
                Range = 900,
                Radius = 200,
                MissileSpeed = 0,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "SwainShadowGrasp"
            },

            #endregion Swain

            #region Syndra
            new SpellDataBase
            {
                DisplayName = "Dark Sphere",
                ChampionName = "Syndra",
                SpellName = "SyndraQ",
                Slot = SpellSlot.Q,
                Delay = 600,
                Range = 800,
                Radius = 210,
                MissileSpeed = 0,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "SyndraQ"
            },
            new SpellDataBase
            {
                DisplayName = "Force of Will",
                ChampionName = "Syndra",
                SpellName = "syndrawcast",
                Slot = SpellSlot.W,
                Delay = 0,
                Range = 925,
                Radius = 220,
                MissileSpeed = 1450,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "syndrawcast"
            },

            #endregion Syndra

            #region Taliyah
            new SpellDataBase
            {
                DisplayName = "Taliyah Q",
                ChampionName = "Taliyah",
                SpellName = "TaliyahQ",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1000,
                Radius = 100,
                MissileSpeed = 3600,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "TaliyahQMis"
            },
            new SpellDataBase
            {
                DisplayName = "Taliyah W",
                ChampionName = "Taliyah",
                SpellName = "TaliyahW",
                Slot = SpellSlot.W,
                Delay = 600,
                Range = 900,
                Radius = 200,
                MissileSpeed = int.MaxValue,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "TaliyahW"
            },

            #endregion Taliyah

            #region TahmKench
            new SpellDataBase
            {
                DisplayName = "Tongue Lash",
                ChampionName = "TahmKench",
                SpellName = "TahmKenchQ",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 951,
                Radius = 90,
                MissileSpeed = 2000,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "tahmkenchqmissile"
            },

            #endregion TahmKench

            #region Thresh
            new SpellDataBase
            {
                DisplayName = "Death Sentence",
                ChampionName = "Thresh",
                SpellName = "ThreshQ",
                Slot = SpellSlot.Q,
                Delay = 500,
                Range = 1200,
                Radius = 70,
                MissileSpeed = 1900,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "ThreshQMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Flay",
                ChampionName = "Thresh",
                SpellName = "ThreshE",
                Slot = SpellSlot.E,
                Delay = 125,
                Range = 1075,
                Radius = 110,
                MissileSpeed = 2000,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "ThreshEMissile1"
            },

            #endregion Thresh

            #region TwistedFate
            new SpellDataBase
            {
                DisplayName = "Wild Cards",
                ChampionName = "TwistedFate",
                SpellName = "disabled/WildCards",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 1450,
                Radius = 40,
                MissileSpeed = 1000,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "SealFateMissile"
            },

            #endregion TwistedFate

            #region Urgot

            new SpellDataBase
            {
                DisplayName = "Acid Hunter",
                ChampionName = "Urgot",
                SpellName = "UrgotHeatseekingLineMissile",
                Slot = SpellSlot.Q,
                Delay = 125,
                Range = 1000,
                Radius = 60,
                MissileSpeed = 1600,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "UrgotHeatseekingLineMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Noxian Corrosive Charge",
                ChampionName = "Urgot",
                SpellName = "UrgotPlasmaGrenade",
                Slot = SpellSlot.E,
                Delay = 250,
                Range = 900,
                Radius = 250,
                MissileSpeed = 1500,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "UrgotPlasmaGrenadeBoom"
            },

            #endregion Urgot

            #region Varus
            new SpellDataBase
            {
                DisplayName = "Piercing Arrow",
                ChampionName = "Varus",
                SpellName = "disabled/varusq",
                Slot = SpellSlot.Q,
                Delay = 0,
                Range = 1600,
                Radius = 75,
                MissileSpeed = 1900,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "VarusQMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Hail of Arrows",
                ChampionName = "Varus",
                SpellName = "VarusE",
                Slot = SpellSlot.E,
                Delay = 1000,
                Range = 925,
                Radius = 235,
                MissileSpeed = 1500,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "VarusE"
            },
            new SpellDataBase
            {
                DisplayName = "Chain of Corruption",
                ChampionName = "Varus",
                SpellName = "VarusR",
                Slot = SpellSlot.R,
                Delay = 250,
                Range = 1200,
                Radius = 100,
                MissileSpeed = 1950,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "VarusRMissile"
            },

            #endregion Varus          
              
            #region Veigar
            new SpellDataBase
            {
                DisplayName = "Baleful Strike",
                ChampionName = "Veigar",
                SpellName = "VeigarBalefulStrike",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 950,
                Radius = 70,
                MissileSpeed = 2000,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "VeigarBalefulStrikeMis"
            },
            new SpellDataBase
            {
                DisplayName = "Dark Matter",
                ChampionName = "Veigar",
                SpellName = "VeigarDarkMatter",
                Slot = SpellSlot.W,
                Delay = 1350,
                Range = 900,
                Radius = 225,
                MissileSpeed = 0,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "VeigarDarkMatter"
            },

            #endregion Veigar

            #region Velkoz
            new SpellDataBase
            {
                DisplayName = "Plasma Fission (split)",
                ChampionName = "Velkoz",
                SpellName = "VelkozQMissileSplit",
                Slot = SpellSlot.Q,
                Delay = 0,
                Range = 900,
                Radius = 90,
                MissileSpeed = 2100,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "VelkozQMissileSplit"
            },
            new SpellDataBase
            {
                DisplayName = "Plasma Fission",
                ChampionName = "Velkoz",
                SpellName = "VelkozQ",
                Slot = SpellSlot.Q,
                Delay = 0,
                Range = 1200,
                Radius = 90,
                MissileSpeed = 1300,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "VelkozQMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Void Rift",
                ChampionName = "Velkoz",
                SpellName = "VelkozW",
                Slot = SpellSlot.W,
                Delay = 250,
                Range = 1100,
                Radius = 90,
                MissileSpeed = 1700,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "VelkozW"
            },
            new SpellDataBase
            {
                DisplayName = "Tectonic Disruption",
                ChampionName = "Velkoz",
                SpellName = "VelkozE",
                Slot = SpellSlot.E,
                Delay = 500,
                Range = 950,
                Radius = 225,
                MissileSpeed = 1500,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "VelkozEMissile"
            },

            #endregion Velkoz

            #region Vi
            new SpellDataBase
            {
                ChampionName = "Vi",
                SpellName = "ViQMissile",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 725,
                Radius = 90,
                MissileSpeed = 1500,
                DangerValue = 3,
                MissileSpellName = "ViQMissile"
            },

            #endregion Vi

            #region Vladimir
            new SpellDataBase
            {
                DisplayName = "Hemoplague",
                ChampionName = "Vladimir",
                SpellName = "VladimirHemoplague",
                Slot = SpellSlot.R,
                Delay = 389,
                Range = 700,
                Radius = 375,
                MissileSpeed = 0,
                DangerValue = 3,
                IsDangerous = false,
                MissileSpellName = "VladimirHemoplague"
            },

            #endregion Vladimir

            #region Xerath
            new SpellDataBase
            {
                DisplayName = "Arcanopulse",
                ChampionName = "Xerath",
                SpellName = "xeratharcanopulse2",
                Slot = SpellSlot.Q,
                Delay = 500,
                Range = 1525,
                Radius = 80,
                MissileSpeed = 0,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "xeratharcanopulse2"
            },
            new SpellDataBase
            {
                DisplayName = "Eye of Destruction",
                ChampionName = "Xerath",
                SpellName = "XerathArcaneBarrage2",
                Slot = SpellSlot.W,
                Delay = 700,
                Range = 1100,
                Radius = 270,
                MissileSpeed = 0,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "XerathArcaneBarrage2"
            },
            new SpellDataBase
            {
                DisplayName = "Shocking Orb",
                ChampionName = "Xerath",
                SpellName = "XerathMageSpear",
                Slot = SpellSlot.E,
                Delay = 200,
                Range = 1125,
                Radius = 60,
                MissileSpeed = 1400,
                DangerValue = 2,
                IsDangerous = true,
                MissileSpellName = "XerathMageSpearMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Rite of the Arcane",
                ChampionName = "Xerath",
                SpellName = "xerathrmissilewrapper",
                Slot = SpellSlot.R,
                Delay = 700,
                Range = 5600,
                Radius = 200,
                MissileSpeed = 0,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "xerathrmissilewrapper"
            },

            #endregion Xerath

            #region Yasuo
            new SpellDataBase
            {
                DisplayName = "Steel Tempest (tornado)",
                ChampionName = "Yasuo",
                SpellName = "YasuoQ3/disabled",
                Slot = SpellSlot.Q,
                Delay = 400,
                Range = 1150,
                Radius = 90,
                MissileSpeed = 1500,
                DangerValue = 3,
                MissileSpellName = "YasuoQ3Mis"
            },

            #endregion Yasuo

            #region Zed
            new SpellDataBase
            {
                DisplayName = "Razor Shuriken",
                ChampionName = "Zed",
                SpellName = "ZedQ",
                Slot = SpellSlot.Q,
                Delay = 300,
                Range = 925,
                Radius = 50,
                MissileSpeed = 1700,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "ZedQMissile"
            },

            #endregion Zed

            #region Ziggs
            new SpellDataBase
            {
                DisplayName = "Bouncing Bomb",
                ChampionName = "Ziggs",
                SpellName = "ZiggsQ",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 850,
                Radius = 150,
                MissileSpeed = 1700,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "ZiggsQSpell"
            },
            new SpellDataBase
            {
                DisplayName = "Mega Inferno Bomb",
                ChampionName = "Ziggs",
                SpellName = "ZiggsR",
                Slot = SpellSlot.R,
                Delay = 1500,
                Range = 5300,
                Radius = 550,
                MissileSpeed = 1500,
                DangerValue = 3,
                MissileSpellName = "ZiggsR"
            },

            #endregion Ziggs

            #region Zilean
            new SpellDataBase
            {
                DisplayName = "Time Bomb",
                ChampionName = "Zilean",
                SpellName = "ZileanQ",
                Slot = SpellSlot.Q,
                Delay = 300,
                Range = 900,
                Radius = 250,
                MissileSpeed = 2000,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "ZileanQ"
            },

            #endregion Zilean

            #region Zyra
            new SpellDataBase
            {
                DisplayName = "Rampant Growth",
                ChampionName = "Zyra",
                SpellName = "ZyraQFissure",
                Slot = SpellSlot.Q,
                Delay = 800,
                Range = 825,
                Radius = 260,
                MissileSpeed = 0,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "ZyraQFissure"
            },
            new SpellDataBase
            {
                DisplayName = "Grasping Roots",
                ChampionName = "Zyra",
                SpellName = "ZyraE",
                Slot = SpellSlot.E,
                Delay = 250,
                Range = 1150,
                Radius = 70,
                MissileSpeed = 1150,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "ZyraEMissile"
            },
            new SpellDataBase
            {
                DisplayName = "Stranglethorns",
                ChampionName = "Zyra",
                SpellName = "ZyraBrambleZone",
                Slot = SpellSlot.R,
                Delay = 500,
                Range = 700,
                Radius = 525,
                MissileSpeed = 0,
                DangerValue = 5,
                IsDangerous = true,
                MissileSpellName = "ZyraBrambleZone"
            },

            #endregion Zyra

            #region Illaoi
            new SpellDataBase
            {
                DisplayName = "Tentacle Smash",
                ChampionName = "Illaoi",
                SpellName = "IllaoiQ",
                Slot = SpellSlot.Q,
                Delay = 750,
                Range = 850,
                Radius = 100,
                MissileSpeed = 0,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "illaoiemis"
            },
            new SpellDataBase
            {
                DisplayName = "Test of Spirit",
                ChampionName = "Illaoi",
                SpellName = "IllaoiE",
                Slot = SpellSlot.E,
                Delay = 250,
                Range = 950,
                Radius = 50,
                MissileSpeed = 1900,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "illaoiemis"
            },

            #endregion Illaoi

            #region Graves
            new SpellDataBase
            {
                DisplayName = "End of the Line",
                ChampionName = "Graves",
                SpellName = "GravesQLineSpell",
                Slot = SpellSlot.Q,
                Delay = 250,
                Range = 808,
                Radius = 40,
                MissileSpeed = 3000,
                DangerValue = 2,
                IsDangerous = false,
                MissileSpellName = "GravesQLineMis"
            },

            #endregion Graves

            #region Poppy
            new SpellDataBase
                    {
                        DisplayName = "Hammer Shock",
                        ChampionName = "Poppy",
                        SpellName = "PoppyQ",
                        Slot = SpellSlot.Q,
                        Delay = 500,
                        Range = 430,
                        Radius = 100,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = false,
                        MissileSpellName = "PoppyQ"
                    },
            #endregion Poppy

            #region Jhin
            new SpellDataBase
                    {
                        DisplayName = "Deadly Flourish",
                        ChampionName = "Jhin",
                        SpellName = "JhinW",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 3000,
                        Radius = 40,
                        MissileSpeed = 5000,
                        DangerValue = 2,
                        IsDangerous = false,
                        MissileSpellName = "JhinWMissile"
                    },new SpellDataBase
                    {
                        DisplayName = "Curtain Call",
                        ChampionName = "Jhin",
                        SpellName = "JhinRShot",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 3500,
                        Radius = 80,
                        MissileSpeed = 5000,
                        DangerValue = 2,
                        IsDangerous = false,
                        MissileSpellName = "JhinRShotMis"
                    }
            #endregion Jhin

        };
    }
}
