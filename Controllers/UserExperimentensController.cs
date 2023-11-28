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
    public class UserExperimentensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserExperimentensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserExperimentens
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.userexperimenten.Include(u => u.Experiment).Include(u => u.User);
            return View(await applicationDbContext.ToListAsync());
        }

        
        // GET: UserExperimentens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.userexperimenten == null)
            {
                return NotFound();
            }

            var userExperimenten = await _context.userexperimenten.FindAsync(id);
            if (userExperimenten == null)
            {
                return NotFound();
            }

            var userList = await _context.Users
        .Select(u => new { Id = u.Id, FullName = $"{((ApplicationUser)u).Firstname} {((ApplicationUser)u).Lastname}" })
        .ToListAsync();

            ViewData["ExperimentId"] = new SelectList(_context.experiments, "experimentId", "experimentName", userExperimenten.ExperimentId);
            ViewData["UserId"] = new SelectList(userList, "Id", "FullName", userExperimenten.UserId);
            return View(userExperimenten);
        }

        // POST: UserExperimentens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ExperimentId")] UserExperimenten userExperimenten)
        {
            if (id != userExperimenten.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userExperimenten);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExperimentenExists(userExperimenten.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ExperimentId"] = new SelectList(_context.experiments, "experimentId", "experimentCardBackText", userExperimenten.ExperimentId);
            ViewData["UserId"] = new SelectList(_context.applicationuser, "Id", "Id", userExperimenten.UserId);
            return View(userExperimenten);
        }

        private bool UserExperimentenExists(int id)
        {
          return (_context.userexperimenten?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
