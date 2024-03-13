using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisisManagementSystem.API.DataLayer
{
    public class Location
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int PostalCode { get; set; }
        public virtual ICollection<Department> Departments { get; set; }

    }
}
