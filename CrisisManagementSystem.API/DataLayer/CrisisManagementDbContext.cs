using CrisisManagementSystem.API.DataLayer.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrisisManagementSystem.API.DataLayer
{
    public class CrisisManagementDbContext : IdentityDbContext<SystemUser>
    {
        //opeitons here passed by options from CrisisManagementDbContext appsetting.json
        public CrisisManagementDbContext(DbContextOptions options):base(options) 
        {

        }

        public DbSet<User> Users { get;set; }
        public DbSet<Incident> Incidents { get;set; }
        public DbSet<IncidentMedia> IncidentMedia { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new IncidentConfiguration());
            modelBuilder.ApplyConfiguration(new IncidentMediaConfiguration());
        }

    }
}
