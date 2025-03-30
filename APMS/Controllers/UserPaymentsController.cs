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
    public class UserPaymentsController : Controller
    {
        private readonly ParkingDbContext _context;

        public UserPaymentsController(ParkingDbContext context)
        {
            _context = context;
        }

        // GET: UserPayments
        public async Task<IActionResult> Index()
        {
            var parkingDbContext = _context.UserPayments.Include(u => u.Tariff).Include(u => u.User);
            return View(await parkingDbContext.ToListAsync());
        }

        // GET: UserPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPayment = await _context.UserPayments
                .Include(u => u.Tariff)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userPayment == null)
            {
                return NotFound();
            }

            return View(userPayment);
        }

        // GET: UserPayments/Create
        public IActionResult Create()
        {
            ViewData["TariffId"] = new SelectList(_context.Tariff, "TariffId", "TariffName");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName");
            return View();
        }

        // POST: UserPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,TariffId,PaymentDate,Amount,IsPaid")] UserPayment userPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TariffId"] = new SelectList(_context.Tariff, "TariffId", "TariffName", userPayment.TariffId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName", userPayment.UserId);
            return View(userPayment);
        }

        // GET: UserPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPayment = await _context.UserPayments.FindAsync(id);
            if (userPayment == null)
            {
                return NotFound();
            }
            ViewData["TariffId"] = new SelectList(_context.Tariff, "TariffId", "TariffName", userPayment.TariffId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName", userPayment.UserId);
            return View(userPayment);
        }

        // POST: UserPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,TariffId,PaymentDate,Amount,IsPaid")] UserPayment userPayment)
        {
            if (id != userPayment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserPaymentExists(userPayment.Id))
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
            ViewData["TariffId"] = new SelectList(_context.Tariff, "TariffId", "TariffName", userPayment.TariffId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName", userPayment.UserId);
            return View(userPayment);
        }

        // GET: UserPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPayment = await _context.UserPayments
                .Include(u => u.Tariff)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userPayment == null)
            {
                return NotFound();
            }

            return View(userPayment);
        }

        // POST: UserPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userPayment = await _context.UserPayments.FindAsync(id);
            if (userPayment != null)
            {
                _context.UserPayments.Remove(userPayment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserPaymentExists(int id)
        {
            return _context.UserPayments.Any(e => e.Id == id);
        }
    }
}
