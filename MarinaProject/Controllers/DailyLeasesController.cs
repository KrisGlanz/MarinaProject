using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarinaProject.Data;
using MarinaProject.Models;

namespace MarinaProject.Controllers
{
    public class DailyLeasesController : Controller
    {
        private readonly MarinaDBContext _context;

        public DailyLeasesController(MarinaDBContext context)
        {
            _context = context;
        }

        // GET: DailyLeases
        public async Task<IActionResult> Index()
        {
              return View(await _context.DailyLease.ToListAsync());
        }

        // GET: DailyLeases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DailyLease == null)
            {
                return NotFound();
            }

            var dailyLease = await _context.DailyLease
                .FirstOrDefaultAsync(m => m.leaseId == id);
            if (dailyLease == null)
            {
                return NotFound();
            }

            return View(dailyLease);
        }

        // GET: DailyLeases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DailyLeases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("numDays,leaseId,Amount,startDate,endDate")] DailyLease dailyLease)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dailyLease);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dailyLease);
        }

        // GET: DailyLeases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DailyLease == null)
            {
                return NotFound();
            }

            var dailyLease = await _context.DailyLease.FindAsync(id);
            if (dailyLease == null)
            {
                return NotFound();
            }
            return View(dailyLease);
        }

        // POST: DailyLeases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("numDays,leaseId,Amount,startDate,endDate")] DailyLease dailyLease)
        {
            if (id != dailyLease.leaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dailyLease);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyLeaseExists(dailyLease.leaseId))
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
            return View(dailyLease);
        }

        // GET: DailyLeases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DailyLease == null)
            {
                return NotFound();
            }

            var dailyLease = await _context.DailyLease
                .FirstOrDefaultAsync(m => m.leaseId == id);
            if (dailyLease == null)
            {
                return NotFound();
            }

            return View(dailyLease);
        }

        // POST: DailyLeases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DailyLease == null)
            {
                return Problem("Entity set 'MarinaDBContext.DailyLease'  is null.");
            }
            var dailyLease = await _context.DailyLease.FindAsync(id);
            if (dailyLease != null)
            {
                _context.DailyLease.Remove(dailyLease);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DailyLeaseExists(int id)
        {
          return _context.DailyLease.Any(e => e.leaseId == id);
        }
    }
}
