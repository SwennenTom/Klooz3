using Klooz3.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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

        [ValidateNever]
        [Required(ErrorMessage = "Verplicht veld.")]
        [FileExtensions(Extensions = "jpg,jpeg,png,gif,bmp,webp", ErrorMessage = "Selecteer een geldig bestand. De geldige formaten zijn jpg, jpeg, png, gif, bmp en webp.")]
        public byte[]? partnerImage { get; set; }

        [Required(ErrorMessage = "Verplicht veld.")]
        [StringLength(100, ErrorMessage = "Deze tekst kan maximaal 100 tekens lang zijn.")]
        [StartsWithHttp]
        public string? partnerLink { get; set; }

        public int? partnerDisplayOrder { get; set; }

        //public Partner(string? partnerName,string? partnerAlt, byte[]? partnerImage, string? partnerLink, int? partnerDisplayOrder)
        //{
        //    this.partnerName = partnerName;
        //    this.partnerAlt = partnerAlt;
        //    this.partnerImage = partnerImage;
        //    this.partnerLink = partnerLink;
        //    this.partnerDisplayOrder = partnerDisplayOrder;
        //}

        public Partner() { }
    }
}
