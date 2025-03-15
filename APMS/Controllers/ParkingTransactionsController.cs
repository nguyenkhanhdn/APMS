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
    public class ParkingTransactionsController : Controller
    {
        private readonly ParkingDbContext _context;

        public ParkingTransactionsController(ParkingDbContext context)
        {
            _context = context;
        }

        // GET: ParkingTransactions
        public async Task<IActionResult> Index()
        {
            var parkingDbContext = _context.ParkingTransactions.Include(p => p.ParkingSlot).Include(p => p.User).Include(p => p.Vehicle);
            return View(await parkingDbContext.ToListAsync());
        }

        // GET: ParkingTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingTransaction = await _context.ParkingTransactions
                .Include(p => p.ParkingSlot)
                .Include(p => p.User)
                .Include(p => p.Vehicle)
                .FirstOrDefaultAsync(m => m.ParkingTransactionId == id);
            if (parkingTransaction == null)
            {
                return NotFound();
            }

            return View(parkingTransaction);
        }

        // GET: ParkingTransactions/Create
        public IActionResult Create()
        {
            ViewData["SlotId"] = new SelectList(_context.ParkingSlots, "ParkingSlotId", "ParkingSlotId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId");
            return View();
        }

        // POST: ParkingTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParkingTransactionId,VehicleId,SlotId,UserId,EntryTime,ExitTime,TotalAmount")] ParkingTransaction parkingTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkingTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SlotId"] = new SelectList(_context.ParkingSlots, "ParkingSlotId", "ParkingSlotId", parkingTransaction.SlotId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", parkingTransaction.UserId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId", parkingTransaction.VehicleId);
            return View(parkingTransaction);
        }

        // GET: ParkingTransactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingTransaction = await _context.ParkingTransactions.FindAsync(id);
            if (parkingTransaction == null)
            {
                return NotFound();
            }
            ViewData["SlotId"] = new SelectList(_context.ParkingSlots, "ParkingSlotId", "ParkingSlotId", parkingTransaction.SlotId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", parkingTransaction.UserId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId", parkingTransaction.VehicleId);
            return View(parkingTransaction);
        }

        // POST: ParkingTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParkingTransactionId,VehicleId,SlotId,UserId,EntryTime,ExitTime,TotalAmount")] ParkingTransaction parkingTransaction)
        {
            if (id != parkingTransaction.ParkingTransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingTransactionExists(parkingTransaction.ParkingTransactionId))
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
            ViewData["SlotId"] = new SelectList(_context.ParkingSlots, "ParkingSlotId", "ParkingSlotId", parkingTransaction.SlotId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", parkingTransaction.UserId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId", parkingTransaction.VehicleId);
            return View(parkingTransaction);
        }

        // GET: ParkingTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingTransaction = await _context.ParkingTransactions
                .Include(p => p.ParkingSlot)
                .Include(p => p.User)
                .Include(p => p.Vehicle)
                .FirstOrDefaultAsync(m => m.ParkingTransactionId == id);
            if (parkingTransaction == null)
            {
                return NotFound();
            }

            return View(parkingTransaction);
        }

        // POST: ParkingTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkingTransaction = await _context.ParkingTransactions.FindAsync(id);
            if (parkingTransaction != null)
            {
                _context.ParkingTransactions.Remove(parkingTransaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingTransactionExists(int id)
        {
            return _context.ParkingTransactions.Any(e => e.ParkingTransactionId == id);
        }
    }
}
