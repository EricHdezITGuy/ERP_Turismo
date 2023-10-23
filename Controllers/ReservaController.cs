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
    public class ReservaController : Controller
    {
        private readonly AdminToursContext _context;

        public ReservaController(AdminToursContext context)
        {
            _context = context;
        }

        // GET: Reserva
        public async Task<IActionResult> Index()
        {
            var adminToursContext = _context.Reservas.Include(r => r.Cliente).Include(r => r.Descuento).Include(r => r.Estado).Include(r => r.Tour);
            return View(await adminToursContext.ToListAsync());
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Descuento)
                .Include(r => r.Estado)
                .Include(r => r.Tour)
                .FirstOrDefaultAsync(m => m.ReservaId == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            ViewData["DescuentoId"] = new SelectList(_context.Descuentos, "DescuentoId", "DescuentoId");
            ViewData["EstadoId"] = new SelectList(_context.EstadosReservas, "EstadoId", "EstadoId");
            ViewData["TourId"] = new SelectList(_context.Tours, "TourId", "TourId");
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservaId,ClienteId,TourId,NumeroPersonas,Pagado,DescuentoId,EstadoId")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", reserva.ClienteId);
            ViewData["DescuentoId"] = new SelectList(_context.Descuentos, "DescuentoId", "DescuentoId", reserva.DescuentoId);
            ViewData["EstadoId"] = new SelectList(_context.EstadosReservas, "EstadoId", "EstadoId", reserva.EstadoId);
            ViewData["TourId"] = new SelectList(_context.Tours, "TourId", "TourId", reserva.TourId);
            return View(reserva);
        }

        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", reserva.ClienteId);
            ViewData["DescuentoId"] = new SelectList(_context.Descuentos, "DescuentoId", "DescuentoId", reserva.DescuentoId);
            ViewData["EstadoId"] = new SelectList(_context.EstadosReservas, "EstadoId", "EstadoId", reserva.EstadoId);
            ViewData["TourId"] = new SelectList(_context.Tours, "TourId", "TourId", reserva.TourId);
            return View(reserva);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservaId,ClienteId,TourId,NumeroPersonas,Pagado,DescuentoId,EstadoId")] Reserva reserva)
        {
            if (id != reserva.ReservaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.ReservaId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", reserva.ClienteId);
            ViewData["DescuentoId"] = new SelectList(_context.Descuentos, "DescuentoId", "DescuentoId", reserva.DescuentoId);
            ViewData["EstadoId"] = new SelectList(_context.EstadosReservas, "EstadoId", "EstadoId", reserva.EstadoId);
            ViewData["TourId"] = new SelectList(_context.Tours, "TourId", "TourId", reserva.TourId);
            return View(reserva);
        }

        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Descuento)
                .Include(r => r.Estado)
                .Include(r => r.Tour)
                .FirstOrDefaultAsync(m => m.ReservaId == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservas == null)
            {
                return Problem("Entity set 'AdminToursContext.Reservas'  is null.");
            }
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
          return (_context.Reservas?.Any(e => e.ReservaId == id)).GetValueOrDefault();
        }
    }
}
