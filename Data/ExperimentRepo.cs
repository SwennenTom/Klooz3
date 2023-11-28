using Klooz3.Data;
using Klooz3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Klooz3.Data
{
    public class ExperimentRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public ExperimentRepo(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public List<UserExperimenten> GetAllUserExperimenten()
        {
            var userExperimentList = _dbContext.experiments
                .Select(e => new UserExperimenten
                {
                    Experiment = e,
                    User = GetUserForExperiment(_dbContext, e.experimentId).Result // Pass _dbContext as a parameter
                                                                                   // Set other properties as needed
                })
                .ToList();

            return userExperimentList;
        }

        private static async Task<ApplicationUser> GetUserForExperiment(ApplicationDbContext dbContext, int experimentId)
        {
            // Use dbContext to get the user by experimentId
            var userExperiment = await dbContext.userexperimenten
                .FirstOrDefaultAsync(ue => ue.ExperimentId == experimentId);

            return userExperiment?.User;
        }


        //public List<UserExperimenten> GetAllUserExperimenten()
        //{
        //    return _dbContext.experiments
        //        .Select(e => new UserExperimenten { Experiment = e })
        //        .ToList();
        //}

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
