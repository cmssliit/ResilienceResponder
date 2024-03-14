using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrisisManagementSystem.API.Application.DTOs.Workflow
{
    //we use abstract class because, we cant instantiate
    //only used for inheritance purposes
    public abstract class BaseWorkflowDto
    {
        //since following properties are repeatin in all 
        //Dtos we can put it in base
        //we can add the required anotation.
        //it will only consider when adding new user
        [Required]
        public string WorkflowName { get; set; }
        public string WorkflowDescription { get; set; }
        public int IncidentTypeId { get; set; }
    }
}