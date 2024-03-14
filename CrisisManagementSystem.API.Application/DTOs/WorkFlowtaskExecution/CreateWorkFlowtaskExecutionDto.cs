using CrisisManagementSystem.API.Application.DTOs.WorkFlowtaskExecution;
using System.ComponentModel.DataAnnotations;

namespace CrisisManagementSystem.API.Application.DTOs.WorkFlowtaskExecution
{
    //Introduce to add here Single Responsibilty priniciple.
    //Only to transfer data.Not to hold data from database
    public class CreateWorkFlowtaskExecutionDto : BaseWorkFlowtaskExecutionDto
    {
    }

    // This is feel repeating samething. but
    //it follows single responsibility prinicple
    // one clas for one purpose
    public class UpdateWorkFlowtaskExecutionDto : BaseWorkFlowtaskExecutionDto
    {
        public int Id { get; set; }
    }
}