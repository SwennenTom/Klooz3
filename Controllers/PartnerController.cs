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
    public class PartnerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ImageConversionService _imageConversionService;

        public PartnerController(ApplicationDbContext context, ImageConversionService imageConversionService)
        {
            _context = context;
            _imageConversionService = imageConversionService;
        }

        // GET: Partner
        public async Task<IActionResult> Index()
        {
            var orderedPartners = await _context.partners
        .OrderBy(p => p.partnerDisplayOrder)
        .AsNoTracking()
        .ToListAsync();

            return View(orderedPartners);
        }

        // GET: Partner/Create
        [Authorize(Roles="Admin, TeamRegie")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, TeamRegie")]
        public async Task<IActionResult> Create([Bind("partnerId,partnerName,partnerAlt,partnerLink,partnerDisplayOrder")] Partner partner, IFormFile PartnerImageFile)
        {
            if (ModelState.IsValid)
            {
                if (PartnerImageFile != null && PartnerImageFile.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await PartnerImageFile.CopyToAsync(stream);
                        var webPImage = _imageConversionService.ConvertToWebP(stream.ToArray());
                        partner.partnerImage = webPImage;
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
        [Authorize(Roles = "Admin, TeamRegie")]
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
        [Authorize(Roles = "Admin, TeamRegie")]
        public async Task<IActionResult> Edit(int id, [Bind("partnerId,partnerAlt,partnerName,partnerLink,partnerDisplayOrder")] Partner partner, IFormFile? partnerImageFile)
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
                            var WebPImage = _imageConversionService.ConvertToWebP(stream.ToArray());
                            partner.partnerImage = WebPImage;
                        }
                    }

                    else
                    {
                        var existingPartner = await _context.partners
                            .AsNoTracking()
                            .FirstOrDefaultAsync(p => p.partnerId == id);

                        if (existingPartner != null)
                        {
                            partner.partnerImage = existingPartner.partnerImage;
                        }
                    }

                    using (var context = _context)
                    {
                        context.partners.Update(partner);
                        await context.SaveChangesAsync();
                    }
                    return RedirectToAction(nameof(Index));
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
        [Authorize(Roles = "Admin, TeamRegie")]
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
        [Authorize(Roles = "Admin, TeamRegie")]
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
