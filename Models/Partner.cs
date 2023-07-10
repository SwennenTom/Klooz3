namespace Klooz3.Models
{
    public class Partner
    {
        public int partnerId { get; set; }

        public string? partnerName { get; set; }
        public byte[]? partnerImage { get; set; }
        public string? partnerLink { get; set; }

        public Partner(string? partnerName, byte[]? partnerImage, string? partnerLink)
        {
            this.partnerName = partnerName;
            this.partnerImage = partnerImage;
            this.partnerLink = partnerLink;
        }

        public Partner() { }
    }
}
