using System.ComponentModel.DataAnnotations.Schema;

namespace CrisisManagementSystem.API.DataLayer
{
    public class Incident
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripton { get; set; }
        public string Location { get; set; }
        public int IncidentTypeId {get; set;}

        [ForeignKey(nameof(ReporterId))]
        public int ReporterId { get; set; }

        public virtual User Reporter { get; set; }

        public virtual ICollection<IncidentMedia> Media { get; set; } = new List<IncidentMedia>();
    }
}
