using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Klooz3.Data;
using Klooz3.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Drawing.Imaging;

namespace Klooz3.Controllers
{
    public class ExperimentenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserExperimenten _userExperimenten;
        private readonly ExperimentRepo _experimentrepo;

        public ExperimentenController(UserService userService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, Models.UserExperimenten userExperimenten, ExperimentRepo userExperimentenService, ApplicationDbContext dbContext)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
            _userExperimenten = userExperimenten;
            _experimentrepo = userExperimentenService;
            _context = dbContext;
        }


        [HttpGet]
        public IActionResult GetExperimentDetails(int id)
        {
            var experiment = _context.experiments.Find(id);
            return Json(experiment);
        }

        [Authorize]
        public IActionResult Admin()
        {
            // Get the currently logged-in user
            var currentUser = _userManager.GetUserAsync(User).Result;

            // Retrieve experimenten based on the user's roles
            var experimenten = _userManager.IsInRoleAsync(currentUser, "admin").Result || _userManager.IsInRoleAsync(currentUser, "teamregie").Result
        ? _experimentrepo.GetAllUserExperimenten()
        : _experimentrepo.GetUserExperimentenByUserId(currentUser.Id);

            return View(experimenten);
        }


        // GET: Experimenten
        public async Task<IActionResult> Index()
        {
            var experiments = await _context.experiments
                .Where(e => e.experimentPublished)
                .ToListAsync();

            return View(experiments);
        }

        // GET: Experimenten/Create

        [Authorize]
        public IActionResult Create()
        {

            return View();
        }

        // POST: Experimenten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("experimentId,experimentName,experimentCardBackText,experimentShortText,experimentPublished")] Experiment experiment, IFormFile experimentImage)
        {
            
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);

                if (experimentImage != null && experimentImage.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await experimentImage.CopyToAsync(stream);
                        experiment.experimentImage = stream.ToArray();
                    }
                }

                _context.Add(experiment);
                await _context.SaveChangesAsync();

                var userExperiment = new UserExperimenten
                {
                    UserId = currentUser.Id,
                    ExperimentId = experiment.experimentId
                };
                _context.Add(userExperiment);
                await _context.SaveChangesAsync();

                return RedirectToAction("Admin");
            }

            if (!ModelState.IsValid)
            {
                // Log or inspect ModelState errors
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                // ...
            }

            return View(experiment);
        }

        [Authorize]
        // GET: Experimenten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.experiments == null)
            {
                return NotFound();
            }

            var experiment = await _context.experiments.FindAsync(id);
            if (experiment == null)
            {
                return NotFound();
            }
            return View(experiment);
        }

        // POST: Experimenten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("experimentId,experimentName,experimentCardBackText,experimentShortText,experimentPhotos,experimentPublished")] Experiment experiment, IFormFile? experimentImage)
        {
            if(id != experiment.experimentId)
            {
                return NotFound();
            }

            try
            {
                if (experimentImage != null && experimentImage.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await experimentImage.CopyToAsync(stream);
                        experiment.experimentImage = stream.ToArray();
                    }
                }
                else
                {
                    var existingExperiment = await _context.experiments
                        .AsNoTracking()
                        .FirstOrDefaultAsync(p => p.experimentId == id);

                    if (existingExperiment != null)
                    {
                        experiment.experimentImage = existingExperiment.experimentImage;
                    }
                }

                using (var context = _context)
                {
                    context.experiments.Update(experiment);
                    await context.SaveChangesAsync();
                }
                return RedirectToAction("Admin");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperimentExists(experiment.experimentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

    }

    // GET: Experimenten/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        try
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiment = await _context.experiments
                .FirstOrDefaultAsync(m => m.experimentId == id);

            if (experiment == null)
            {
                return NotFound();
            }

            return View(experiment);
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }


    // POST: Experimenten/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.experiments == null)
        {
            return Problem("Entity set 'ApplicationDbContext.experiments'  is null.");
        }
        var experiment = await _context.experiments.FindAsync(id);
        if (experiment != null)
        {
            _context.experiments.Remove(experiment);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ExperimentExists(int id)
    {
        return (_context.experiments?.Any(e => e.experimentId == id)).GetValueOrDefault();
    }
}
}
