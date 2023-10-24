using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();

        Category GetCategory(int categoryId);

        ICollection<Pokemon> GetPokemonsByCategory(int categoryId);

        bool CategoryExists(int categoryId);

        
    }
}
