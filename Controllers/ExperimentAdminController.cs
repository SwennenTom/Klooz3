using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Klooz3.Data;
using Klooz3.Models;

namespace Klooz3.Controllers
{
    public class ExperimentAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExperimentAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExperimentAdmin
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.experiments.Include(e => e.categories);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ExperimentAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.experiments == null)
            {
                return NotFound();
            }

            var experiment = await _context.experiments
                .Include(e => e.categories)
                .FirstOrDefaultAsync(m => m.experimentId == id);
            if (experiment == null)
            {
                return NotFound();
            }

            return View(experiment);
        }

        // GET: ExperimentAdmin/Create
        public IActionResult Create()
        {
            ViewData["categoriesId"] = new SelectList(_context.categories, "categoriesId", "name");
            return View();
        }

        // POST: ExperimentAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("experimentId,experimentImage,experimentName,experimentCardFrontText,experimentCardBackText,categoriesId,experimentShortText,experimentKickOffDate,experimentEndDate,experimentwickedProblemsToSmartSolutions,experimenttargetAndImpact,experimentTouchstone,experimentPhotos,experimentPublished,experimentCreatedDate,experimentLastModified,experimentStatus")] Experiment experiment, IFormFile ExperimentImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ExperimentImageFile != null && ExperimentImageFile.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await ExperimentImageFile.CopyToAsync(stream);
                        experiment.experimentImage = stream.ToArray();
                    }
                }

                using (var context = _context)
                {
                    context.experiments.Add(experiment);
                    await context.SaveChangesAsync();
                }

                return RedirectToAction("Index"); // Redirect to the desired action after successful creation
            }

            return View(experiment);

            //if (ModelState.IsValid)
            //{
            //    _context.Add(experiment);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["categoriesId"] = new SelectList(_context.categories, "categoriesId", "name", experiment.categoriesId);
            //return View(experiment);
        }

        // GET: ExperimentAdmin/Edit/5
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
            ViewData["categoriesId"] = new SelectList(_context.categories, "categoriesId", "categoriesId", experiment.categoriesId);
            return View(experiment);
        }

        // POST: ExperimentAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("experimentId,experimentImage,experimentName,experimentCardFrontText,experimentCardBackText,categoriesId,experimentShortText,experimentKickOffDate,experimentEndDate,experimentwickedProblemsToSmartSolutions,experimenttargetAndImpact,experimentTouchstone,experimentPhotos,experimentPublished,experimentCreatedDate,experimentLastModified,experimentStatus")] Experiment experiment)
        {
            if (id != experiment.experimentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experiment);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["categoriesId"] = new SelectList(_context.categories, "categoriesId", "categoriesId", experiment.categoriesId);
            return View(experiment);
        }

        // GET: ExperimentAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.experiments == null)
            {
                return NotFound();
            }

            var experiment = await _context.experiments
                .Include(e => e.categories)
                .FirstOrDefaultAsync(m => m.experimentId == id);
            if (experiment == null)
            {
                return NotFound();
            }

            return View(experiment);
        }

        // POST: ExperimentAdmin/Delete/5
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
