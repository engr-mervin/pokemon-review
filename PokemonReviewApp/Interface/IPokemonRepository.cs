﻿using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int pokemonId);
        Pokemon GetPokemon(string name);

        decimal GetPokemonRating(int pokemonId);

        bool PokemonExists(int pokemonId);
    }
}
