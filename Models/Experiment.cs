using Microsoft.AspNetCore.Identity;

namespace Klooz3.Models
{
    public class Experiment
    {
        public int experimentId { get; set; }

        public byte[]? experimentImage { get; set; }
        public string? experimentName { get; set; }
        public string? experimentCardBackText { get; set; }
        public string? experimentShortText { get; set; }
        public bool experimentPublished { get; set; } = false;

        public Experiment()
        {

        }
    }
}
