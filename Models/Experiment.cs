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
        public byte[]? experimentPhotos { get; set; }
        public bool? experimentPublished { get; set; } = false;

        //public Experiment(int experimentId, 
        //    byte[]? experimentImage, 
        //    string? experimentName, 
        //    string? experimentCardBackText,
        //    string? experimentShortText,
        //    byte[]? experimentPhotos, 
        //    bool? experimentPublished)
        //{
        //    this.experimentId = experimentId;
        //    this.experimentImage = experimentImage;
        //    this.experimentName = experimentName;
        //    this.experimentCardBackText = experimentCardBackText;
        //    this.experimentShortText = experimentShortText;
        //    this.experimentPhotos = experimentPhotos;
        //    this.experimentPublished = experimentPublished;
        //}

        public Experiment()
        {

        }
    }
}
