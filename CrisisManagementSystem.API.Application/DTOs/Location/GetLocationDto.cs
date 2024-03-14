namespace CrisisManagementSystem.API.Application.DTOs.Location
{
    //we create this dto to single responsiblity princiepl
    // and avoid sending unnersseary data like navigation properties etc
    public class GetLocationDto : BaseLocationDto
    {
        public int Id { get; set; }
    }
}