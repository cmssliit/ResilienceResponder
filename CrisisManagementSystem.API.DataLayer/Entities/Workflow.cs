using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisisManagementSystem.API.DataLayer.Entities
{
    public class Workflow
    {
        public int Id { get; set; }
        public string WorkflowName { get; set; }
        public string WorkflowDescription { get; set; }
        [ForeignKey(nameof(IncidentTypeId))]
        public int IncidentTypeId { get; set; }
        public virtual IncidentType IncidentType { get; set; }

        public virtual ICollection<WorkflowTask> WorkflowTasks { get; set; }


    }
}
