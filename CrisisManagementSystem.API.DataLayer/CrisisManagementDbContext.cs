using CrisisManagementSystem.API.DataLayer.Configuration;
using CrisisManagementSystem.API.DataLayer.Entities;
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
        public DbSet<IncidentType> IncidentTypes { get;set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Workflow> Workflows { get; set; }

        public DbSet<WorkflowTask> WorkflowTasks { get; set; }

        public DbSet<WorkFlowtaskExecution> WorkFlowtaskExecutions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.Entity<Department>()
       .HasOne(d => d.DeptHead)
       .WithOne(u => u.UserDepartment)
       .HasForeignKey<SystemUser>(u => u.DepartmentId);
        }

    }
}
