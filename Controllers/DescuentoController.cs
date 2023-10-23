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
    public class DescuentoController : Controller
    {
        private readonly AdminToursContext _context;

        public DescuentoController(AdminToursContext context)
        {
            _context = context;
        }

        // GET: Descuento
        public async Task<IActionResult> Index()
        {
              return _context.Descuentos != null ? 
                          View(await _context.Descuentos.ToListAsync()) :
                          Problem("Entity set 'AdminToursContext.Descuentos'  is null.");
        }

        // GET: Descuento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Descuentos == null)
            {
                return NotFound();
            }

            var descuento = await _context.Descuentos
                .FirstOrDefaultAsync(m => m.DescuentoId == id);
            if (descuento == null)
            {
                return NotFound();
            }

            return View(descuento);
        }

        // GET: Descuento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Descuento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DescuentoId,NombreDescuento,CantidadDescuento,Codigo")] Descuento descuento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(descuento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(descuento);
        }

        // GET: Descuento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Descuentos == null)
            {
                return NotFound();
            }

            var descuento = await _context.Descuentos.FindAsync(id);
            if (descuento == null)
            {
                return NotFound();
            }
            return View(descuento);
        }

        // POST: Descuento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DescuentoId,NombreDescuento,CantidadDescuento,Codigo")] Descuento descuento)
        {
            if (id != descuento.DescuentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(descuento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescuentoExists(descuento.DescuentoId))
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
            return View(descuento);
        }

        // GET: Descuento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Descuentos == null)
            {
                return NotFound();
            }

            var descuento = await _context.Descuentos
                .FirstOrDefaultAsync(m => m.DescuentoId == id);
            if (descuento == null)
            {
                return NotFound();
            }

            return View(descuento);
        }

        // POST: Descuento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Descuentos == null)
            {
                return Problem("Entity set 'AdminToursContext.Descuentos'  is null.");
            }
            var descuento = await _context.Descuentos.FindAsync(id);
            if (descuento != null)
            {
                _context.Descuentos.Remove(descuento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DescuentoExists(int id)
        {
          return (_context.Descuentos?.Any(e => e.DescuentoId == id)).GetValueOrDefault();
        }
    }
}
