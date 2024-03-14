using CrisisManagementSystem.API.Application.DTOs.WorkflowTask;
using System.ComponentModel.DataAnnotations;

namespace CrisisManagementSystem.API.Application.DTOs.WorkflowTask
{
    //Introduce to add here Single Responsibilty priniciple.
    //Only to transfer data.Not to hold data from database
    public class CreateWorkflowTaskDto : BaseWorkflowTaskDto
    {
    }

    // This is feel repeating samething. but
    //it follows single responsibility prinicple
    // one clas for one purpose
    public class UpdateWorkflowTaskDto : BaseWorkflowTaskDto
    {
        public int Id { get; set; }
    }
}