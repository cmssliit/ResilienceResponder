
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrisisManagementSystem.API.Application.DTOs.Workflow;
using AutoMapper;
using CrisisManagementSystem.API.Application.IRepository;
using CrisisManagementSystem.API.Application.DTOs.Incident;
using CrisisManagementSystem.API.DataLayer.Entities;

namespace CrisisManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIncidentRepository _incidentRepository;

        //since we register our dbcontext with builder.services in program.cs
        //it geives the ability to inject almost anyfile wewant
        public IncidentsController(IMapper mapper, IIncidentRepository incidentRepository)
        {
            _mapper = mapper;
            _incidentRepository = incidentRepository;
        }

        // GET: api/GetIncidents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetIncidentDto>>> GetIncidents()
        {
            if (await _incidentRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var incidents = await _incidentRepository.GetAllAsync();

            var getIncidents = _mapper.Map<List<GetIncidentDto>>(incidents);


            return Ok(getIncidents);
        }

        // GET: api/Incident/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Incident>> GetIncident(int id)
        {
            if (await _incidentRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var incident = await _incidentRepository.GetAsync(id);

            if (incident == null)
            {
                return NotFound();
            }

            return incident;
        }

        // PUT: api/Incident/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncident(int id, UpdateIncidentDto updateIncident)
        {
            if (id != updateIncident.Id)
            {
                return BadRequest();
            }

            // _context.Entry(updateWorkflow).State = EntityState.Modified;

            var workflow = await _incidentRepository.GetAsync(id);//from this line entity get tracked.
            if (workflow == null)
            {
                return NotFound();
            }

            _mapper.Map(updateIncident, workflow); //from this line it get modified

            try
            {
                await _incidentRepository.UpdateAsync(workflow);
            }
            catch (DbUpdateConcurrencyException exc)
            {
                if (!await IncidentExists(id))
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

        // POST: api/Incidents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Incident>> PostIncident(CreateIncidentDto createIncident)
        {
            var incident = _mapper.Map<Incident>(createIncident);

            await _incidentRepository.AddAsync(incident);

            return CreatedAtAction("GetIncident", new { id = incident.Id }, incident);
        }

        // DELETE: api/Workflows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncident(int id)
        {
            if (await _incidentRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var workflow = await _incidentRepository.GetAsync(id);
            if (workflow == null)
            {
                return NotFound();
            }

            await _incidentRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> IncidentExists(int id)
        {
            return await _incidentRepository.Exists(id);
        }
    }
}