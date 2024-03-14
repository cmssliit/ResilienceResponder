using CrisisManagementSystem.API.Application.DTOs.Department;
using System.ComponentModel.DataAnnotations;

namespace CrisisManagementSystem.API.Application.DTOs.Department
{
    //Introduce to add here Single Responsibilty priniciple.
    //Only to transfer data.Not to hold data from database
    public class CreateDepartmentDto : BaseDepartmentDto
    {
    }

    // This is feel repeating samething. but
    //it follows single responsibility prinicple
    // one clas for one purpose
    public class UpdateDepartmentDto : BaseDepartmentDto
    {
        public int Id { get; set; }
    }
}