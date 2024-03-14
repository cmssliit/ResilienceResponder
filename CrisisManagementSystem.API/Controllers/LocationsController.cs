
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrisisManagementSystem.API.DataLayer;
using CrisisManagementSystem.API.Application.DTOs.Location;
using AutoMapper;
using CrisisManagementSystem.API.Application.IRepository;
using CrisisManagementSystem.API.Application.DTOs.User;

namespace CrisisManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepository;

        //since we register our dbcontext with builder.services in program.cs
        //it geives the ability to inject almost anyfile wewant
        public LocationsController(IMapper mapper, ILocationRepository locationRepository)
        {
            _mapper = mapper;
            _locationRepository = locationRepository;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetLocationDto>>> GetLocations()
        {
            if (await _locationRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var locations = await _locationRepository.GetAllAsync();

            var getlocations = _mapper.Map<List<GetLocationDto>>(locations);

            return Ok(getlocations);
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            if (await _locationRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var location = await _locationRepository.GetAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, UpdateLocationDto updateLocation)
        {
            if (id != updateLocation.Id)
            {
                return BadRequest();
            }

            // _context.Entry(updateLocation).State = EntityState.Modified;

            var location = await _locationRepository.GetAsync(id);//from this line entity get tracked.
            if (location == null)
            {
                return NotFound();
            }

            _mapper.Map(updateLocation, location); //from this line it get modified

            try
            {
                await _locationRepository.UpdateAsync(location);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await LocationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(CreateLocationDto createLocation)
        {
            var location = _mapper.Map<Location>(createLocation);

            await _locationRepository.AddAsync(location);

            return CreatedAtAction("GetLocation", new { id = location.Id }, location);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            if (await _locationRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var location = await _locationRepository.GetAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            await _locationRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> LocationExists(int id)
        {
            return await _locationRepository.Exists(id);
        }
    }
}
