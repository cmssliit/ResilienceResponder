namespace CrisisManagementSystem.API.Application.DTOs.Department
{
    //we create this dto to single responsiblity princiepl
    // and avoid sending unnersseary data like navigation properties etc
    public class GetDepartmentDto : BaseDepartmentDto
    {
        public int Id { get; set; }
    }
}