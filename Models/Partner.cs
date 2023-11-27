using Klooz3.Validation;
using System.ComponentModel.DataAnnotations;

namespace Klooz3.Models
{
    public class Partner
    {
        public int partnerId { get; set; }
        [Required]
        public string? partnerName { get; set; }
        [Required]
        public string? partnerAlt { get; set; }
        [Required]
        public byte[]? partnerImage { get; set; }
        [Required]
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
