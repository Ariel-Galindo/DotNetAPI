using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    // https://localhost:7295/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _context;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(NZWalksDbContext context, IRegionRepository regionRepository, IMapper mapper)
        {
            this._context = context;
            this._regionRepository = regionRepository;
            this._mapper = mapper;
        }

        // GET ALL REGIONS
        // GET: https://localhost:7295/api/regions
        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain Models
            var regionsDomain = await _regionRepository.GetAllAsync();

            // Map Domain Models to DTOs
            var regionsDto = _mapper.Map<List<RegionDto>>(regionsDomain);

            // Return DTOs
            return Ok(regionsDto);
        }

        // GET SINGLE regionDomain (Get regionDomain By ID)
        // GET: https://localhost:7295/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get Data From Database - Domain Models
            var regionDomain = await _regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Return DTOs
            return Ok(_mapper.Map<RegionDto>(regionDomain));
        }

        // POST To Create New Region
        // POST: https://localhost:7295/api/regions
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map/Convert Region Domain Model to Region DTO
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);

            // Use Domain Model to create Region
            regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);

            // Map Domain model back to DTO
            var regionsDto = _mapper.Map<RegionDto>(regionDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionsDto);
        }

        // Update Region
        // PUT: https://localhost:7295/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDto);

            // Check if region exists
            regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }

        // DELETE Region
        // DELETE: https://localhost:7295/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await _regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}