using Klooz3.Data;
using Klooz3.Models;
using System.Collections.Generic;
using System.Linq;

namespace Klooz3.Data
{
    public class ExperimentRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public ExperimentRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserExperimenten> GetAllUserExperimenten()
        {
            return _dbContext.experiments
                .Select(e => new UserExperimenten { Experiment = e })
                .ToList();
        }

        public List<UserExperimenten> GetUserExperimentenByUserId(string userId)
        {
            var userExperiments = _dbContext.userexperimenten
                .Where(ue => ue.UserId == userId)
                .Select(ue => new UserExperimenten { User = ue.User, Experiment = ue.Experiment })
                .ToList();

            return userExperiments;
        }
    }
}
