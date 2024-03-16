using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrisisManagementSystem.API.Application.DTOs.User;
using AutoMapper;
using CrisisManagementSystem.API.Application.IRepository;
using Microsoft.AspNetCore.Authorization;
using CrisisManagementSystem.API.Application.Exceptions;
using CrisisManagementSystem.API.DataLayer.Entities;

namespace CrisisManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        //since we register our dbcontext with builder.services in program.cs
        //it geives the ability to inject almost anyfile wewant
        public UsersController(IMapper mapper,IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetUsers()
        {
          if (await _userRepository.GetAllAsync() == null)
          {
              return NotFound();
          }
            var users = await _userRepository.GetAllAsync();

            var getusers = _mapper.Map<List<GetUserDto>>(users);

            return Ok(getusers); 
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDto>> GetUser(int id)
        {
          
            var user = await _userRepository.GetAsync(id);

            if (user == null)
            {
                throw new NotFoundException(nameof(GetUser), id.ToString());
            }

            var getUserDto = _mapper.Map<GetUserDto>(user);

            return Ok(getUserDto);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutUser(int id, UpdateUserDto updateUser)
        {
            if (id != updateUser.Id)
            {
                return BadRequest();
            }

            // _context.Entry(updateUser).State = EntityState.Modified;

            var user = await _userRepository.GetAsync(id);//from this line entity get tracked.
            if (user == null)
            {
                return NotFound();
            }

            _mapper.Map(updateUser,user); //from this line it get modified

            try
            {
                await _userRepository.UpdateAsync(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<User>> PostUser(CreateUserDto createUser)
        {
          var user = _mapper.Map<User>(createUser);

            await _userRepository.AddAsync(user);

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize (Roles = "Administrator,User")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (await _userRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var user = await _userRepository.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> UserExists(int id)
        {
            return await _userRepository.Exists(id);
        }
    }
}
