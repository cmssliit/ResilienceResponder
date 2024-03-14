
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrisisManagementSystem.API.DataLayer;
using CrisisManagementSystem.API.Application.DTOs.WorkFlowtaskExecution;
using AutoMapper;
using CrisisManagementSystem.API.Application.IRepository;
using CrisisManagementSystem.API.Application.DTOs.User;

namespace CrisisManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkFlowtaskExecutionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWorkFlowtaskExecutionRepository _workFlowtaskExecutionRepository;

        //since we register our dbcontext with builder.services in program.cs
        //it geives the ability to inject almost anyfile wewant
        public WorkFlowtaskExecutionsController(IMapper mapper, IWorkFlowtaskExecutionRepository workFlowtaskExecutionRepository)
        {
            _mapper = mapper;
            _workFlowtaskExecutionRepository = workFlowtaskExecutionRepository;
        }

        // GET: api/WorkFlowtaskExecutions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetWorkFlowtaskExecutionDto>>> GetWorkFlowtaskExecutions()
        {
            if (await _workFlowtaskExecutionRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var workFlowtaskExecutions = await _workFlowtaskExecutionRepository.GetAllAsync();

            var getworkFlowtaskExecutions = _mapper.Map<List<GetWorkFlowtaskExecutionDto>>(workFlowtaskExecutions);

            return Ok(getworkFlowtaskExecutions);
        }

        // GET: api/WorkFlowtaskExecutions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkFlowtaskExecution>> GetWorkFlowtaskExecution(int id)
        {
            if (await _workFlowtaskExecutionRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var workFlowtaskExecution = await _workFlowtaskExecutionRepository.GetAsync(id);

            if (workFlowtaskExecution == null)
            {
                return NotFound();
            }

            return workFlowtaskExecution;
        }

        // PUT: api/WorkFlowtaskExecutions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkFlowtaskExecution(int id, UpdateWorkFlowtaskExecutionDto updateWorkFlowtaskExecution)
        {
            if (id != updateWorkFlowtaskExecution.Id)
            {
                return BadRequest();
            }

            // _context.Entry(updateWorkFlowtaskExecution).State = EntityState.Modified;

            var workFlowtaskExecution = await _workFlowtaskExecutionRepository.GetAsync(id);//from this line entity get tracked.
            if (workFlowtaskExecution == null)
            {
                return NotFound();
            }

            _mapper.Map(updateWorkFlowtaskExecution, workFlowtaskExecution); //from this line it get modified

            try
            {
                await _workFlowtaskExecutionRepository.UpdateAsync(workFlowtaskExecution);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await WorkFlowtaskExecutionExists(id))
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

        // POST: api/WorkFlowtaskExecutions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkFlowtaskExecution>> PostWorkFlowtaskExecution(CreateWorkFlowtaskExecutionDto createWorkFlowtaskExecution)
        {
            var workFlowtaskExecution = _mapper.Map<WorkFlowtaskExecution>(createWorkFlowtaskExecution);

            await _workFlowtaskExecutionRepository.AddAsync(workFlowtaskExecution);

            return CreatedAtAction("GetWorkFlowtaskExecution", new { id = workFlowtaskExecution.Id }, workFlowtaskExecution);
        }

        // DELETE: api/WorkFlowtaskExecutions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkFlowtaskExecution(int id)
        {
            if (await _workFlowtaskExecutionRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var workFlowtaskExecution = await _workFlowtaskExecutionRepository.GetAsync(id);
            if (workFlowtaskExecution == null)
            {
                return NotFound();
            }

            await _workFlowtaskExecutionRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> WorkFlowtaskExecutionExists(int id)
        {
            return await _workFlowtaskExecutionRepository.Exists(id);
        }
    }
}