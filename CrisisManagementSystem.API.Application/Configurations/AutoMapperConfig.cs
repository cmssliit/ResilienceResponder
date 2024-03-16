using AutoMapper;
using CrisisManagementSystem.API.Application.DTOs.User;
using CrisisManagementSystem.API.DataLayer.Entities;

namespace CrisisManagementSystem.API.Application.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //Auto mapper will use the name of the property and will autamaticlly map
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<SystemUserDto, SystemUser>().ReverseMap();

            CreateMap<Department, DTOs.Department.CreateDepartmentDto>().ReverseMap();
            CreateMap<Department, DTOs.Department.GetDepartmentDto>().ReverseMap();
            CreateMap<Department, DTOs.Department.UpdateDepartmentDto>().ReverseMap();

            CreateMap<Location, DTOs.Location.CreateLocationDto>().ReverseMap();
            CreateMap<Location, DTOs.Location.GetLocationDto>().ReverseMap();
            CreateMap<Location, DTOs.Location.UpdateLocationDto>().ReverseMap();

            CreateMap<Workflow, DTOs.Workflow.CreateWorkflowDto>().ReverseMap();
            CreateMap<Workflow, DTOs.Workflow.GetWorkflowDto>().ReverseMap();
            CreateMap<Workflow, DTOs.Workflow.UpdateWorkflowDto>().ReverseMap();

            CreateMap<WorkflowTask, DTOs.WorkflowTask.CreateWorkflowTaskDto>().ReverseMap();
            CreateMap<WorkflowTask, DTOs.WorkflowTask.GetWorkflowTaskDto>().ReverseMap();
            CreateMap<WorkflowTask, DTOs.WorkflowTask.UpdateWorkflowTaskDto>().ReverseMap();

            CreateMap<WorkFlowtaskExecution, DTOs.WorkFlowtaskExecution.CreateWorkFlowtaskExecutionDto>().ReverseMap();
            CreateMap<WorkFlowtaskExecution, DTOs.WorkFlowtaskExecution.GetWorkFlowtaskExecutionDto>().ReverseMap();
            CreateMap<WorkFlowtaskExecution, DTOs.WorkFlowtaskExecution.UpdateWorkFlowtaskExecutionDto>().ReverseMap();

        }
    }
}
