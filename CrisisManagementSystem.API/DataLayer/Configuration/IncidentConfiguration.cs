using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrisisManagementSystem.API.DataLayer.Configuration
{
    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        //on first build we need some roles
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasData(
                new Incident
                {
                    Id = 1,
                    Name = "fire in office",
                    Descripton = "very exapansive",
                    IncidentTypeId = (int)IncidentType.Fire,
                    Location = "MainBuilding",
                    ReporterId = 1
                },
                new Incident
                {
                    Id = 2,
                    Name = "Flood in office",
                    Descripton = "very exapansive",
                    IncidentTypeId = (int)IncidentType.Fire,
                    Location = "Whole",
                    ReporterId = 1
                },
                new Incident
                {
                    Id = 3,
                    Name = "CyberAttack",
                    Descripton = "very exapansive",
                    IncidentTypeId = (int)IncidentType.Fire,
                    Location = "Whole",
                    ReporterId = 1
                }

                );

        }
    }
}
