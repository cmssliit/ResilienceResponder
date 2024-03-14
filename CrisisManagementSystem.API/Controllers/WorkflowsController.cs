
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrisisManagementSystem.API.DataLayer;
using CrisisManagementSystem.API.Application.DTOs.Workflow;
using AutoMapper;
using CrisisManagementSystem.API.Application.IRepository;
using CrisisManagementSystem.API.Application.DTOs.User;

namespace CrisisManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWorkflowRepository _workflowRepository;

        //since we register our dbcontext with builder.services in program.cs
        //it geives the ability to inject almost anyfile wewant
        public WorkflowsController(IMapper mapper, IWorkflowRepository workflowRepository)
        {
            _mapper = mapper;
            _workflowRepository = workflowRepository;
        }

        // GET: api/Workflows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetWorkflowDto>>> GetWorkflows()
        {
            if (await _workflowRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var workflows = await _workflowRepository.GetAllAsync();

            var getworkflows = _mapper.Map<List<GetWorkflowDto>>(workflows);

            return Ok(getworkflows);
        }

        // GET: api/Workflows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workflow>> GetWorkflow(int id)
        {
            if (await _workflowRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var workflow = await _workflowRepository.GetAsync(id);

            if (workflow == null)
            {
                return NotFound();
            }

            return workflow;
        }

        // PUT: api/Workflows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkflow(int id, UpdateWorkflowDto updateWorkflow)
        {
            if (id != updateWorkflow.Id)
            {
                return BadRequest();
            }

            // _context.Entry(updateWorkflow).State = EntityState.Modified;

            var workflow = await _workflowRepository.GetAsync(id);//from this line entity get tracked.
            if (workflow == null)
            {
                return NotFound();
            }

            _mapper.Map(updateWorkflow, workflow); //from this line it get modified

            try
            {
                await _workflowRepository.UpdateAsync(workflow);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await WorkflowExists(id))
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

        // POST: api/Workflows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Workflow>> PostWorkflow(CreateWorkflowDto createWorkflow)
        {
            var workflow = _mapper.Map<Workflow>(createWorkflow);

            await _workflowRepository.AddAsync(workflow);

            return CreatedAtAction("GetWorkflow", new { id = workflow.Id }, workflow);
        }

        // DELETE: api/Workflows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkflow(int id)
        {
            if (await _workflowRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var workflow = await _workflowRepository.GetAsync(id);
            if (workflow == null)
            {
                return NotFound();
            }

            await _workflowRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> WorkflowExists(int id)
        {
            return await _workflowRepository.Exists(id);
        }
    }
}