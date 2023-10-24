using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController:Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            
        }


        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            List<CategoryDto> categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(categories);
        }


        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        public IActionResult GetCategory(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId)) return NotFound();
            CategoryDto category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(categoryId));

            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            return Ok(category);

        }


        [HttpGet("{categoryId}/pokemons")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemonsByCategory(int categoryId)
        {
            if(!_categoryRepository.CategoryExists(categoryId)) return NotFound();

            List<PokemonDto> pokemonsByCategory = _mapper.Map<List<PokemonDto>>(_categoryRepository.GetPokemonsByCategory(categoryId));


            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pokemonsByCategory);
        }


    }
}
