namespace Klooz3.Models
{
    public class Partner
    {
        public int partnerId { get; set; }

        public string? partnerName { get; set; }
        public string? partnerAlt { get; set; }
        public byte[]? partnerImage { get; set; }
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
