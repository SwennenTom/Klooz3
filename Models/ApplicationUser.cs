using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Klooz3.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress]
        public string Email {  get; set; }
        [Required]
        public string PhoneNumber {  get; set; }
        [Required]
        public string Organization {  get; set; }
    }
}
