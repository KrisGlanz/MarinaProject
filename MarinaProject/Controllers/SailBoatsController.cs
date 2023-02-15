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
    public class SailBoatsController : Controller
    {
        private readonly MarinaDBContext _context;

        public SailBoatsController(MarinaDBContext context)
        {
            _context = context;
        }

        // GET: SailBoats
        public async Task<IActionResult> Index()
        {
              return View(await _context.SailBoats.ToListAsync());
        }

        // GET: SailBoats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SailBoats == null)
            {
                return NotFound();
            }

            var sailBoat = await _context.SailBoats
                .FirstOrDefaultAsync(m => m.BoatId == id);
            if (sailBoat == null)
            {
                return NotFound();
            }

            return View(sailBoat);
        }

        // GET: SailBoats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SailBoats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KneelDepth,NumberOfSails,MotorType,BoatId,BoatType,Registration,BoatLength,Manufacturer")] SailBoat sailBoat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sailBoat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sailBoat);
        }

        // GET: SailBoats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SailBoats == null)
            {
                return NotFound();
            }

            var sailBoat = await _context.SailBoats.FindAsync(id);
            if (sailBoat == null)
            {
                return NotFound();
            }
            return View(sailBoat);
        }

        // POST: SailBoats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KneelDepth,NumberOfSails,MotorType,BoatId,BoatType,Registration,BoatLength,Manufacturer")] SailBoat sailBoat)
        {
            if (id != sailBoat.BoatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sailBoat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SailBoatExists(sailBoat.BoatId))
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
            return View(sailBoat);
        }

        // GET: SailBoats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SailBoats == null)
            {
                return NotFound();
            }

            var sailBoat = await _context.SailBoats
                .FirstOrDefaultAsync(m => m.BoatId == id);
            if (sailBoat == null)
            {
                return NotFound();
            }

            return View(sailBoat);
        }

        // POST: SailBoats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SailBoats == null)
            {
                return Problem("Entity set 'MarinaDBContext.SailBoats'  is null.");
            }
            var sailBoat = await _context.SailBoats.FindAsync(id);
            if (sailBoat != null)
            {
                _context.SailBoats.Remove(sailBoat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SailBoatExists(int id)
        {
          return _context.SailBoats.Any(e => e.BoatId == id);
        }
    }
}
