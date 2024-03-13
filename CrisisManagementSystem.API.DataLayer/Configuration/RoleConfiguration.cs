using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrisisManagementSystem.API.DataLayer.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        //on first build we need some roles
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole
            {
                Name= "Administrator",
                NormalizedName="ADMINISTRATOR"
            }, 
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "User"
            }
            );
        }
    }
}
