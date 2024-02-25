namespace CrisisManagementSystem.API.DTOs.User
{
    //we create this dto to single responsiblity princiepl
    // and avoid sending unnersseary data like navigation properties etc
    public class GetUserDto : BaseUserDto
    {
        public int Id { get; set; }
    }
}
