using CrisisManagementSystem.API.DataLayer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrisisManagementSystem.API.Application.DTOs.WorkFlowtaskExecution
{
    //we use abstract class because, we cant instantiate
    //only used for inheritance purposes
    public abstract class BaseWorkFlowtaskExecutionDto
    {
        //since following properties are repeatin in all 
        //Dtos we can put it in base
        //we can add the required anotation.
        //it will only consider when adding new user
        [Required]
        public int WorkflowTaskId { get; set; }
        public int IncidentId { get; set; }
        public bool IsDone { get; set; }
        public DateTime? ExecutedTime { get; set; }
    }
}