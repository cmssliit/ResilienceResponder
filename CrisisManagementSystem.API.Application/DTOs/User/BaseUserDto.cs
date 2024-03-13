using System.ComponentModel.DataAnnotations;

namespace CrisisManagementSystem.API.Application.DTOs.User
{
    //we use abstract class because, we cant instantiate
    //only used for inheritance purposes
    public abstract class BaseUserDto
    {
        //since following properties are repeatin in all 
        //Dtos we can put it in base
        //we can add the required anotation.
        //it will only consider when adding new user
        [Required]
        public string UserName { get; set; }    
        public string Password { get; set; }    
        public string Role { get; set; }
    }
}
