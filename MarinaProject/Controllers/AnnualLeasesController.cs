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
    public class AnnualLeasesController : Controller
    {
        private readonly MarinaDBContext _context;

        public AnnualLeasesController(MarinaDBContext context)
        {
            _context = context;
        }

        // GET: AnnualLeases
        public async Task<IActionResult> Index()
        {
              return View(await _context.AnnualLeases.ToListAsync());
        }

        // GET: AnnualLeases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AnnualLeases == null)
            {
                return NotFound();
            }

            var annualLease = await _context.AnnualLeases
                .FirstOrDefaultAsync(m => m.leaseId == id);
            if (annualLease == null)
            {
                return NotFound();
            }

            return View(annualLease);
        }

        // GET: AnnualLeases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnnualLeases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("monthlyPay,balanceDue,leaseId,Amount,startDate,endDate")] AnnualLease annualLease)
        {
            if (ModelState.IsValid)
            {
                _context.Add(annualLease);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(annualLease);
        }

        // GET: AnnualLeases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AnnualLeases == null)
            {
                return NotFound();
            }

            var annualLease = await _context.AnnualLeases.FindAsync(id);
            if (annualLease == null)
            {
                return NotFound();
            }
            return View(annualLease);
        }

        // POST: AnnualLeases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("monthlyPay,balanceDue,leaseId,Amount,startDate,endDate")] AnnualLease annualLease)
        {
            if (id != annualLease.leaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(annualLease);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnualLeaseExists(annualLease.leaseId))
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
            return View(annualLease);
        }

        // GET: AnnualLeases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AnnualLeases == null)
            {
                return NotFound();
            }

            var annualLease = await _context.AnnualLeases
                .FirstOrDefaultAsync(m => m.leaseId == id);
            if (annualLease == null)
            {
                return NotFound();
            }

            return View(annualLease);
        }

        // POST: AnnualLeases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AnnualLeases == null)
            {
                return Problem("Entity set 'MarinaDBContext.AnnualLeases'  is null.");
            }
            var annualLease = await _context.AnnualLeases.FindAsync(id);
            if (annualLease != null)
            {
                _context.AnnualLeases.Remove(annualLease);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnualLeaseExists(int id)
        {
          return _context.AnnualLeases.Any(e => e.leaseId == id);
        }
    }
}
