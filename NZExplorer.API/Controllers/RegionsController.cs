using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZExplorer.API.Dtos;
using NZExplorer.API.Models;
using NZExplorer.API.Repositories.interfaces;

namespace NZExplorer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRegionRepository _regionRepository;

        public RegionsController(IMapper mapper, IRegionRepository regionRepository)
        {
            _mapper = mapper;
            _regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {

            var regions = await _regionRepository.GetAllAsync();

            var regionsDto = _mapper.Map<IEnumerable<GetRegion>>(regions);

            return Ok(regionsDto);
        }

        [HttpGet("{id:guid}", Name = "GetRegionById")]
        public async Task<IActionResult> GetRegionAsync([FromRoute] Guid id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDto = _mapper.Map<GetRegion>(region);

            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync([FromBody] AddRegionRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            var region = _mapper.Map<Region>(model);
            region = await _regionRepository.AddAsync(region);
            var regionDTO = _mapper.Map<GetRegion>(region);

            return CreatedAtRoute("GetRegionById", new { id = regionDTO.Id }, regionDTO);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] UpdateRegionRequest model)
        {

            var region = _mapper.Map<Region>(model);

            region = await _regionRepository.UpdateAsync(id, region);

            if (region is null)
                return NotFound();

            var regionDto = _mapper.Map<GetRegion>(region);


            return Ok(regionDto);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegionAsync([FromRoute] Guid id)
        {

            var region = await _regionRepository.DeleteAsync(id);

            if (region is null)
                return NotFound();

            var regionDto = _mapper.Map<GetRegion>(region);

            return Ok(region);
        }

    }


}
