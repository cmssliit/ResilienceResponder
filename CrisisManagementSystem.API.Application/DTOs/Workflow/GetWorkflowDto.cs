namespace CrisisManagementSystem.API.Application.DTOs.Workflow
{
    //we create this dto to single responsiblity princiepl
    // and avoid sending unnersseary data like navigation properties etc
    public class GetWorkflowDto : BaseWorkflowDto
    {
        public int Id { get; set; }
    }
}
