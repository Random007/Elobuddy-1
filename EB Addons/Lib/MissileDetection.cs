using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Timers;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Spells;

namespace Lib
{
    public class MissileDetection
    {
        public class MyMissile
        {
            public MissileClient Missile;
            public SpellInfo SpellInfo;
            public Geometry.Polygon Polygon;

            public MyMissile(MissileClient missile, SpellInfo info)
            {
                Missile = missile;
                SpellInfo = info;
            }
        }

        public List<MyMissile> Missiles;
        public List<Geometry.Polygon> Polygons;
        public bool CanDraw;

        public MissileDetection()
        {
            Missiles = new List<MyMissile>();
            Polygons = new List<Geometry.Polygon>();

            CanDraw = true;

            GameObject.OnCreate += GameObject_OnCreate;
            GameObject.OnDelete += GameObject_OnDelete;

            var timer = new Timer(700);
            timer.Start();
            timer.Elapsed += Timer_Elapsed;

            Drawing.OnDraw += Drawing_OnDraw;
        }

        private void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            var missile = sender as MissileClient;
            if (missile == null) return;

            var spellsInfo = SpellDatabase.GetSpellInfoList(missile.SpellCaster);

            if (spellsInfo == null) return;

            var missileInfo = spellsInfo.FirstOrDefault(m => m.Slot == missile.Slot);

            if (missileInfo == null)
            {
                Console.WriteLine(missile.SpellCaster.Name + " " + missile.Slot + " NULL");
                return;
            }

            var myMiss = new MyMissile(missile, missileInfo);

            Missiles.Add(myMiss);
            UpdatePolygons();
        }

        private void GameObject_OnDelete(GameObject sender, EventArgs args)
        {
            var missile = sender as MissileClient;
            if (missile == null) return;

            var missileFromList =
                Missiles.FirstOrDefault(
                    m =>
                        m.Missile.Slot == missile.Slot &&
                        m.Missile.SpellCaster.Name.ToLower() == missile.SpellCaster.Name.ToLower());

            if (missileFromList == null) return;

            Missiles.Remove(missileFromList);

            UpdatePolygons();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            UpdatePolygons();
        }

        private void UpdatePolygons()
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
                        var polygonMissileAOE = new Geometry.Polygon.Line(missile.StartPosition, missile.EndPosition, 5f);
                        myMissile.Polygon = polygonMissileAOE;

                        Polygons.Add(polygonMissileAOE);
                        return;
                }
            }

            Polygons = Polygons.JoinPolygons();
        }

        private void Drawing_OnDraw(EventArgs args)
        {
            if(!CanDraw)return;

            foreach (var polygon in Polygons)
            {
                polygon.Draw(Color.Black, 6);
            }
        }
    }
}
