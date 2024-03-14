using CrisisManagementSystem.API.DataLayer;
using CrisisManagementSystem.API.Application.IRepository;

namespace CrisisManagementSystem.API.Application.Repository
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(CrisisManagementDbContext context) : base(context)
        {
        }
    }
}