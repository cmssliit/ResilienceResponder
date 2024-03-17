using CrisisManagementSystem.API.DataLayer;
using CrisisManagementSystem.API.Application.IRepository;
using CrisisManagementSystem.API.DataLayer.Entities;

namespace CrisisManagementSystem.API.Application.Repository
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(CrisisManagementDbContext context) : base(context)
        {
        }
    }
}