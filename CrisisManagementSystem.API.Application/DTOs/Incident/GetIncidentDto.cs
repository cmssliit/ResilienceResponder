namespace CrisisManagementSystem.API.Application.DTOs.Incident
{
    //we create this dto to single responsiblity princiepl
    // and avoid sending unnersseary data like navigation properties etc
    public class GetIncidentDto : BaseIncidentDto
    {
        public int Id { get; set; }
    }
}
