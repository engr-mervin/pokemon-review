using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface ICountryRepository
    {

        ICollection<Country> GetCountries();

        Country GetCountry(int countryId);

        Country GetCountryByOwner(int ownerId);

        ICollection<Owner> GetOwnersFromCountry(int countryId);

        bool CountryExists(int countryId);
    }
}
