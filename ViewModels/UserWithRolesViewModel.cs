using Klooz3.Models;
using Microsoft.AspNetCore.Identity;

namespace Klooz3.ViewModels
{
    public class UserWithRolesViewModel
    {
        //public IdentityUser User { get; set; }
        public ApplicationUser User { get; set; }
        public IList<string> Roles { get; set; }
    }
}
