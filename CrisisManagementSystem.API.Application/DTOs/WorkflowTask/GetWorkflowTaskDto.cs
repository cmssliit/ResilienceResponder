namespace CrisisManagementSystem.API.Application.DTOs.WorkflowTask
{
    //we create this dto to single responsiblity princiepl
    // and avoid sending unnersseary data like navigation properties etc
    public class GetWorkflowTaskDto : BaseWorkflowTaskDto
    {
        public int Id { get; set; }
    }
}