using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LesGrupo8Bioterio.Models;

namespace LesGrupo8Bioterio.Controllers
{
    public class FamiliasController : Controller
    {
        private readonly bd_lesContext _context;

        public FamiliasController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Familias
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.Familia.Include(f => f.GrupoIdGrupoNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: Familias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.Familia
                .Include(f => f.GrupoIdGrupoNavigation)
                .SingleOrDefaultAsync(m => m.IdFamilia == id);
            if (familia == null)
            {
                return NotFound();
            }

            return View(familia);
        }

        // GET: Familias/Create
        public IActionResult Create()
        {
            ViewData["GrupoIdGrupo"] = new SelectList(_context.Grupo, "IdGrupo", "IdGrupo");
            return View();
        }

        // POST: Familias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFamilia,GrupoIdGrupo")] Familia familia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GrupoIdGrupo"] = new SelectList(_context.Grupo, "IdGrupo", "IdGrupo", familia.GrupoIdGrupo);
            return View(familia);
        }

        // GET: Familias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.Familia.SingleOrDefaultAsync(m => m.IdFamilia == id);
            if (familia == null)
            {
                return NotFound();
            }
            ViewData["GrupoIdGrupo"] = new SelectList(_context.Grupo, "IdGrupo", "IdGrupo", familia.GrupoIdGrupo);
            return View(familia);
        }

        // POST: Familias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFamilia,GrupoIdGrupo")] Familia familia)
        {
            if (id != familia.IdFamilia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliaExists(familia.IdFamilia))
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
            ViewData["GrupoIdGrupo"] = new SelectList(_context.Grupo, "IdGrupo", "IdGrupo", familia.GrupoIdGrupo);
            return View(familia);
        }

        // GET: Familias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.Familia
                .Include(f => f.GrupoIdGrupoNavigation)
                .SingleOrDefaultAsync(m => m.IdFamilia == id);
            if (familia == null)
            {
                return NotFound();
            }

            return View(familia);
        }

        // POST: Familias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familia = await _context.Familia.SingleOrDefaultAsync(m => m.IdFamilia == id);
            _context.Familia.Remove(familia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamiliaExists(int id)
        {
            return _context.Familia.Any(e => e.IdFamilia == id);
        }
    }
}
