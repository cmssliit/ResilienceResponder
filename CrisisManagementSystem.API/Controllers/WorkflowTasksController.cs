
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrisisManagementSystem.API.DataLayer;
using CrisisManagementSystem.API.Application.DTOs.WorkflowTask;
using AutoMapper;
using CrisisManagementSystem.API.Application.IRepository;
using CrisisManagementSystem.API.Application.DTOs.User;

namespace CrisisManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowTasksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWorkflowTaskRepository _workflowTaskRepository;

        //since we register our dbcontext with builder.services in program.cs
        //it geives the ability to inject almost anyfile wewant
        public WorkflowTasksController(IMapper mapper, IWorkflowTaskRepository workflowTaskRepository)
        {
            _mapper = mapper;
            _workflowTaskRepository = workflowTaskRepository;
        }

        // GET: api/WorkflowTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetWorkflowTaskDto>>> GetWorkflowTasks()
        {
            if (await _workflowTaskRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var workflowTasks = await _workflowTaskRepository.GetAllAsync();

            var getworkflowTasks = _mapper.Map<List<GetWorkflowTaskDto>>(workflowTasks);

            return Ok(getworkflowTasks);
        }

        // GET: api/WorkflowTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkflowTask>> GetWorkflowTask(int id)
        {
            if (await _workflowTaskRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var workflowTask = await _workflowTaskRepository.GetAsync(id);

            if (workflowTask == null)
            {
                return NotFound();
            }

            return workflowTask;
        }

        // PUT: api/WorkflowTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkflowTask(int id, UpdateWorkflowTaskDto updateWorkflowTask)
        {
            if (id != updateWorkflowTask.Id)
            {
                return BadRequest();
            }

            // _context.Entry(updateWorkflowTask).State = EntityState.Modified;

            var workflowTask = await _workflowTaskRepository.GetAsync(id);//from this line entity get tracked.
            if (workflowTask == null)
            {
                return NotFound();
            }

            _mapper.Map(updateWorkflowTask, workflowTask); //from this line it get modified

            try
            {
                await _workflowTaskRepository.UpdateAsync(workflowTask);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await WorkflowTaskExists(id))
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

        // POST: api/WorkflowTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkflowTask>> PostWorkflowTask(CreateWorkflowTaskDto createWorkflowTask)
        {
            var workflowTask = _mapper.Map<WorkflowTask>(createWorkflowTask);

            await _workflowTaskRepository.AddAsync(workflowTask);

            return CreatedAtAction("GetWorkflowTask", new { id = workflowTask.Id }, workflowTask);
        }

        // DELETE: api/WorkflowTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkflowTask(int id)
        {
            if (await _workflowTaskRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var workflowTask = await _workflowTaskRepository.GetAsync(id);
            if (workflowTask == null)
            {
                return NotFound();
            }

            await _workflowTaskRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> WorkflowTaskExists(int id)
        {
            return await _workflowTaskRepository.Exists(id);
        }
    }
}