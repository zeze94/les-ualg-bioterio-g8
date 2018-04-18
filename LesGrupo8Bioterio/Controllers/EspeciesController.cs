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
    public class EspeciesController : Controller
    {
        private readonly bd_lesContext _context;

        public EspeciesController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Especies
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.Especie.Include(e => e.Familia);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: Especies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.Especie
                .Include(e => e.Familia)
                .SingleOrDefaultAsync(m => m.IdEspecie == id);
            if (especie == null)
            {
                return NotFound();
            }

            return View(especie);
        }

        // GET: Especies/Create
        public IActionResult Create()
        {
            ViewData["FamiliaIdFamilia"] = new SelectList(_context.Familia, "IdFamilia", "IdFamilia");
            return View();
        }

        // POST: Especies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEspecie,NomeCient,NomeVulgar,FamiliaIdFamilia,FamiliaGrupoIdGrupo")] Especie especie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FamiliaIdFamilia"] = new SelectList(_context.Familia, "IdFamilia", "IdFamilia", especie.FamiliaIdFamilia);
            return View(especie);
        }

        // GET: Especies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.Especie.SingleOrDefaultAsync(m => m.IdEspecie == id);
            if (especie == null)
            {
                return NotFound();
            }
            ViewData["FamiliaIdFamilia"] = new SelectList(_context.Familia, "IdFamilia", "IdFamilia", especie.FamiliaIdFamilia);
            return View(especie);
        }

        // POST: Especies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEspecie,NomeCient,NomeVulgar,FamiliaIdFamilia,FamiliaGrupoIdGrupo")] Especie especie)
        {
            if (id != especie.IdEspecie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecieExists(especie.IdEspecie))
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
            ViewData["FamiliaIdFamilia"] = new SelectList(_context.Familia, "IdFamilia", "IdFamilia", especie.FamiliaIdFamilia);
            return View(especie);
        }

        // GET: Especies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.Especie
                .Include(e => e.Familia)
                .SingleOrDefaultAsync(m => m.IdEspecie == id);
            if (especie == null)
            {
                return NotFound();
            }

            return View(especie);
        }

        // POST: Especies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especie = await _context.Especie.SingleOrDefaultAsync(m => m.IdEspecie == id);
            _context.Especie.Remove(especie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecieExists(int id)
        {
            return _context.Especie.Any(e => e.IdEspecie == id);
        }
    }
}
