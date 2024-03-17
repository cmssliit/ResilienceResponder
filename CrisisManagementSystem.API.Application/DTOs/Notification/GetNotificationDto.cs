namespace CrisisManagementSystem.API.Application.DTOs.Notification
{
    //we create this dto to single responsiblity princiepl
    // and avoid sending unnersseary data like navigation properties etc
    public class GetNotificationDto : BaseNotificationDto
    {
        public int Id { get; set; }
    }
}
