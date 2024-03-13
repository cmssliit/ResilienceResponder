using System.ComponentModel.DataAnnotations.Schema;

namespace CrisisManagementSystem.API.DataLayer
{
    public class IncidentMedia
    {
        public int Id { get; set; } 
        public int MediaType { get; set; }

        public string Path { get; set; }

        [ForeignKey(nameof(IncidentId))]
        public int IncidentId { get; set; }

        public virtual Incident Incident { get; set; }
    }
}
