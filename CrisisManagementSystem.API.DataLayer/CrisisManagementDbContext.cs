﻿using CrisisManagementSystem.API.DataLayer.Configuration;
using CrisisManagementSystem.API.DataLayer.Confirguration;
using CrisisManagementSystem.API.DataLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// Updated Data Layer

namespace CrisisManagementSystem.API.DataLayer
{
    public class CrisisManagementDbContext : IdentityDbContext<SystemUser>
    {
        //opeitons here passed by options from CrisisManagementDbContext appsetting.json
        public CrisisManagementDbContext(DbContextOptions options):base(options) 
        {

        }

        #region Public Properties
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

        #endregion 

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        }

        #endregion

    }
}
