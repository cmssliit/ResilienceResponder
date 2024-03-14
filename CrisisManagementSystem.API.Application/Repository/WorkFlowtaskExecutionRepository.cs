using CrisisManagementSystem.API.DataLayer;
using CrisisManagementSystem.API.Application.IRepository;

namespace CrisisManagementSystem.API.Application.Repository
{
    public class WorkFlowtaskExecutionRepository : GenericRepository<WorkFlowtaskExecution>, IWorkFlowtaskExecutionRepository
    {
        public WorkFlowtaskExecutionRepository(CrisisManagementDbContext context) : base(context)
        {
        }
    }
}