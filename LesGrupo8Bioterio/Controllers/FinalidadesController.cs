using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LesGrupo8Bioterio;
using LesGrupo8Bioterio.Models;

namespace LesGrupo8Bioterio.Controllers
{
    public class FinalidadesController : Controller
    {
        private readonly bd_lesContext _context;

        public FinalidadesController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Finalidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Finalidade.ToListAsync());
        }

        // GET: Finalidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalidade = await _context.Finalidade
                .SingleOrDefaultAsync(m => m.IdFinalidade == id);
            if (finalidade == null)
            {
                return NotFound();
            }

            return View(finalidade);
        }

        // GET: Finalidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Finalidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFinalidade,TFinalidade")] Finalidade finalidade)
        {
            var cTCodefindany = _context.Finalidade.Where(b => EF.Property<string>(b, "TFinalidade").Equals(finalidade.TFinalidade));
            if (cTCodefindany.Any())
            {
                ModelState.AddModelError("TFinalidade", string.Format("Esta Finalidade já existe.", finalidade.TFinalidade));
            }
            if (ModelState.IsValid)
            {
                _context.Add(finalidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(finalidade);
        }

        // GET: Finalidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalidade = await _context.Finalidade.SingleOrDefaultAsync(m => m.IdFinalidade == id);
            if (finalidade == null)
            {
                return NotFound();
            }
            return View(finalidade);
        }

        // POST: Finalidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFinalidade,TFinalidade")] Finalidade finalidade)
        {
            if (id != finalidade.IdFinalidade)
            {
                return NotFound();
            }
            var cTCodefindany = _context.Finalidade.Where(b => EF.Property<string>(b, "TFinalidade").Equals(finalidade.TFinalidade));
            if (cTCodefindany.Any())
            {
                ModelState.AddModelError("TFinalidade", string.Format("Esta Finalidade já existe.", finalidade.TFinalidade));
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finalidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinalidadeExists(finalidade.IdFinalidade))
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
            return View(finalidade);
        }

        // GET: Finalidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalidade = await _context.Finalidade
                .SingleOrDefaultAsync(m => m.IdFinalidade == id);
            if (finalidade == null)
            {
                return NotFound();
            }

            return View(finalidade);
        }

        // POST: Finalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var finalidade = await _context.Finalidade.SingleOrDefaultAsync(m => m.IdFinalidade == id);
            _context.Finalidade.Remove(finalidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinalidadeExists(int id)
        {
            return _context.Finalidade.Any(e => e.IdFinalidade == id);
        }
    }
}
