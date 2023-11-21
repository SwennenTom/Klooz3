using Microsoft.AspNetCore.Identity;

namespace Klooz3.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email {  get; set; }
        public string PhoneNumber {  get; set; }
        public string Organization {  get; set; }
    }
}
