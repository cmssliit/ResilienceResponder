using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrisisManagementSystem.API.DataLayer.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        //on first build we need some roles
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    UserName = "ThomasRay",
                    Password = "",
                    Role = "Ceo"
                },
                new User
                {
                    Id = 2,
                    UserName = "JhonDoe",
                    Password = "",
                    Role = "Excecutive"
                },
                new User
                {
                    Id = 3,
                    UserName = "JaneDoe",
                    Password = "",
                    Role = "Receptionist"
                }
                ); 
        }
    }
}
