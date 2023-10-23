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
    public class EstadosReservaController : Controller
    {
        private readonly AdminToursContext _context;

        public EstadosReservaController(AdminToursContext context)
        {
            _context = context;
        }

        // GET: EstadosReserva
        public async Task<IActionResult> Index()
        {
              return _context.EstadosReservas != null ? 
                          View(await _context.EstadosReservas.ToListAsync()) :
                          Problem("Entity set 'AdminToursContext.EstadosReservas'  is null.");
        }

        // GET: EstadosReserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstadosReservas == null)
            {
                return NotFound();
            }

            var estadosReserva = await _context.EstadosReservas
                .FirstOrDefaultAsync(m => m.EstadoId == id);
            if (estadosReserva == null)
            {
                return NotFound();
            }

            return View(estadosReserva);
        }

        // GET: EstadosReserva/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadosReserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstadoId,NombreEstado")] EstadosReserva estadosReserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadosReserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadosReserva);
        }

        // GET: EstadosReserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EstadosReservas == null)
            {
                return NotFound();
            }

            var estadosReserva = await _context.EstadosReservas.FindAsync(id);
            if (estadosReserva == null)
            {
                return NotFound();
            }
            return View(estadosReserva);
        }

        // POST: EstadosReserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstadoId,NombreEstado")] EstadosReserva estadosReserva)
        {
            if (id != estadosReserva.EstadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadosReserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadosReservaExists(estadosReserva.EstadoId))
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
            return View(estadosReserva);
        }

        // GET: EstadosReserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstadosReservas == null)
            {
                return NotFound();
            }

            var estadosReserva = await _context.EstadosReservas
                .FirstOrDefaultAsync(m => m.EstadoId == id);
            if (estadosReserva == null)
            {
                return NotFound();
            }

            return View(estadosReserva);
        }

        // POST: EstadosReserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstadosReservas == null)
            {
                return Problem("Entity set 'AdminToursContext.EstadosReservas'  is null.");
            }
            var estadosReserva = await _context.EstadosReservas.FindAsync(id);
            if (estadosReserva != null)
            {
                _context.EstadosReservas.Remove(estadosReserva);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadosReservaExists(int id)
        {
          return (_context.EstadosReservas?.Any(e => e.EstadoId == id)).GetValueOrDefault();
        }
    }
}
