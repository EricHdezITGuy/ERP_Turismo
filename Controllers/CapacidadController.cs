using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminTurismoERP;

namespace AdminTurismoERP.Controllers
{
    public class CapacidadController : Controller
    {
        private readonly AdminToursContext _context;

        public CapacidadController(AdminToursContext context)
        {
            _context = context;
        }

        // GET: Capacidad
        public async Task<IActionResult> Index()
        {
              return _context.Capacidads != null ? 
                          View(await _context.Capacidads.ToListAsync()) :
                          Problem("Entity set 'AdminToursContext.Capacidads'  is null.");
        }

        // GET: Capacidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Capacidads == null)
            {
                return NotFound();
            }

            var capacidad = await _context.Capacidads
                .FirstOrDefaultAsync(m => m.CapacidadId == id);
            if (capacidad == null)
            {
                return NotFound();
            }

            return View(capacidad);
        }

        // GET: Capacidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Capacidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CapacidadId,CapacidadTour")] Capacidad capacidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(capacidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(capacidad);
        }

        // GET: Capacidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Capacidads == null)
            {
                return NotFound();
            }

            var capacidad = await _context.Capacidads.FindAsync(id);
            if (capacidad == null)
            {
                return NotFound();
            }
            return View(capacidad);
        }

        // POST: Capacidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CapacidadId,CapacidadTour")] Capacidad capacidad)
        {
            if (id != capacidad.CapacidadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(capacidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapacidadExists(capacidad.CapacidadId))
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
            return View(capacidad);
        }

        // GET: Capacidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Capacidads == null)
            {
                return NotFound();
            }

            var capacidad = await _context.Capacidads
                .FirstOrDefaultAsync(m => m.CapacidadId == id);
            if (capacidad == null)
            {
                return NotFound();
            }

            return View(capacidad);
        }

        // POST: Capacidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Capacidads == null)
            {
                return Problem("Entity set 'AdminToursContext.Capacidads'  is null.");
            }
            var capacidad = await _context.Capacidads.FindAsync(id);
            if (capacidad != null)
            {
                _context.Capacidads.Remove(capacidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CapacidadExists(int id)
        {
          return (_context.Capacidads?.Any(e => e.CapacidadId == id)).GetValueOrDefault();
        }
    }
}
