using Microsoft.AspNetCore.Identity;

namespace Klooz3.Models
{
    public class UserExperimenten
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public int ExperimentId { get; set; }
        public Experiment Experiment { get; set; }
    }
}
