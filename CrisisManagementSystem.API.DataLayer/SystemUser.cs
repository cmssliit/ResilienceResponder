using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrisisManagementSystem.API.DataLayer
{
    public class SystemUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NIC { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public int DepartmentId { get; set; }

        public virtual Department UserDepartment { get; set; }
    }
}
