using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APMS.Models;
using Microsoft.AspNetCore.Authorization;

namespace APMS.Controllers
{
    [Authorize()]
    public class TransactionsController : Controller
    {
        private readonly ParkingDbContext _context;

        public TransactionsController(ParkingDbContext context)
        {
            _context = context;
        }
        public int GetVehicleIdByEmail(string email)
        {            
            var vehicle = _context.Vehicles.Include(v => v.User).FirstOrDefault(v => v.User.Email == email);
            if (vehicle != null)
            {
                return vehicle.VehicleId;
            }
            else
            {
                return -1;
            }
        }

        // GET: Transactions
        public async Task<IActionResult> Index(string email)
        {
            var vehicleId = GetVehicleIdByEmail(email);

            var parkingDbContext = _context.Transactions.Include(t => t.ParkingSlot).Include(t => t.Vehicle);

            return View(await parkingDbContext.Where(t=>t.VehicleId==vehicleId).ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.ParkingSlot)
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["ParkingSlotId"] = new SelectList(_context.ParkingSlots, "ParkingSlotId", "SlotNumber");
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "LicensePlate");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,VehicleId,ParkingSlotId,EntryTime,ExitTime,TotalAmount")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParkingSlotId"] = new SelectList(_context.ParkingSlots, "ParkingSlotId", "SlotNumber", transaction.ParkingSlotId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "LicensePlate", transaction.VehicleId);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["ParkingSlotId"] = new SelectList(_context.ParkingSlots, "ParkingSlotId", "SlotNumber", transaction.ParkingSlotId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "LicensePlate", transaction.VehicleId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,VehicleId,ParkingSlotId,EntryTime,ExitTime,TotalAmount")] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionId))
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
            ViewData["ParkingSlotId"] = new SelectList(_context.ParkingSlots, "ParkingSlotId", "SlotNumber", transaction.ParkingSlotId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "LicensePlate", transaction.VehicleId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.ParkingSlot)
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.TransactionId == id);
        }
    }
}
