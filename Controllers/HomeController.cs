using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using thegioididong.Models;

namespace hegioididong.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDBConext _context;
        public HomeController(MyDBConext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var myDBConext = _context.Product.Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Images);
            return View(await myDBConext.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(m => m.Id_pro == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

    }
}
