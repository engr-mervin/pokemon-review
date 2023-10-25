using PokemonReviewApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonReviewApp.Dto
{
    public class OwnerDto
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gym { get; set; }

        public Country Country { get; set; }

    }
}
