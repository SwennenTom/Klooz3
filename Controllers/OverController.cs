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
    public class OverController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OverController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orderedPartners = await _context.partners
        .OrderBy(p => p.partnerDisplayOrder)
        .AsNoTracking()
        .ToListAsync();

            return View(orderedPartners);
        }
    }
}
