using CrisisManagementSystem.API.Application.DTOs.Workflow;
using System.ComponentModel.DataAnnotations;

namespace CrisisManagementSystem.API.Application.DTOs.Notification
{
    //Introduce to add here Single Responsibilty priniciple.
    //Only to transfer data.Not to hold data from database
    public class CreateNotificationDto : BaseNotificationDto
    {
    }

    // This is feel repeating samething. but
    //it follows single responsibility prinicple
    // one clas for one purpose
    public class UpdateNotificationDto : BaseNotificationDto
    {
        public int Id { get; set; }
    }
}