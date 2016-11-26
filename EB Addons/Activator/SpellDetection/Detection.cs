using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using Lib.Bases;
using Lib.Databases;

// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace Activator.SpellDetection
{
    class Detection
    {
        private static Dictionary<MissileClient, SpellDataBase> Missiles = new Dictionary<MissileClient, SpellDataBase>();
        private static Dictionary<MissileClient, Geometry.Polygon> Polygons =new Dictionary<MissileClient, Geometry.Polygon>();

        public static List<Geometry.Polygon> JoinedPolygons = new List<Geometry.Polygon>();

        public static void Load()
        {
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;

            GameObject.OnCreate += GameObject_OnCreate;
            GameObject.OnDelete += GameObject_OnDelete;
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            
        }

        private static void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            var missile = sender as MissileClient;

            if (missile == null || sender.IsAlly || !sender.IsValid) return;

            var hero = missile.SpellCaster as AIHeroClient;

            if (hero == null || hero.IsAlly || !hero.IsValid) return;

            var spell =
                SpellDB.Database.FirstOrDefault(
                    s => s.ChampionName == hero.ChampionName && s.Slot == missile.Slot);

            if (spell == null) return;

            Missiles.Add(missile, spell);

            switch (spell.SkillShotType)
            {
                case SkillShotType.Linear:
                    Polygons.Add(missile,
                        new Geometry.Polygon.Rectangle(missile.StartPosition, missile.EndPosition, spell.Radius));
                    break;
                case SkillShotType.Circular:
                    Polygons.Add(missile, new Geometry.Polygon.Circle(missile.EndPosition, spell.Radius, 50));
                    break;
                case SkillShotType.Cone:
                    Polygons.Add(missile,
                        new Geometry.Polygon.Sector(missile.StartPosition, missile.EndPosition, spell.Radius,
                            spell.Range, 50));
                    break;
            }

            JoinedPolygons = Polygons.Values.ToList().JoinPolygons();
        }

        private static void GameObject_OnDelete(GameObject sender, EventArgs args)
        {
            var missile = sender as MissileClient;
            if (missile == null || sender.IsAlly || !sender.IsValid) return;

            Missiles.Remove(missile);
            Polygons.Remove(missile);

            JoinedPolygons = Polygons.Values.ToList().JoinPolygons();
        }
    }
}
