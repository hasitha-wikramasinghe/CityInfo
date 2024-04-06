using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;
        private const int maxPageSize = 20;

        public CitiesController(
            ICityInfoRepository cityInfoRepository,
            IMapper mapper
            )
        {
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(ICityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointOfInterestDto>>> GetCities(
            string? name,
            string? searchQuery,
            int pageNumber = 1,
            int pageSize = 10)
        {
            if (pageSize > maxPageSize)
            {
                pageSize = maxPageSize;
            }

            var (entities, paginationMetadata) = await _cityInfoRepository.GetCitiesAsync(name, searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<CityWithoutPointOfInterestDto>>(entities));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(
            int id,
            bool includePointsOfInterest)
        {
            var city = await _cityInfoRepository.GetCityAsync(id, includePointsOfInterest);
            if (city is null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                return Ok(_mapper.Map<CityDto>(city));
            }
            return Ok(_mapper.Map<CityWithoutPointOfInterestDto>(city));
        }
    }
}