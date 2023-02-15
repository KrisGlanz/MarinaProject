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
    public class DocksController : Controller
    {
        private readonly MarinaDBContext _context;

        public DocksController(MarinaDBContext context)
        {
            _context = context;
        }

        // GET: Docks
        public async Task<IActionResult> Index()
        {
              return View(await _context.Docks.ToListAsync());
        }

        // GET: Docks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Docks == null)
            {
                return NotFound();
            }

            var dock = await _context.Docks
                .FirstOrDefaultAsync(m => m.DockId == id);
            if (dock == null)
            {
                return NotFound();
            }

            return View(dock);
        }

        // GET: Docks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Docks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DockId,Location,Electricity,Water")] Dock dock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dock);
        }

        // GET: Docks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Docks == null)
            {
                return NotFound();
            }

            var dock = await _context.Docks.FindAsync(id);
            if (dock == null)
            {
                return NotFound();
            }
            return View(dock);
        }

        // POST: Docks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DockId,Location,Electricity,Water")] Dock dock)
        {
            if (id != dock.DockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DockExists(dock.DockId))
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
            return View(dock);
        }

        // GET: Docks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Docks == null)
            {
                return NotFound();
            }

            var dock = await _context.Docks
                .FirstOrDefaultAsync(m => m.DockId == id);
            if (dock == null)
            {
                return NotFound();
            }

            return View(dock);
        }

        // POST: Docks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Docks == null)
            {
                return Problem("Entity set 'MarinaDBContext.Docks'  is null.");
            }
            var dock = await _context.Docks.FindAsync(id);
            if (dock != null)
            {
                _context.Docks.Remove(dock);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DockExists(int id)
        {
          return _context.Docks.Any(e => e.DockId == id);
        }
    }
}
