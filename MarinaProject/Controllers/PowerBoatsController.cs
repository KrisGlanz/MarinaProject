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
    public class PowerBoatsController : Controller
    {
        private readonly MarinaDBContext _context;

        public PowerBoatsController(MarinaDBContext context)
        {
            _context = context;
        }

        // GET: PowerBoats
        public async Task<IActionResult> Index()
        {
              return View(await _context.PowerBoats.ToListAsync());
        }

        // GET: PowerBoats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PowerBoats == null)
            {
                return NotFound();
            }

            var powerBoat = await _context.PowerBoats
                .FirstOrDefaultAsync(m => m.BoatId == id);
            if (powerBoat == null)
            {
                return NotFound();
            }

            return View(powerBoat);
        }

        // GET: PowerBoats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PowerBoats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumberOfEngines,FuelType,BoatId,BoatType,Registration,BoatLength,Manufacturer")] PowerBoat powerBoat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(powerBoat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(powerBoat);
        }

        // GET: PowerBoats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PowerBoats == null)
            {
                return NotFound();
            }

            var powerBoat = await _context.PowerBoats.FindAsync(id);
            if (powerBoat == null)
            {
                return NotFound();
            }
            return View(powerBoat);
        }

        // POST: PowerBoats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumberOfEngines,FuelType,BoatId,BoatType,Registration,BoatLength,Manufacturer")] PowerBoat powerBoat)
        {
            if (id != powerBoat.BoatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(powerBoat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PowerBoatExists(powerBoat.BoatId))
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
            return View(powerBoat);
        }

        // GET: PowerBoats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PowerBoats == null)
            {
                return NotFound();
            }

            var powerBoat = await _context.PowerBoats
                .FirstOrDefaultAsync(m => m.BoatId == id);
            if (powerBoat == null)
            {
                return NotFound();
            }

            return View(powerBoat);
        }

        // POST: PowerBoats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PowerBoats == null)
            {
                return Problem("Entity set 'MarinaDBContext.PowerBoats'  is null.");
            }
            var powerBoat = await _context.PowerBoats.FindAsync(id);
            if (powerBoat != null)
            {
                _context.PowerBoats.Remove(powerBoat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PowerBoatExists(int id)
        {
          return _context.PowerBoats.Any(e => e.BoatId == id);
        }
    }
}
