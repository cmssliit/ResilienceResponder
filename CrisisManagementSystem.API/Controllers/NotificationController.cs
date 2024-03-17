
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrisisManagementSystem.API.Application.DTOs.Notification;
using AutoMapper;
using CrisisManagementSystem.API.Application.IRepository;
using CrisisManagementSystem.API.DataLayer.Entities;

namespace CrisisManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INotificationRepository _notificationRepository;

        //since we register our dbcontext with builder.services in program.cs
        //it geives the ability to inject almost anyfile wewant
        public NotificationController(IMapper mapper, INotificationRepository notificationRepository)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
        }

        // GET: api/GetNotifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetNotificationDto>>> GetNotifications()
        {
            if (await _notificationRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var notifications = await _notificationRepository.GetAllAsync();

            var getNotifications = _mapper.Map<List<GetNotificationDto>>(notifications);


            return Ok(getNotifications);
        }

        // GET: api/Notification/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notification>> GetNotification(int id)
        {
            if (await _notificationRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var notification = await _notificationRepository.GetAsync(id);

            if (notification == null)
            {
                return NotFound();
            }

            return notification;
        }

        // PUT: api/Notification/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotification(int id, UpdateNotificationDto updateNotification)
        {
            if (id != updateNotification.Id)
            {
                return BadRequest();
            }

            // _context.Entry(updateWorkflow).State = EntityState.Modified;

            var nofication = await _notificationRepository.GetAsync(id);//from this line entity get tracked.
            if (nofication == null)
            {
                return NotFound();
            }

            _mapper.Map(updateNotification, nofication); //from this line it get modified

            try
            {
                await _notificationRepository.UpdateAsync(nofication);
            }
            catch (DbUpdateConcurrencyException exc)
            {
                if (!await NotificationExists(id))
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

        // POST: api/Notifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Notification>> PostNotification(CreateNotificationDto createNotification)
        {
            var notification = _mapper.Map<Notification>(createNotification);

            await _notificationRepository.AddAsync(notification);

            return CreatedAtAction("GetNotification", new { id = notification.Id }, notification);
        }

        // DELETE: api/Notification/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            if (await _notificationRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var workflow = await _notificationRepository.GetAsync(id);
            if (workflow == null)
            {
                return NotFound();
            }

            await _notificationRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> NotificationExists(int id)
        {
            return await _notificationRepository.Exists(id);
        }
    }
}