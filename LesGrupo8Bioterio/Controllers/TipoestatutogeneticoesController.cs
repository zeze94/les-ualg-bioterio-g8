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
    public class TipoestatutogeneticoesController : Controller
    {
        private readonly bd_lesContext _context;

        public TipoestatutogeneticoesController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Tipoestatutogeneticoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipoestatutogenetico.ToListAsync());
        }

        // GET: Tipoestatutogeneticoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoestatutogenetico = await _context.Tipoestatutogenetico
                .SingleOrDefaultAsync(m => m.IdTipoEstatutoGenetico == id);
            if (tipoestatutogenetico == null)
            {
                return NotFound();
            }

            return View(tipoestatutogenetico);
        }

        // GET: Tipoestatutogeneticoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipoestatutogeneticoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoEstatutoGenetico,TipoEstatutoGeneticocol")] Tipoestatutogenetico tipoestatutogenetico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoestatutogenetico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoestatutogenetico);
        }

        // GET: Tipoestatutogeneticoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoestatutogenetico = await _context.Tipoestatutogenetico.SingleOrDefaultAsync(m => m.IdTipoEstatutoGenetico == id);
            if (tipoestatutogenetico == null)
            {
                return NotFound();
            }
            return View(tipoestatutogenetico);
        }

        // POST: Tipoestatutogeneticoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoEstatutoGenetico,TipoEstatutoGeneticocol")] Tipoestatutogenetico tipoestatutogenetico)
        {
            if (id != tipoestatutogenetico.IdTipoEstatutoGenetico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoestatutogenetico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoestatutogeneticoExists(tipoestatutogenetico.IdTipoEstatutoGenetico))
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
            return View(tipoestatutogenetico);
        }

        // GET: Tipoestatutogeneticoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoestatutogenetico = await _context.Tipoestatutogenetico
                .SingleOrDefaultAsync(m => m.IdTipoEstatutoGenetico == id);
            if (tipoestatutogenetico == null)
            {
                return NotFound();
            }

            return View(tipoestatutogenetico);
        }

        // POST: Tipoestatutogeneticoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoestatutogenetico = await _context.Tipoestatutogenetico.SingleOrDefaultAsync(m => m.IdTipoEstatutoGenetico == id);
            _context.Tipoestatutogenetico.Remove(tipoestatutogenetico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoestatutogeneticoExists(int id)
        {
            return _context.Tipoestatutogenetico.Any(e => e.IdTipoEstatutoGenetico == id);
        }
    }
}
