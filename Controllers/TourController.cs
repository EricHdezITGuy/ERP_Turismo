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
    public class TourController : Controller
    {
        private readonly AdminToursContext _context;

        public TourController(AdminToursContext context)
        {
            _context = context;
        }

        // GET: Tour
        public async Task<IActionResult> Index()
        {
            var adminToursContext = _context.Tours.Include(t => t.Capacidad).Include(t => t.Guia);
            return View(await adminToursContext.ToListAsync());
        }

        // GET: Tour/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tours == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours
                .Include(t => t.Capacidad)
                .Include(t => t.Guia)
                .FirstOrDefaultAsync(m => m.TourId == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        // GET: Tour/Create
        public IActionResult Create()
        {
            ViewData["CapacidadId"] = new SelectList(_context.Capacidads, "CapacidadId", "CapacidadId");
            ViewData["GuiaId"] = new SelectList(_context.Guias, "GuiaId", "GuiaId");
            return View();
        }

        // POST: Tour/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourId,NombreTour,Fecha,Costo,CapacidadMaxima,GuiaId,CapacidadId")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CapacidadId"] = new SelectList(_context.Capacidads, "CapacidadId", "CapacidadId", tour.CapacidadId);
            ViewData["GuiaId"] = new SelectList(_context.Guias, "GuiaId", "GuiaId", tour.GuiaId);
            return View(tour);
        }

        // GET: Tour/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tours == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }
            ViewData["CapacidadId"] = new SelectList(_context.Capacidads, "CapacidadId", "CapacidadId", tour.CapacidadId);
            ViewData["GuiaId"] = new SelectList(_context.Guias, "GuiaId", "GuiaId", tour.GuiaId);
            return View(tour);
        }

        // POST: Tour/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TourId,NombreTour,Fecha,Costo,CapacidadMaxima,GuiaId,CapacidadId")] Tour tour)
        {
            if (id != tour.TourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourExists(tour.TourId))
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
            ViewData["CapacidadId"] = new SelectList(_context.Capacidads, "CapacidadId", "CapacidadId", tour.CapacidadId);
            ViewData["GuiaId"] = new SelectList(_context.Guias, "GuiaId", "GuiaId", tour.GuiaId);
            return View(tour);
        }

        // GET: Tour/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tours == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours
                .Include(t => t.Capacidad)
                .Include(t => t.Guia)
                .FirstOrDefaultAsync(m => m.TourId == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        // POST: Tour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tours == null)
            {
                return Problem("Entity set 'AdminToursContext.Tours'  is null.");
            }
            var tour = await _context.Tours.FindAsync(id);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TourExists(int id)
        {
          return (_context.Tours?.Any(e => e.TourId == id)).GetValueOrDefault();
        }
    }
}
