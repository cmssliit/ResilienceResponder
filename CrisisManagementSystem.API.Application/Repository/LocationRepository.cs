using CrisisManagementSystem.API.DataLayer;
using CrisisManagementSystem.API.Application.IRepository;

namespace CrisisManagementSystem.API.Application.Repository
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(CrisisManagementDbContext context) : base(context)
        {
        }
    }
}