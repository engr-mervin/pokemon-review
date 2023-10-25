using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<CountryDto>))]
        public IActionResult GetCountries()
        {
            List<CountryDto> countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(countries);

        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200,Type=typeof(CountryDto))]
        public IActionResult GetCountry(int countryId)
        {
            if (!_countryRepository.CountryExists(countryId)) return NotFound();

            CountryDto country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(countryId));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet("{countryId}/owners")]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Owner>))]
        public IActionResult GetOwnersFromCountry(int countryId)
        {
            if (!_countryRepository.CountryExists(countryId)) return NotFound();

            List<OwnerDto> owners = _mapper.Map<List<OwnerDto>>(_countryRepository.GetOwnersFromCountry(countryId));


            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(owners);
        }



        [HttpGet("{ownerId}/country")]
        [ProducesResponseType(200,Type=typeof(CountryDto))]
        public IActionResult GetCountryByOwner(int ownerId)
        {
            //Check if Owner exists

            CountryDto country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(ownerId));


            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(country);
        }
    }
}
