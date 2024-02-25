namespace CrisisManagementSystem.API.DTOs.User
{
    //Introduce to add here Single Responsibilty priniciple.
    //Only to transfer data.Not to hold data from database
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
