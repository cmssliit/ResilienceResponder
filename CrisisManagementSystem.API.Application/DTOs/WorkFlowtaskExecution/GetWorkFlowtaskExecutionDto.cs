namespace CrisisManagementSystem.API.Application.DTOs.WorkFlowtaskExecution
{
    //we create this dto to single responsiblity princiepl
    // and avoid sending unnersseary data like navigation properties etc
    public class GetWorkFlowtaskExecutionDto : BaseWorkFlowtaskExecutionDto
    {
        public int Id { get; set; }
    }
}