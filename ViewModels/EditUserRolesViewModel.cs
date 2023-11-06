using Microsoft.AspNetCore.Identity;

namespace Klooz3.ViewModels
{
    public class EditUserRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<string> AvailableRoles { get; set; }
        public string SelectedRole { get; set; }
    }
}
