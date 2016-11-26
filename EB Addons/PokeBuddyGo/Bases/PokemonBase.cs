using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy.SDK.Rendering;
using SharpDX;
using SharpDX.Direct3D9;

using Sprite = EloBuddy.SDK.Rendering.Sprite;

namespace PokeBuddyGo.Bases
{
    public class PokemonBase
    {
        public Pokemons Poke { get; private set; }

        private Bitmap Photo;
        private Sprite Sprite;

        public int CP { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }

        public Vector3 Position { get; private set; }

        public List<MoveBase> MoveSet;

        public PokemonBase(Pokemons poke)
        {
            Poke = poke;
            Photo = GetPhoto();
            Sprite = TextureManager.LoadSprite(poke, Photo);
        }

        public bool IsDead => Health <= 0;
        public int EvadeChance => 0;

        private Bitmap GetPhoto()
        {
            var bitMap = (Bitmap)Resources.ResourceManager.GetObject(Poke.ToString());
            if (bitMap == null)
            {
                Console.WriteLine(@"Pokemon image not added");
                return null;
            }
            return new Bitmap(bitMap);
        }

        public void Draw(Vector2 pos)
        {
            Sprite.Draw(pos);
        }
    }
}
