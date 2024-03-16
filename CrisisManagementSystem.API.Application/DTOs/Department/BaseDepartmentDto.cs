using System.ComponentModel.DataAnnotations;

namespace CrisisManagementSystem.API.Application.DTOs.Department
{
    //we use abstract class because, we cant instantiate
    //only used for inheritance purposes
    public abstract class BaseDepartmentDto
    {
        //since following properties are repeatin in all 
        //Dtos we can put it in base
        //we can add the required anotation.
        //it will only consider when adding new user
        [Required]
        public string DeptName { get; set; }
        public string DeptHeadId { get; set; }
        public int LocationId { get; set; }
    }
}
