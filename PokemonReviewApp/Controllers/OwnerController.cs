using AutoMapper;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController:Controller
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository ownerRepository,IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<OwnerDto>))]
        public IActionResult GetOwners()
        {
            List<OwnerDto> owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());

            if(!ModelState.IsValid) return BadRequest(ModelState);
            
            return Ok(owners);
        }


        [HttpGet("{ownerId}")]
        [ProducesResponseType(200,Type=typeof(OwnerDto))]
        public IActionResult GetOwner(int ownerId) 
        {
            if (!_ownerRepository.OwnerExists(ownerId)) return NotFound();

            OwnerDto owner = _mapper.Map<OwnerDto>(_ownerRepository.GetOwner(ownerId));


            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(owner);
        }

        [HttpGet("{ownerId}/pokemons")]
        [ProducesResponseType(200,Type=typeof(IEnumerable<PokemonDto>))]
        public IActionResult GetPokemonsByOwner(int ownerId)
        {
            if (!_ownerRepository.OwnerExists(ownerId)) return NotFound();

            List<PokemonDto> pokemons = _mapper.Map<List<PokemonDto>>(_ownerRepository.GetPokemonsByOwner(ownerId));


            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pokemons);
        }


        [HttpGet("{pokemonId}/owners")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OwnerDto>))]
        public IActionResult GetOwnersOfAPokemon(int pokemonId)
        {
            //check if Pokemon exists

            List<OwnerDto> owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwnersOfAPokemon(pokemonId));


            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(owners);

        }
    }
}
