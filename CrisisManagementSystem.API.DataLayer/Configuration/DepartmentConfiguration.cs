using CrisisManagementSystem.API.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrisisManagementSystem.API.DataLayer.Confirguration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasOne(d => d.DeptHead)
                   .WithOne(u => u.UserDepartment)
                   .HasForeignKey<SystemUser>(u => u.DepartmentId);
        }
    }
}
