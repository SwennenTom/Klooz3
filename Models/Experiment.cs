using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Klooz3.Models
{
    public class Experiment
    {
        public int experimentId { get; set; }

        
        public byte[]? experimentImage { get; set; }
        [Required]
        public string? experimentName { get; set; }
        [Required]
        public string? experimentCardBackText { get; set; }
        [Required]
        public string? experimentShortText { get; set; }
        public bool experimentPublished { get; set; } = false;

        public Experiment()
        {

        }
    }
}
