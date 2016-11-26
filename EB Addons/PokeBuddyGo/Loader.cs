using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokeBuddyGo.Bases;

namespace PokeBuddyGo
{
    class Loader
    {
        public static PokemonBase Teste;
        public static void Load()
        {
            DrawingsManager.Load();

            Teste = new PokemonBase(Pokemons.Bulbasaur);
        }
    }
}
