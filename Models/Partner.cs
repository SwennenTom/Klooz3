namespace Klooz3.Models
{
    public class Partner
    {
        public int partnerId { get; set; }

        public string? partnerName { get; set; }
        public byte[]? partnerImage { get; set; }
        public string? partnerLink { get; set; }
        public int? partnerDisplayOrder { get; set; }

        public Partner(string? partnerName, byte[]? partnerImage, string? partnerLink, int? partnerDisplayOrder)
        {
            this.partnerName = partnerName;
            this.partnerImage = partnerImage;
            this.partnerLink = partnerLink;
            this.partnerDisplayOrder = partnerDisplayOrder;
        }

        public Partner() { }
    }
}
