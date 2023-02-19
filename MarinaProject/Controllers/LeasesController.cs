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
    public class LeasesController : Controller
    {
        private readonly MarinaDBContext _context;

        public LeasesController(MarinaDBContext context)
        {
            _context = context;
        }

        // GET: Leases
        public async Task<IActionResult> Index()
        {
              return View(await _context.Leases.ToListAsync());
        }

        // GET: Leases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Leases == null)
            {
                return NotFound();
            }

            var leases = await _context.Leases
                .FirstOrDefaultAsync(m => m.leaseId == id);
            if (leases == null)
            {
                return NotFound();
            }

            return View(leases);
        }

        // GET: Leases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("leaseId,Amount,startDate,endDate")] Leases leases)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leases);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leases);
        }

        // GET: Leases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Leases == null)
            {
                return NotFound();
            }

            var leases = await _context.Leases.FindAsync(id);
            if (leases == null)
            {
                return NotFound();
            }
            return View(leases);
        }

        // POST: Leases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("leaseId,Amount,startDate,endDate")] Leases leases)
        {
            if (id != leases.leaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leases);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeasesExists(leases.leaseId))
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
            return View(leases);
        }

        // GET: Leases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Leases == null)
            {
                return NotFound();
            }

            var leases = await _context.Leases
                .FirstOrDefaultAsync(m => m.leaseId == id);
            if (leases == null)
            {
                return NotFound();
            }

            return View(leases);
        }

        // POST: Leases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Leases == null)
            {
                return Problem("Entity set 'MarinaDBContext.Leases'  is null.");
            }
            var leases = await _context.Leases.FindAsync(id);
            if (leases != null)
            {
                _context.Leases.Remove(leases);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeasesExists(int id)
        {
          return _context.Leases.Any(e => e.leaseId == id);
        }
    }
}
