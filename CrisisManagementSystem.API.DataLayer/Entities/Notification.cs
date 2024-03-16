using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisisManagementSystem.API.DataLayer.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(ReciverId))]
        public string ReciverId { get; set; }

        public virtual SystemUser Reciever { get; set; }

        [ForeignKey(nameof(SenderId))]
        public string SenderId { get; set; }

        public virtual SystemUser Sender { get; set; }

        public DateTime? SentTime { get; set; }
        public DateTime? RecieveTime { get; set; }
    }
}
