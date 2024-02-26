using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrisisManagementSystem.API.DataLayer.Configuration
{
    public class IncidentMediaConfiguration : IEntityTypeConfiguration<IncidentMedia>
    {
        //on first build we need some roles
        public void Configure(EntityTypeBuilder<IncidentMedia> builder)
        {
            builder.HasData(
                new IncidentMedia
                {
                    Id = 1,
                    IncidentId = 1,
                    MediaType = (int)MediaType.Image,
                    Path = "/Crisis/Images/image1.jpg"
                },
                  new IncidentMedia
                  {
                      Id = 2,
                      IncidentId = 1,
                      MediaType = (int)MediaType.Image,
                      Path = "/Crisis/Images/image2.jpg"
                  },
                   new IncidentMedia
                   {
                       Id = 3,
                       IncidentId = 1,
                       MediaType = (int)MediaType.Image,
                       Path = "/Crisis/Images/image3.jpg"
                   },
                    new IncidentMedia
                    {
                        Id = 4,
                        IncidentId = 1,
                        MediaType = (int)MediaType.Image,
                        Path = "/Crisis/Images/image4.jpg"
                    }


            );

        }
    }
}
