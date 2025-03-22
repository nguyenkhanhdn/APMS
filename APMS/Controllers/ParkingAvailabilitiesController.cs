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
    public class ParkingAvailabilitiesController : Controller
    {
        private readonly ParkingDbContext _context;

        public ParkingAvailabilitiesController(ParkingDbContext context)
        {
            _context = context;
        }

        // GET: ParkingAvailabilities
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParkingAvailabilities.ToListAsync());
        }

        // GET: ParkingAvailabilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingAvailability = await _context.ParkingAvailabilities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingAvailability == null)
            {
                return NotFound();
            }

            return View(parkingAvailability);
        }

        // GET: ParkingAvailabilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkingAvailabilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TotalSlots,AvailableSlots")] ParkingAvailability parkingAvailability)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkingAvailability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkingAvailability);
        }

        // GET: ParkingAvailabilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingAvailability = await _context.ParkingAvailabilities.FindAsync(id);
            if (parkingAvailability == null)
            {
                return NotFound();
            }
            return View(parkingAvailability);
        }

        // POST: ParkingAvailabilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TotalSlots,AvailableSlots")] ParkingAvailability parkingAvailability)
        {
            if (id != parkingAvailability.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingAvailability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingAvailabilityExists(parkingAvailability.Id))
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
            return View(parkingAvailability);
        }

        // GET: ParkingAvailabilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingAvailability = await _context.ParkingAvailabilities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingAvailability == null)
            {
                return NotFound();
            }

            return View(parkingAvailability);
        }

        // POST: ParkingAvailabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkingAvailability = await _context.ParkingAvailabilities.FindAsync(id);
            if (parkingAvailability != null)
            {
                _context.ParkingAvailabilities.Remove(parkingAvailability);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingAvailabilityExists(int id)
        {
            return _context.ParkingAvailabilities.Any(e => e.Id == id);
        }
    }
}
