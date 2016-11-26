using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using AutoJanna.Bases;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Spells;

using static AutoJanna.Misc.Helper;

namespace AutoJanna.Managers
{
    public static class DangerManager
    {
        private static List<MyMissile> Missiles;
        private static List<Geometry.Polygon> Polygons;

        public static void LoadDangerHandler()
        {
            Missiles = new List<MyMissile>();
            Polygons = new List<Geometry.Polygon>();

            GameObject.OnCreate += GameObject_OnCreate;
            GameObject.OnDelete += GameObject_OnDelete;

            var timer = new Timer(60);
            timer.Start();
            timer.Elapsed += Timer_Elapsed;
        }

        public static void DrawSpells(Color color)
        {
            foreach (var polygon in Polygons)
            {
                polygon.Draw(Color.Black, 6);
            }

            foreach (var missile in Missiles)
            {
                missile.Missile.DrawCircle((int)missile.SpellInfo.Radius, Color.Black, 5f);
            }
        }
        
        public static bool IsInDanger(this AIHeroClient target, int range = 250, int hPercent = 30)
        {
            return Missiles.Any(m => m.Polygon.IsInside(target) && m.Missile.Position.IsInRange(target, range));
        }

        private static void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            var missile = sender as MissileClient;
            if (missile == null || missile.IsAutoAttack()) return;

            var spellsInfo = SpellDatabase.GetSpellInfoList(missile.SpellCaster);

            if (spellsInfo == null) return;

            var missileInfo = spellsInfo.FirstOrDefault(m => (int)m.Slot == (int)missile.Slot);

            if (missileInfo == null)
            {
                if (MenuVariables.DebugMissiles)
                {
                    Console.WriteLine(missile.SpellCaster.BaseSkinName + ", Missile Name = " + missile.SData.Name + ", Slot = " + missile.Slot + " [NULL]");
                }
                
                return;
            }

            var myMiss = new MyMissile(missile, missileInfo);

            Missiles.Add(myMiss);
            UpdatePolygons();
        }

        private static void GameObject_OnDelete(GameObject sender, EventArgs args)
        {
            var missile = sender as MissileClient;
            if (missile == null || missile.IsAutoAttack()) return;

            var missileFromList =
                Missiles.FirstOrDefault(
                    m =>
                        m.Missile.Slot == missile.Slot &&
                        m.Missile.SpellCaster.Name.ToLower() == missile.SpellCaster.Name.ToLower());

            if (missileFromList == null) return;

            Missiles.Remove(missileFromList);

            UpdatePolygons();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            UpdatePolygons();
        }

        private static void UpdatePolygons()
        {
            Polygons = new List<Geometry.Polygon>();

            foreach (var myMissile in Missiles)
            {
                var missile = myMissile.Missile;
                var info = myMissile.SpellInfo;

                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (info.Type)
                {
                    case SpellType.Self:
                        return;
                    case SpellType.Circle:
                        var polygonCircle = new Geometry.Polygon.Circle(missile.Position,
                            myMissile.SpellInfo.Radius, 80);
                        myMissile.Polygon = polygonCircle;

                        Polygons.Add(polygonCircle);
                        return;
                    case SpellType.Line:
                        var polygonLine = new Geometry.Polygon.Line(missile.StartPosition, missile.EndPosition, 5f);
                        myMissile.Polygon = polygonLine;

                        Polygons.Add(polygonLine);
                        return;
                    case SpellType.Cone:
                        var polygonCone = new Geometry.Polygon.Sector(missile.StartPosition, missile.EndPosition, info.Radius, info.Range, 80);
                        myMissile.Polygon = polygonCone;

                        Polygons.Add(polygonCone);
                        return;
                    case SpellType.Ring:
                        return;
                    case SpellType.Arc:
                        return;
                    case SpellType.MissileLine:
                        var polygonMissileLine = new Geometry.Polygon.Line(missile.StartPosition, missile.EndPosition, 5f);
                        myMissile.Polygon = polygonMissileLine;

                        Polygons.Add(polygonMissileLine);
                        return;
                    case SpellType.MissileAoe:
                        var polygonMissileAOE = new Geometry.Polygon.Circle(missile.EndPosition, 5f);
                        myMissile.Polygon = polygonMissileAOE;

                        Polygons.Add(polygonMissileAOE);
                        return;
                }
            }

            Polygons = Polygons.JoinPolygons();
        }
    }
}
