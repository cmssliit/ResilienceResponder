using CrisisManagementSystem.API.DataLayer.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrisisManagementSystem.API.Application.DTOs.Notification
{
    //we use abstract class because, we cant instantiate
    //only used for inheritance purposes
    public abstract class BaseNotificationDto
    {
        //since following properties are repeatin in all 
        //Dtos we can put it in base
        //we can add the required anotation.
        //it will only consider when adding new user
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReciverId { get; set; }
        public string SenderId { get; set; }
        public DateTime? SentTime { get; set; }
        public DateTime? RecieveTime { get; set; }
    }
}