using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisisManagementSystem.API.DataLayer.Entities
{
    public class WorkFlowtaskExecution
    {
        public int Id { get; set; }
        [ForeignKey(nameof(WorkflowTaskId))]
        public int WorkflowTaskId { get; set; }

        [NotMapped]
        public virtual WorkflowTask WorkflowTask { get; set; }

        [ForeignKey(nameof(IncidentId))]
        public int IncidentId { get; set; }
        public virtual Incident Incident { get; set; }
        public bool IsDone { get; set; }
        public DateTime? ExecutedTime { get; set; }
    }
}
