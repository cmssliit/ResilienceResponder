using CrisisManagementSystem.API.DataLayer;
using CrisisManagementSystem.API.Application.IRepository;

namespace CrisisManagementSystem.API.Application.Repository
{
    public class WorkflowRepository : GenericRepository<Workflow>, IWorkflowRepository
    {
        public WorkflowRepository(CrisisManagementDbContext context) : base(context)
        {
        }
    }
}