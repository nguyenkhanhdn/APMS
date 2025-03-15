using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APMS.Models;

namespace APMS.Controllers
{
    public class TariffsController : Controller
    {
        private readonly ParkingDbContext _context;

        public TariffsController(ParkingDbContext context)
        {
            _context = context;
        }

        // GET: Tariffs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tariff.ToListAsync());
        }

        // GET: Tariffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tariff = await _context.Tariff
                .FirstOrDefaultAsync(m => m.TariffId == id);
            if (tariff == null)
            {
                return NotFound();
            }

            return View(tariff);
        }

        // GET: Tariffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tariffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TariffId,TariffName,Price,Description")] Tariff tariff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tariff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tariff);
        }

        // GET: Tariffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tariff = await _context.Tariff.FindAsync(id);
            if (tariff == null)
            {
                return NotFound();
            }
            return View(tariff);
        }

        // POST: Tariffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TariffId,TariffName,Price,Description")] Tariff tariff)
        {
            if (id != tariff.TariffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tariff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TariffExists(tariff.TariffId))
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
            return View(tariff);
        }

        // GET: Tariffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tariff = await _context.Tariff
                .FirstOrDefaultAsync(m => m.TariffId == id);
            if (tariff == null)
            {
                return NotFound();
            }

            return View(tariff);
        }

        // POST: Tariffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tariff = await _context.Tariff.FindAsync(id);
            if (tariff != null)
            {
                _context.Tariff.Remove(tariff);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TariffExists(int id)
        {
            return _context.Tariff.Any(e => e.TariffId == id);
        }
    }
}
