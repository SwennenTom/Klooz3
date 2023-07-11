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

namespace Klooz3.Controllers
{
    public class PartnerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartnerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Partner
        public async Task<IActionResult> Index()
        {
              return _context.partners != null ? 
                          View(await _context.partners.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.partners'  is null.");
        }

        // GET: Partner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.partners == null)
            {
                return NotFound();
            }

            var partner = await _context.partners
                .FirstOrDefaultAsync(m => m.partnerId == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // GET: Partner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("partnerId,partnerName,partnerLink,partnerDisplayOrder")] Partner partner, IFormFile PartnerImageFile)
        {
            if (ModelState.IsValid)
            {
                if (PartnerImageFile != null && PartnerImageFile.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await PartnerImageFile.CopyToAsync(stream);
                        partner.partnerImage = stream.ToArray();
                    }
                }

                using (var context = _context)
                {
                    context.partners.Add(partner);
                    await context.SaveChangesAsync();
                }

                return RedirectToAction("Index"); // Redirect to the desired action after successful creation
            }

            return View(partner); // If there are validation errors, return the view with the submitted model
        }

        // GET: Partner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.partners == null)
            {
                return NotFound();
            }

            var partner = await _context.partners.FindAsync(id);
            if (partner == null)
            {
                return NotFound();
            }
            return View(partner);
        }

        // POST: Partner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("partnerId,partnerName,partnerLink,partnerDisplayOrder")] Partner partner, IFormFile partnerImageFile)
        {
            if (id != partner.partnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (partnerImageFile != null && partnerImageFile.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await partnerImageFile.CopyToAsync(stream);
                            partner.partnerImage = stream.ToArray();
                        }
                    }

                    using (var context = _context)
                    {
                        context.partners.Update(partner);
                        await context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnerExists(partner.partnerId))
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

            return View(partner);
        }


        // GET: Partner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.partners == null)
            {
                return NotFound();
            }

            var partner = await _context.partners
                .FirstOrDefaultAsync(m => m.partnerId == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // POST: Partner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.partners == null)
            {
                return Problem("Entity set 'ApplicationDbContext.partners'  is null.");
            }
            var partner = await _context.partners.FindAsync(id);
            if (partner != null)
            {
                _context.partners.Remove(partner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerExists(int id)
        {
          return (_context.partners?.Any(e => e.partnerId == id)).GetValueOrDefault();
        }
    }
}
