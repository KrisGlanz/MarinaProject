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
    public class RowBoatsController : Controller
    {
        private readonly MarinaDBContext _context;

        public RowBoatsController(MarinaDBContext context)
        {
            _context = context;
        }

        // GET: RowBoats
        public async Task<IActionResult> Index()
        {
              return View(await _context.RowBoat.ToListAsync());
        }

        // GET: RowBoats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RowBoat == null)
            {
                return NotFound();
            }

            var rowBoat = await _context.RowBoat
                .FirstOrDefaultAsync(m => m.BoatId == id);
            if (rowBoat == null)
            {
                return NotFound();
            }

            return View(rowBoat);
        }

        // GET: RowBoats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RowBoats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumberOfRowers,Motor,BoatId,BoatType,Registration,BoatLength,Manufacturer")] RowBoat rowBoat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rowBoat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rowBoat);
        }

        // GET: RowBoats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RowBoat == null)
            {
                return NotFound();
            }

            var rowBoat = await _context.RowBoat.FindAsync(id);
            if (rowBoat == null)
            {
                return NotFound();
            }
            return View(rowBoat);
        }

        // POST: RowBoats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumberOfRowers,Motor,BoatId,BoatType,Registration,BoatLength,Manufacturer")] RowBoat rowBoat)
        {
            if (id != rowBoat.BoatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rowBoat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RowBoatExists(rowBoat.BoatId))
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
            return View(rowBoat);
        }

        // GET: RowBoats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RowBoat == null)
            {
                return NotFound();
            }

            var rowBoat = await _context.RowBoat
                .FirstOrDefaultAsync(m => m.BoatId == id);
            if (rowBoat == null)
            {
                return NotFound();
            }

            return View(rowBoat);
        }

        // POST: RowBoats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RowBoat == null)
            {
                return Problem("Entity set 'MarinaDBContext.RowBoat'  is null.");
            }
            var rowBoat = await _context.RowBoat.FindAsync(id);
            if (rowBoat != null)
            {
                _context.RowBoat.Remove(rowBoat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RowBoatExists(int id)
        {
          return _context.RowBoat.Any(e => e.BoatId == id);
        }
    }
}
