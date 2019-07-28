using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace AutomatedManagementPilot_AMP.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        //public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        //public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        //public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
        //public virtual IEnumberable<ApplicationRole> Roles { get; set; }
        //public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
