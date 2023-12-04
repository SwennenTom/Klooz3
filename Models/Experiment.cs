using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Klooz3.Models
{
    public class Experiment
    {
        public int experimentId { get; set; }

        [ValidateNever]
        public byte[] experimentImage { get; set; }

        [Required(ErrorMessage = "Verplicht veld.")]
        [StringLength(50, ErrorMessage = "De titel kan maximum 50 tekens lang zijn.")]
        public string experimentName { get; set; }

        [Required(ErrorMessage = "Verplicht veld.")]
        [StringLength(200, ErrorMessage = "Deze tekst kan maximaal 200 tekens lang zijn.")]
        public string experimentCardBackText { get; set; }

        [Required(ErrorMessage = "Verplicht veld.")]
        [StringLength(5000, ErrorMessage = "Deze tekst kan maximaal 5000 tekens lang zijn.")]
        public string experimentShortText { get; set; }

        public ICollection<UserExperimenten> UserExperimenten { get; set; } = new List<UserExperimenten>();

        public bool experimentPublished { get; set; } = false;

        public Experiment()
        {
            
        }
    }
}
