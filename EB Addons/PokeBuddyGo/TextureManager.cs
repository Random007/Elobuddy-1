using System.Drawing;
using EloBuddy.SDK.Rendering;

using Sprite = EloBuddy.SDK.Rendering.Sprite;

namespace PokeBuddyGo
{
    public static class TextureManager
    {
        public static TextureLoader TLoader;

        public static void Load()
        {
            TLoader = new TextureLoader();
        }

        public static Sprite LoadSprite(Pokemons pokemon, Bitmap bitmap)
        {
            TLoader.Load(pokemon.ToString(), Resources.Bulbasaur);
            return new Sprite(() => TLoader[pokemon.ToString()]);
        }
    }
}
