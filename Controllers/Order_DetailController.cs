using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using thegioididong.Models;

namespace thegioididong.Controllers
{
    public class Order_DetailController : Controller
    {
        private readonly MyDBConext _context;

        public Order_DetailController(MyDBConext context)
        {
            _context = context;
        }

        // GET: Order_Detail
        public async Task<IActionResult> Index()
        {
            var myDBConext = _context.Order_Detail.Include(o => o.Order).Include(o => o.Product);
            return View(await myDBConext.ToListAsync());
        }

        // GET: Order_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Order_Detail == null)
            {
                return NotFound();
            }

            var order_Detail = await _context.Order_Detail
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id_D_Order == id);
            if (order_Detail == null)
            {
                return NotFound();
            }

            return View(order_Detail);
        }

        // GET: Order_Detail/Create
        public IActionResult Create()
        {
            ViewData["Id_Order"] = new SelectList(_context.Order, "Id_Order", "Id_Order");
            ViewData["Id_pro"] = new SelectList(_context.Product, "Id_pro", "Id_pro");
            return View();
        }

        // POST: Order_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_D_Order,Id_Order,Id_pro,amount")] Order_Detail order_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Order"] = new SelectList(_context.Order, "Id_Order", "Id_Order", order_Detail.Id_Order);
            ViewData["Id_pro"] = new SelectList(_context.Product, "Id_pro", "Id_pro", order_Detail.Id_pro);
            return View(order_Detail);
        }

        // GET: Order_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Order_Detail == null)
            {
                return NotFound();
            }

            var order_Detail = await _context.Order_Detail.FindAsync(id);
            if (order_Detail == null)
            {
                return NotFound();
            }
            ViewData["Id_Order"] = new SelectList(_context.Order, "Id_Order", "Id_Order", order_Detail.Id_Order);
            ViewData["Id_pro"] = new SelectList(_context.Product, "Id_pro", "Id_pro", order_Detail.Id_pro);
            return View(order_Detail);
        }

        // POST: Order_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_D_Order,Id_Order,Id_pro,amount")] Order_Detail order_Detail)
        {
            if (id != order_Detail.Id_D_Order)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Order_DetailExists(order_Detail.Id_D_Order))
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
            ViewData["Id_Order"] = new SelectList(_context.Order, "Id_Order", "Id_Order", order_Detail.Id_Order);
            ViewData["Id_pro"] = new SelectList(_context.Product, "Id_pro", "Id_pro", order_Detail.Id_pro);
            return View(order_Detail);
        }

        // GET: Order_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Order_Detail == null)
            {
                return NotFound();
            }

            var order_Detail = await _context.Order_Detail
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id_D_Order == id);
            if (order_Detail == null)
            {
                return NotFound();
            }

            return View(order_Detail);
        }

        // POST: Order_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Order_Detail == null)
            {
                return Problem("Entity set 'MyDBConext.Order_Detail'  is null.");
            }
            var order_Detail = await _context.Order_Detail.FindAsync(id);
            if (order_Detail != null)
            {
                _context.Order_Detail.Remove(order_Detail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Order_DetailExists(int id)
        {
          return (_context.Order_Detail?.Any(e => e.Id_D_Order == id)).GetValueOrDefault();
        }
    }
}
