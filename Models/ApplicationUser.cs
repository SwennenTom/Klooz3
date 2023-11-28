using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Klooz3.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage ="Verplicht veld.")]
        [StringLength(50, ErrorMessage = "Deze tekst kan maximaal 50 tekens lang zijn.")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Verplicht veld.")]
        [StringLength(50, ErrorMessage = "Deze tekst kan maximaal 50 tekens lang zijn.")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Verplicht veld.")]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "Deze tekst kan maximaal 50 tekens lang zijn.")]
        public string Email {  get; set; }
        [Required(ErrorMessage = "Verplicht veld.")]
        [StringLength(20, ErrorMessage = "Deze tekst kan maximaal 20 tekens lang zijn.")]
        public string PhoneNumber {  get; set; }
        [Required(ErrorMessage = "Verplicht veld.")]
        public string Organization {  get; set; }
    }
}
