using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisisManagementSystem.API.DataLayer
{
    public class Department
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public int DeptHeadId { get; set; }

        public int LocationId { get; set; }
        public virtual SystemUser DeptHead { get; set; }
        public virtual Location Location { get; set; }

        [NotMapped]
        public virtual ICollection<SystemUser> DepartmentMembers { get; set; }
        

    }
}
