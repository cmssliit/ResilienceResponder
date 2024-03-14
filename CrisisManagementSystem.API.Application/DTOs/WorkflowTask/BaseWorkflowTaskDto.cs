using CrisisManagementSystem.API.DataLayer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrisisManagementSystem.API.Application.DTOs.WorkflowTask
{
    //we use abstract class because, we cant instantiate
    //only used for inheritance purposes
    public abstract class BaseWorkflowTaskDto
    {
        //since following properties are repeatin in all 
        //Dtos we can put it in base
        //we can add the required anotation.
        //it will only consider when adding new user
        [Required]
        public int SequenceOrder { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string AssigneeId { get; set; }
        public DateTime Deadline { get; set; }
        public int WorkflowId { get; set; }
    }
}