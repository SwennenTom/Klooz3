namespace Klooz3.Models
{
    public class Experiment
    {
        public int experimentId { get; set; }

        public string? experimentImage { get; set; }
        public string? experimentName { get; set; }
        public string? experimentCardFrontText { get; set; }
        public string? experimentCardBackText { get; set; }

        public int? categoriesId { get; set; }
        public Categories? categories { get; set; }

        public string? experimentShortText { get; set; }
        public string? experimentPartners { get; set; }
        public DateTime? experimentKickOffDate { get; set; }
        public string? experimentwickedProblemsToSmartSolutions { get; set; }
        public string? experimenttargetAndImpact { get; set; }
        public string? experimentTouchstone { get; set; }
        public string? experimentPhotos { get; set; }
        public bool? experimentPublished { get; set; }

        public Experiment(string? experimentImage, string? experimentName, string? experimentCardFrontText, string? experimentCardBackText, int? categoriesId, string? experimentShortText, string? experimentPartners, DateTime? experimentKickOffDate, string? experimentwickedProblemsToSmartSolutions, string? experimenttargetAndImpact, string? experimentTouchstone, string? experimentPhotos, bool? experimentPublished)
        {
            this.experimentImage = experimentImage;
            this.experimentName = experimentName;
            this.experimentCardFrontText = experimentCardFrontText;
            this.experimentCardBackText = experimentCardBackText;
            this.categoriesId = categoriesId;
            this.experimentShortText = experimentShortText;
            this.experimentPartners = experimentPartners;
            this.experimentKickOffDate = experimentKickOffDate;
            this.experimentwickedProblemsToSmartSolutions = experimentwickedProblemsToSmartSolutions;
            this.experimenttargetAndImpact = experimenttargetAndImpact;
            this.experimentTouchstone = experimentTouchstone;
            this.experimentPhotos = experimentPhotos;
            this.experimentPublished = experimentPublished;
        }

        public Experiment()
        {

        }
    }
}
