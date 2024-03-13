using System.ComponentModel.DataAnnotations;

namespace CrisisManagementSystem.API.Application.DTOs.User
{
    public class SystemUserDto : LoginDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string NIC { get; set; }

    }
}