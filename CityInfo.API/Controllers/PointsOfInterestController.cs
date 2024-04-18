using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsOfInterest")]
    [ApiController]
    [Authorize(Policy = "MustBeFromColombo")]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly ILogger<PointsOfInterestController> _logger;
        private readonly IMailServer _mailServer;
        private readonly IMapper _mapper;
        private readonly ICityInfoRepository _cityInfoRepository;

        public PointsOfInterestController(
            ILogger<PointsOfInterestController> logger,
            IMailServer mailServer,
            IMapper mapper,
            ICityInfoRepository cityInfoRepository
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailServer = mailServer ?? throw new ArgumentNullException(nameof(mailServer));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetPointsOfInterest(
            int cityId)
        {
            var cityName = User.Claims.FirstOrDefault(c => c.Type == "city")?.Value;

            if (!await _cityInfoRepository.IsCityIdMatchingCityName(cityName, cityId))
            {
                return Forbid();
            }

            if (!await _cityInfoRepository.IsCityExists(cityId))
            {
                _logger.LogInformation($"City with id {cityId} wasn't found when trying to access it's point of interest");
                return NotFound();
            }

            var pointsOfInterestForCity = await _cityInfoRepository.GetPointsOfInterestForCityAsync(cityId);
            return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterestForCity));
        }

        [HttpGet("{pointofinterestid}", Name = "GetPointOfInterest")]
        public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(
            int cityId,
            int pointOfInterestId)
        {
            if (!await _cityInfoRepository.IsCityExists(cityId))
            {
                return NotFound();
            }

            var pointOfInterest = await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
            if (pointOfInterest is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PointOfInterestDto>(pointOfInterest));
        }

        [HttpPost]
        public async Task<ActionResult<PointOfInterestDto>> CreatePointOfInterest(
            int cityId,
            PointOfInterestCreationDto pointOfInterest)
        {
            if (!await _cityInfoRepository.IsCityExists(cityId))
            {
                return NotFound($"City with id {cityId} wasn't found when trying to create a point of interest for the city.");
            }

            var pointOfInterestEntity = _mapper.Map<PointOfInterest>(pointOfInterest);

            await _cityInfoRepository.AddPointOfInterestForCity(cityId, pointOfInterestEntity);

            await _cityInfoRepository.SaveChangesAsync();

            var createdPointOfInterestToReturn = _mapper.Map<PointOfInterestDto>(pointOfInterestEntity);

            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    cityId = cityId,
                    pointOfInterestId = createdPointOfInterestToReturn.Id,
                },
                createdPointOfInterestToReturn);
        }

        [HttpPut("{pointOfInterestId}")]
        public async Task<ActionResult> UpdatePointOfInterest(
            int cityId,
            int pointOfInterestId,
            PointOfInterestUpdateDto pointOfInterest)
        {
            if (!await _cityInfoRepository.IsCityExists(cityId))
            {
                return NotFound();
            }

            var existingPointOfInterest = await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
            if (existingPointOfInterest == null)
            {
                return NotFound();
            }

            _mapper.Map(pointOfInterest, existingPointOfInterest);

            await _cityInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{pointOfInterestId}")]
        public async Task<ActionResult> PartiallyUpdatePointOfInterest(
            int cityId,
            int pointOfInterestId,
            JsonPatchDocument<PointOfInterestUpdateDto> patchDoucment)
        {
            if (!await _cityInfoRepository.IsCityExists(cityId))
            {
                return NotFound();
            }

            var pointOfInterest = await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
            if (pointOfInterest is null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = _mapper.Map<PointOfInterestUpdateDto>(pointOfInterest);

            patchDoucment.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(pointOfInterestToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(pointOfInterestToPatch, pointOfInterest);

            await _cityInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{pointOfInterestId}")]
        public async Task<ActionResult> DeletePointOfInterest(
            int cityId,
            int pointOfInterestId)
        {
            if (!await _cityInfoRepository.IsCityExists(cityId))
            {
                return NotFound();
            }

            var pointOfInterest = await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
            if (pointOfInterest is null)
            {
                return NotFound();
            }

            _cityInfoRepository.DeletePointOfInterest(pointOfInterest);
            await _cityInfoRepository.SaveChangesAsync();

            _mailServer.Send(
                "Deletion of point of interest",
                $"Point of interest with the id of {pointOfInterest.Id} which is belongs to city with id {pointOfInterest.CityId} has been deleted..");

            return NoContent();
        }
    }
}