using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisisManagementSystem.API.DataLayer.Entities
{
    public class WorkflowTask
    {
        public int Id { get; set; }

        public int SequenceOrder { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        [ForeignKey(nameof(AssigneeId))]
        public string AssigneeId { get; set; }
        public virtual SystemUser Assignee { get; set; }
        public DateTime Deadline { get; set; }

        [ForeignKey(nameof(WorkflowId))]
        public int WorkflowId { get; set; }
        public virtual Workflow Workflow { get; set; }

    }
}
