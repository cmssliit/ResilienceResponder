using CrisisManagementSystem.API.DataLayer;
using CrisisManagementSystem.API.IRepository;

namespace CrisisManagementSystem.API.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CrisisManagementDbContext context) : base(context)
        {
        }
    }
}
