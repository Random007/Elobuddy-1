using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using static BlackYasuo.Helper;
using Color = System.Drawing.Color;

namespace BlackYasuo
{
    internal class WallManager
    {
        internal class YasuoWall
        {
            public Obj_GeneralParticleEmitter ParticleEmitter { get; set; }
            public Geometry.Polygon.Rectangle WallRectangle { get; set; }
            public Vector2 CastedPostion { get; set; }
            public float EndTime { get; set; }

            public YasuoWall()
            {
                var level = Player.GetSpell(SpellSlot.W).Level;
                var wallWidth = (300 + 50 * level);
                var wallDirection = (Wall.ParticleEmitter.Position.To2D() - Wall.CastedPostion).Normalized().Perpendicular();
                var wallStart = Wall.ParticleEmitter.Position.To2D() + wallWidth / 2 * wallDirection;
                var wallEnd = wallStart - wallWidth * wallDirection;
                Wall.WallRectangle = new Geometry.Polygon.Rectangle(wallStart, wallEnd, 75);
            }
        }

        internal static YasuoWall Wall = new YasuoWall();
        internal static int EndTime;

        internal static void Load()
        {
            GameObject.OnCreate += GameObject_OnCreate;
            Game.OnTick += Game_OnTick;
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
            Drawing.OnDraw += delegate(EventArgs args)
            {
                if (Wall.WallRectangle != null)
                {
                    Wall.WallRectangle.Draw(Color.Black, 6);
                }
            };
        }

        private static void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            var particle = sender as Obj_GeneralParticleEmitter;
            if(particle == null)return;
            if (particle.Name.ToLower().Contains("_w_windwall.\\.troy"))
            {
                Wall.ParticleEmitter = particle;
            }
        }

        private static void Game_OnTick(EventArgs args)
        {
            if (EndTime < Environment.TickCount)
            {
                try
                {
                    Wall.ParticleEmitter = null;
                    Wall.WallRectangle = null;
                    Wall = new YasuoWall();
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsValid && sender.Team == ObjectManager.Player.Team && args.SData.Name == "YasuoWMovingWall")
            {
                Wall.CastedPostion = sender.ServerPosition.To2D();
                EndTime = Environment.TickCount + 4000;
            }
        }
    }
}
