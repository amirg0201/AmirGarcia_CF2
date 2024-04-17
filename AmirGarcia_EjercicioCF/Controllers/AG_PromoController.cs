using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AmirGarcia_EjercicioCF.Data;
using AmirGarcia_EjercicioCF.Models;

namespace AmirGarcia_EjercicioCF.Controllers
{
    public class AG_PromoController : Controller
    {
        private readonly AmirGarcia_EjercicioCFContext _context;

        public AG_PromoController(AmirGarcia_EjercicioCFContext context)
        {
            _context = context;
        }

        // GET: AG_Promo
        public async Task<IActionResult> Index()
        {
            var amirGarcia_EjercicioCFContext = _context.Promo.Include(a => a.Burger);
            return View(await amirGarcia_EjercicioCFContext.ToListAsync());
        }

        // GET: AG_Promo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aG_Promo = await _context.Promo
                .Include(a => a.Burger)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aG_Promo == null)
            {
                return NotFound();
            }

            return View(aG_Promo);
        }

        // GET: AG_Promo/Create
        public IActionResult Create()
        {
            ViewData["BurgerId"] = new SelectList(_context.Burger, "Burgerid", "Name");
            return View();
        }

        // POST: AG_Promo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,descripcion,fechaProm,BurgerId")] AG_Promo aG_Promo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aG_Promo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurgerId"] = new SelectList(_context.Burger, "Burgerid", "Name", aG_Promo.BurgerId);
            return View(aG_Promo);
        }

        // GET: AG_Promo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aG_Promo = await _context.Promo.FindAsync(id);
            if (aG_Promo == null)
            {
                return NotFound();
            }
            ViewData["BurgerId"] = new SelectList(_context.Burger, "Burgerid", "Name", aG_Promo.BurgerId);
            return View(aG_Promo);
        }

        // POST: AG_Promo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,descripcion,fechaProm,BurgerId")] AG_Promo aG_Promo)
        {
            if (id != aG_Promo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aG_Promo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AG_PromoExists(aG_Promo.ID))
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
            ViewData["BurgerId"] = new SelectList(_context.Burger, "Burgerid", "Name", aG_Promo.BurgerId);
            return View(aG_Promo);
        }

        // GET: AG_Promo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aG_Promo = await _context.Promo
                .Include(a => a.Burger)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aG_Promo == null)
            {
                return NotFound();
            }

            return View(aG_Promo);
        }

        // POST: AG_Promo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aG_Promo = await _context.Promo.FindAsync(id);
            if (aG_Promo != null)
            {
                _context.Promo.Remove(aG_Promo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AG_PromoExists(int id)
        {
            return _context.Promo.Any(e => e.ID == id);
        }
    }
}
