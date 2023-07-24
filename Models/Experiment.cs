namespace Klooz3.Models
{
    public class Experiment
    {
        public int experimentId { get; set; }

        public byte[]? experimentImage { get; set; }
        public string? experimentName { get; set; }
        public string? experimentCardFrontText { get; set; }
        public string? experimentCardBackText { get; set; }

        public int? categoriesId { get; set; }
        public Categories? categories { get; set; }

        public string? experimentShortText { get; set; }
        public Partner? experimentPartners { get; set; }
        public DateTime? experimentKickOffDate { get; set; }
        public DateTime? experimentEndDate { get; set; }
        public string? experimentwickedProblemsToSmartSolutions { get; set; }
        public string? experimenttargetAndImpact { get; set; }
        public string? experimentTouchstone { get; set; }
        public byte[]? experimentPhotos { get; set; }
        public bool? experimentPublished { get; set; }

        public User? experimentOwner { get; set; }
        public DateTime? experimentCreatedDate { get; set; }
        public DateTime? experimentLastModified { get; set; }
        public User? experimentLastModifiedBy { get; set; }
        public ExperimentStatus? experimentStatus { get; set; }

        public enum ExperimentStatus
        {
            Ingediend,
            Bezig,
            Klaar,
            Lopende,
            Gearchiveerd
        }

        public Experiment(int experimentId, byte[]? experimentImage, string? experimentName, string? experimentCardFrontText, string? experimentCardBackText, int? categoriesId, Categories? categories, string? experimentShortText, Partner? experimentPartners, DateTime? experimentKickOffDate, DateTime? experimentEndDate, string? experimentwickedProblemsToSmartSolutions, string? experimenttargetAndImpact, string? experimentTouchstone, byte[]? experimentPhotos, bool? experimentPublished, User? experimentOwner, DateTime? experimentCreatedDate, DateTime? experimentLastModified, User? experimentLastModifiedBy, ExperimentStatus? experimentStatus)
        {
            this.experimentId = experimentId;
            this.experimentImage = experimentImage;
            this.experimentName = experimentName;
            this.experimentCardFrontText = experimentCardFrontText;
            this.experimentCardBackText = experimentCardBackText;
            this.categoriesId = categoriesId;
            this.categories = categories;
            this.experimentShortText = experimentShortText;
            this.experimentPartners = experimentPartners;
            this.experimentKickOffDate = experimentKickOffDate;
            this.experimentEndDate = experimentEndDate;
            this.experimentwickedProblemsToSmartSolutions = experimentwickedProblemsToSmartSolutions;
            this.experimenttargetAndImpact = experimenttargetAndImpact;
            this.experimentTouchstone = experimentTouchstone;
            this.experimentPhotos = experimentPhotos;
            this.experimentPublished = experimentPublished;
            this.experimentOwner = experimentOwner;
            this.experimentCreatedDate = experimentCreatedDate;
            this.experimentLastModified = experimentLastModified;
            this.experimentLastModifiedBy = experimentLastModifiedBy;
            this.experimentStatus = experimentStatus;
        }

        public Experiment()
        {

        }
    }
}
