using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Klooz3.Data;
using Klooz3.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Klooz3.Controllers
{
    public class TeamRegiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamRegiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeamRegies
        public async Task<IActionResult> Index()
        {
            var teamRegieLeden = await _context.teamregies
                .AsNoTracking()
                .ToListAsync();
            return View(teamRegieLeden);
        }

        // GET: TeamRegies/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.teamregies == null)
        //    {
        //        return NotFound();
        //    }

        //    var teamRegie = await _context.teamregies
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (teamRegie == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(teamRegie);
        //}

        // GET: TeamRegies/Create
        [Authorize(Roles = "Admin, TeamRegie")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeamRegies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, TeamRegie")]
        public async Task<IActionResult> Create([Bind("Id,Name,Emailadress")] TeamRegie teamRegie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teamRegie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teamRegie);
        }

        // GET: TeamRegies/Edit/5
        [Authorize(Roles = "Admin, TeamRegie")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.teamregies == null)
            {
                return NotFound();
            }

            var teamRegie = await _context.teamregies.FindAsync(id);
            if (teamRegie == null)
            {
                return NotFound();
            }
            return View(teamRegie);
        }

        // POST: TeamRegies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, TeamRegie")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Emailadress")] TeamRegie teamRegie)
        {
            if (id != teamRegie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamRegie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamRegieExists(teamRegie.Id))
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
            return View(teamRegie);
        }

        // GET: TeamRegies/Delete/5
        [Authorize(Roles = "Admin, TeamRegie")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.teamregies == null)
            {
                return NotFound();
            }

            var teamRegie = await _context.teamregies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamRegie == null)
            {
                return NotFound();
            }

            return View(teamRegie);
        }

        // POST: TeamRegies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, TeamRegie")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.teamregies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.teamregies'  is null.");
            }
            var teamRegie = await _context.teamregies.FindAsync(id);
            if (teamRegie != null)
            {
                _context.teamregies.Remove(teamRegie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamRegieExists(int id)
        {
          return (_context.teamregies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
