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
    public class UserPaymentTrackingsController : Controller
    {
        private readonly ParkingDbContext _context;

        public UserPaymentTrackingsController(ParkingDbContext context)
        {
            _context = context;
        }

        // GET: UserPaymentTrackings
        public async Task<IActionResult> Index()
        {
            var parkingDbContext = _context.UserPaymentTracking.Include(u => u.Tariff).Include(u => u.User);
            return View(await parkingDbContext.ToListAsync());
        }

        // GET: UserPaymentTrackings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPaymentTracking = await _context.UserPaymentTracking
                .Include(u => u.Tariff)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userPaymentTracking == null)
            {
                return NotFound();
            }

            return View(userPaymentTracking);
        }

        // GET: UserPaymentTrackings/Create
        public IActionResult Create()
        {
            ViewData["TariffId"] = new SelectList(_context.Tariff, "TariffId", "TariffId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: UserPaymentTrackings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,TariffId,PaymentDate,Amount,IsPaid")] UserPaymentTracking userPaymentTracking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userPaymentTracking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TariffId"] = new SelectList(_context.Tariff, "TariffId", "TariffId", userPaymentTracking.TariffId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", userPaymentTracking.UserId);
            return View(userPaymentTracking);
        }

        // GET: UserPaymentTrackings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPaymentTracking = await _context.UserPaymentTracking.FindAsync(id);
            if (userPaymentTracking == null)
            {
                return NotFound();
            }
            ViewData["TariffId"] = new SelectList(_context.Tariff, "TariffId", "TariffId", userPaymentTracking.TariffId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", userPaymentTracking.UserId);
            return View(userPaymentTracking);
        }

        // POST: UserPaymentTrackings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,TariffId,PaymentDate,Amount,IsPaid")] UserPaymentTracking userPaymentTracking)
        {
            if (id != userPaymentTracking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userPaymentTracking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserPaymentTrackingExists(userPaymentTracking.Id))
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
            ViewData["TariffId"] = new SelectList(_context.Tariff, "TariffId", "TariffId", userPaymentTracking.TariffId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", userPaymentTracking.UserId);
            return View(userPaymentTracking);
        }

        // GET: UserPaymentTrackings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPaymentTracking = await _context.UserPaymentTracking
                .Include(u => u.Tariff)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userPaymentTracking == null)
            {
                return NotFound();
            }

            return View(userPaymentTracking);
        }

        // POST: UserPaymentTrackings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userPaymentTracking = await _context.UserPaymentTracking.FindAsync(id);
            if (userPaymentTracking != null)
            {
                _context.UserPaymentTracking.Remove(userPaymentTracking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserPaymentTrackingExists(int id)
        {
            return _context.UserPaymentTracking.Any(e => e.Id == id);
        }
    }
}
