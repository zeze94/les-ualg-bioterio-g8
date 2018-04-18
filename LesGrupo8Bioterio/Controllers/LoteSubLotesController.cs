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
    public class LoteSubLotesController : Controller
    {
        private readonly bd_lesContext _context;

        public LoteSubLotesController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: LoteSubLotes
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.LoteSubLote.Include(l => l.LoteIdLoteAtualNavigation).Include(l => l.LoteIdLotePrevNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: LoteSubLotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loteSubLote = await _context.LoteSubLote
                .Include(l => l.LoteIdLoteAtualNavigation)
                .Include(l => l.LoteIdLotePrevNavigation)
                .SingleOrDefaultAsync(m => m.LoteIdLotePrev == id);
            if (loteSubLote == null)
            {
                return NotFound();
            }

            return View(loteSubLote);
        }

        // GET: LoteSubLotes/Create
        public IActionResult Create()
        {
            ViewData["LoteIdLoteAtual"] = new SelectList(_context.Lote, "IdLote", "CodigoLote");
            ViewData["LoteIdLotePrev"] = new SelectList(_context.Lote, "IdLote", "CodigoLote");
            return View();
        }

        // POST: LoteSubLotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoteIdLotePrev,LoteIdLoteAtual,CodigoSubLote")] LoteSubLote loteSubLote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loteSubLote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoteIdLoteAtual"] = new SelectList(_context.Lote, "IdLote", "CodigoLote", loteSubLote.LoteIdLoteAtual);
            ViewData["LoteIdLotePrev"] = new SelectList(_context.Lote, "IdLote", "CodigoLote", loteSubLote.LoteIdLotePrev);
            return View(loteSubLote);
        }

        // GET: LoteSubLotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loteSubLote = await _context.LoteSubLote.SingleOrDefaultAsync(m => m.LoteIdLotePrev == id);
            if (loteSubLote == null)
            {
                return NotFound();
            }
            ViewData["LoteIdLoteAtual"] = new SelectList(_context.Lote, "IdLote", "CodigoLote", loteSubLote.LoteIdLoteAtual);
            ViewData["LoteIdLotePrev"] = new SelectList(_context.Lote, "IdLote", "CodigoLote", loteSubLote.LoteIdLotePrev);
            return View(loteSubLote);
        }

        // POST: LoteSubLotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoteIdLotePrev,LoteIdLoteAtual,CodigoSubLote")] LoteSubLote loteSubLote)
        {
            if (id != loteSubLote.LoteIdLotePrev)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loteSubLote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoteSubLoteExists(loteSubLote.LoteIdLotePrev))
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
            ViewData["LoteIdLoteAtual"] = new SelectList(_context.Lote, "IdLote", "CodigoLote", loteSubLote.LoteIdLoteAtual);
            ViewData["LoteIdLotePrev"] = new SelectList(_context.Lote, "IdLote", "CodigoLote", loteSubLote.LoteIdLotePrev);
            return View(loteSubLote);
        }

        // GET: LoteSubLotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loteSubLote = await _context.LoteSubLote
                .Include(l => l.LoteIdLoteAtualNavigation)
                .Include(l => l.LoteIdLotePrevNavigation)
                .SingleOrDefaultAsync(m => m.LoteIdLotePrev == id);
            if (loteSubLote == null)
            {
                return NotFound();
            }

            return View(loteSubLote);
        }

        // POST: LoteSubLotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loteSubLote = await _context.LoteSubLote.SingleOrDefaultAsync(m => m.LoteIdLotePrev == id);
            _context.LoteSubLote.Remove(loteSubLote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoteSubLoteExists(int id)
        {
            return _context.LoteSubLote.Any(e => e.LoteIdLotePrev == id);
        }
    }
}
