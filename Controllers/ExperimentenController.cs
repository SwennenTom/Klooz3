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
    public class ExperimentenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExperimentenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Experimenten
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.experiments;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Experimenten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.experiments == null)
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

        // GET: Experimenten/Create
        public IActionResult Create()
        {
            ViewData["categoriesId"] = new SelectList(_context.categories, "categoriesId", "name");
            return View();
        }

        // POST: Experimenten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("experimentId,experimentImage,experimentName,experimentCardBackText,experimentShortText,experimentPhotos,experimentPublished")] Experiment experiment, IFormFile experimentCover)
        {
            if (ModelState.IsValid)
            {
                if (experimentCover != null && experimentCover.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await experimentCover.CopyToAsync(stream);
                        experiment.experimentImage = stream.ToArray();
                    }
                }

                _context.Add(experiment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experiment);
        }

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
        public async Task<IActionResult> Edit(int id, [Bind("experimentId,experimentImage,experimentName,experimentCardBackText,experimentShortText,experimentPhotos,experimentPublished")] Experiment experiment)
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
            return View(experiment);
        }

        // GET: Experimenten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.experiments == null)
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
