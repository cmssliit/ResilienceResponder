using CrisisManagementSystem.API.DataLayer;
using CrisisManagementSystem.API.Application.IRepository;

namespace CrisisManagementSystem.API.Application.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CrisisManagementDbContext context) : base(context)
        {
        }
    }
}
