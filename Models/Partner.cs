namespace Klooz3.Models
{
    public class Partner
    {
        public int partnerId { get; set; }

        public string? partnerName { get; set; }
        public string? partnerImage { get; set; }
        public string? partnerLink { get; set; }

        public Partner(string? partnerName, string? partnerImage, string? partnerLink)
        {
            this.partnerName = partnerName;
            this.partnerImage = partnerImage;
            this.partnerLink = partnerLink;
        }

        public Partner() { }
    }
}
