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
    public class SlipsController : Controller
    {
        private readonly MarinaDBContext _context;

        public SlipsController(MarinaDBContext context)
        {
            _context = context;
        }

        // GET: Slips
        public async Task<IActionResult> Index()
        {
              return View(await _context.Slips.ToListAsync());
        }

        // GET: Slips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Slips == null)
            {
                return NotFound();
            }

            var slip = await _context.Slips
                .FirstOrDefaultAsync(m => m.slipId == id);
            if (slip == null)
            {
                return NotFound();
            }

            return View(slip);
        }

        // GET: Slips/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Slips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("slipId,width,slipLength")] Slip slip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slip);
        }

        // GET: Slips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Slips == null)
            {
                return NotFound();
            }

            var slip = await _context.Slips.FindAsync(id);
            if (slip == null)
            {
                return NotFound();
            }
            return View(slip);
        }

        // POST: Slips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("slipId,width,slipLength")] Slip slip)
        {
            if (id != slip.slipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlipExists(slip.slipId))
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
            return View(slip);
        }

        // GET: Slips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Slips == null)
            {
                return NotFound();
            }

            var slip = await _context.Slips
                .FirstOrDefaultAsync(m => m.slipId == id);
            if (slip == null)
            {
                return NotFound();
            }

            return View(slip);
        }

        // POST: Slips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Slips == null)
            {
                return Problem("Entity set 'MarinaDBContext.Slips'  is null.");
            }
            var slip = await _context.Slips.FindAsync(id);
            if (slip != null)
            {
                _context.Slips.Remove(slip);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlipExists(int id)
        {
          return _context.Slips.Any(e => e.slipId == id);
        }
    }
}
