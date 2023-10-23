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
    public class RolesUsuarioController : Controller
    {
        private readonly AdminToursContext _context;

        public RolesUsuarioController(AdminToursContext context)
        {
            _context = context;
        }

        // GET: RolesUsuario
        public async Task<IActionResult> Index()
        {
              return _context.RolesUsuarios != null ? 
                          View(await _context.RolesUsuarios.ToListAsync()) :
                          Problem("Entity set 'AdminToursContext.RolesUsuarios'  is null.");
        }

        // GET: RolesUsuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RolesUsuarios == null)
            {
                return NotFound();
            }

            var rolesUsuario = await _context.RolesUsuarios
                .FirstOrDefaultAsync(m => m.RolId == id);
            if (rolesUsuario == null)
            {
                return NotFound();
            }

            return View(rolesUsuario);
        }

        // GET: RolesUsuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RolesUsuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RolId,NombreRol")] RolesUsuario rolesUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rolesUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rolesUsuario);
        }

        // GET: RolesUsuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RolesUsuarios == null)
            {
                return NotFound();
            }

            var rolesUsuario = await _context.RolesUsuarios.FindAsync(id);
            if (rolesUsuario == null)
            {
                return NotFound();
            }
            return View(rolesUsuario);
        }

        // POST: RolesUsuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RolId,NombreRol")] RolesUsuario rolesUsuario)
        {
            if (id != rolesUsuario.RolId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolesUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolesUsuarioExists(rolesUsuario.RolId))
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
            return View(rolesUsuario);
        }

        // GET: RolesUsuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RolesUsuarios == null)
            {
                return NotFound();
            }

            var rolesUsuario = await _context.RolesUsuarios
                .FirstOrDefaultAsync(m => m.RolId == id);
            if (rolesUsuario == null)
            {
                return NotFound();
            }

            return View(rolesUsuario);
        }

        // POST: RolesUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RolesUsuarios == null)
            {
                return Problem("Entity set 'AdminToursContext.RolesUsuarios'  is null.");
            }
            var rolesUsuario = await _context.RolesUsuarios.FindAsync(id);
            if (rolesUsuario != null)
            {
                _context.RolesUsuarios.Remove(rolesUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolesUsuarioExists(int id)
        {
          return (_context.RolesUsuarios?.Any(e => e.RolId == id)).GetValueOrDefault();
        }
    }
}
