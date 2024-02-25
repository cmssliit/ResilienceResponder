using System.ComponentModel.DataAnnotations;

namespace CrisisManagementSystem.API.DTOs.User
{
    //Introduce to add here Single Responsibilty priniciple.
    //Only to transfer data.Not to hold data from database
    public class CreateUserDto : BaseUserDto
    {
    }

    // This is feel repeating samething. but
    //it follows single responsibility prinicple
    // one clas for one purpose
    public class UpdateUserDto : BaseUserDto
    {
        public int Id { get; set; }
    }
}
