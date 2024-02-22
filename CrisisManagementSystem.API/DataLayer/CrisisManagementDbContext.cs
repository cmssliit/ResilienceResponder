using Microsoft.EntityFrameworkCore;

namespace CrisisManagementSystem.API.DataLayer
{
    public class CrisisManagementDbContext : DbContext
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

            modelBuilder.Entity<User>().HasData(
                new User
                { 
                    Id=1 ,
                    UserName = "ThomasRay",
                    Password ="", 
                    Role="Ceo"
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

            modelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    Id = 1,
                    Name="fire in office",
                    Descripton ="very exapansive",
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

            modelBuilder.Entity<IncidentMedia>().HasData(
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
