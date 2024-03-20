using System.ComponentModel.DataAnnotations.Schema;

namespace CrisisManagementSystem.API.DataLayer.Entities
{
    public class Incident
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripton { get; set; }
        public int Severity { get; set; }

        [ForeignKey(nameof(IncidentDepartmentId))]
        public int IncidentDepartmentId { get; set; }

        [ForeignKey(nameof(IncidentTypeId))]
        public int IncidentTypeId { get; set; }
        public virtual IncidentType IncidentType { get; set; }

        [ForeignKey(nameof(ReporterId))]
        public string ReporterId { get; set; }

        public virtual SystemUser Reporter { get; set; }

        public virtual ICollection<IncidentMedia> Media { get; set; } = new List<IncidentMedia>();
    }
}
