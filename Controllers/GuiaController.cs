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
    public class GuiaController : Controller
    {
        private readonly AdminToursContext _context;

        public GuiaController(AdminToursContext context)
        {
            _context = context;
        }

        // GET: Guia
        public async Task<IActionResult> Index()
        {
              return _context.Guias != null ? 
                          View(await _context.Guias.ToListAsync()) :
                          Problem("Entity set 'AdminToursContext.Guias'  is null.");
        }

        // GET: Guia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Guias == null)
            {
                return NotFound();
            }

            var guia = await _context.Guias
                .FirstOrDefaultAsync(m => m.GuiaId == id);
            if (guia == null)
            {
                return NotFound();
            }

            return View(guia);
        }

        // GET: Guia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuiaId,Nombre")] Guia guia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guia);
        }

        // GET: Guia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Guias == null)
            {
                return NotFound();
            }

            var guia = await _context.Guias.FindAsync(id);
            if (guia == null)
            {
                return NotFound();
            }
            return View(guia);
        }

        // POST: Guia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuiaId,Nombre")] Guia guia)
        {
            if (id != guia.GuiaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuiaExists(guia.GuiaId))
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
            return View(guia);
        }

        // GET: Guia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Guias == null)
            {
                return NotFound();
            }

            var guia = await _context.Guias
                .FirstOrDefaultAsync(m => m.GuiaId == id);
            if (guia == null)
            {
                return NotFound();
            }

            return View(guia);
        }

        // POST: Guia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Guias == null)
            {
                return Problem("Entity set 'AdminToursContext.Guias'  is null.");
            }
            var guia = await _context.Guias.FindAsync(id);
            if (guia != null)
            {
                _context.Guias.Remove(guia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuiaExists(int id)
        {
          return (_context.Guias?.Any(e => e.GuiaId == id)).GetValueOrDefault();
        }
    }
}
