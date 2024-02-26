using Microsoft.AspNetCore.Identity;

namespace CrisisManagementSystem.API.DataLayer
{
    public class SystemUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NIC { get; set; }
    }
}
