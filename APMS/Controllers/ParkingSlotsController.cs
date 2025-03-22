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
    public class ParkingSlotsController : Controller
    {
        private readonly ParkingDbContext _context;

        public ParkingSlotsController(ParkingDbContext context)
        {
            _context = context;
        }

        // GET: ParkingSlots
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParkingSlots.ToListAsync());
        }

        // GET: ParkingSlots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSlot = await _context.ParkingSlots
                .FirstOrDefaultAsync(m => m.ParkingSlotId == id);
            if (parkingSlot == null)
            {
                return NotFound();
            }

            return View(parkingSlot);
        }

        // GET: ParkingSlots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkingSlots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParkingSlotId,SlotNumber,Status")] ParkingSlot parkingSlot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkingSlot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkingSlot);
        }

        // GET: ParkingSlots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSlot = await _context.ParkingSlots.FindAsync(id);
            if (parkingSlot == null)
            {
                return NotFound();
            }
            return View(parkingSlot);
        }

        // POST: ParkingSlots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParkingSlotId,SlotNumber,Status")] ParkingSlot parkingSlot)
        {
            if (id != parkingSlot.ParkingSlotId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingSlot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingSlotExists(parkingSlot.ParkingSlotId))
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
            return View(parkingSlot);
        }

        // GET: ParkingSlots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSlot = await _context.ParkingSlots
                .FirstOrDefaultAsync(m => m.ParkingSlotId == id);
            if (parkingSlot == null)
            {
                return NotFound();
            }

            return View(parkingSlot);
        }

        // POST: ParkingSlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkingSlot = await _context.ParkingSlots.FindAsync(id);
            if (parkingSlot != null)
            {
                _context.ParkingSlots.Remove(parkingSlot);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingSlotExists(int id)
        {
            return _context.ParkingSlots.Any(e => e.ParkingSlotId == id);
        }
    }
}
