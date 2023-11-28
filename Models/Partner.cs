using Klooz3.Validation;
using System.ComponentModel.DataAnnotations;

namespace Klooz3.Models
{
    public class Partner
    {
        public int partnerId { get; set; }
        [Required(ErrorMessage = "Verplicht veld.")]
        [StringLength(50, ErrorMessage = "Deze tekst kan maximaal 50 tekens lang zijn.")]
        public string? partnerName { get; set; }
        [Required(ErrorMessage = "Verplicht veld.")]
        [StringLength(50, ErrorMessage = "Deze tekst kan maximaal 50 tekens lang zijn.")]
        public string? partnerAlt { get; set; }
        [Required(ErrorMessage = "Verplicht veld.")]
        public byte[]? partnerImage { get; set; }
        [Required(ErrorMessage = "Verplicht veld.")]
        [StringLength(100, ErrorMessage = "Deze tekst kan maximaal 100 tekens lang zijn.")]
        [StartsWithHttp]
        public string? partnerLink { get; set; }
        public int? partnerDisplayOrder { get; set; }

        public Partner(string? partnerName,string? partnerAlt, byte[]? partnerImage, string? partnerLink, int? partnerDisplayOrder)
        {
            this.partnerName = partnerName;
            this.partnerAlt = partnerAlt;
            this.partnerImage = partnerImage;
            this.partnerLink = partnerLink;
            this.partnerDisplayOrder = partnerDisplayOrder;
        }

        public Partner() { }
    }
}
