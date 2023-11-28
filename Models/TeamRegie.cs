using System.ComponentModel.DataAnnotations;

namespace Klooz3.Models
{
    public class TeamRegie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Verplicht veld.")]
        [StringLength(50, ErrorMessage = "Deze tekst kan maximaal 50 tekens lang zijn.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Verplicht veld.")]
        [StringLength(50, ErrorMessage = "Deze tekst kan maximaal 50 tekens lang zijn.")]
        [EmailAddress]
        public string? Emailadress { get; set; }

        public TeamRegie() { }
        public TeamRegie(string? name, string? emailadress)
        {
            Name = name;
            Emailadress = emailadress;
        }
    }
}
