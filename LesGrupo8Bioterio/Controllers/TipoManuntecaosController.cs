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
    public class TipoManuntecaosController : Controller
    {
        private readonly bd_lesContext _context;

        public TipoManuntecaosController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: TipoManuntecaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoManuntecao.ToListAsync());
        }

        // GET: TipoManuntecaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoManuntecao = await _context.TipoManuntecao
                .SingleOrDefaultAsync(m => m.IdTManutencao == id);
            if (tipoManuntecao == null)
            {
                return NotFound();
            }

            return View(tipoManuntecao);
        }

        // GET: TipoManuntecaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoManuntecaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTManutencao,TManutencao")] TipoManuntecao tipoManuntecao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoManuntecao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoManuntecao);
        }

        // GET: TipoManuntecaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoManuntecao = await _context.TipoManuntecao.SingleOrDefaultAsync(m => m.IdTManutencao == id);
            if (tipoManuntecao == null)
            {
                return NotFound();
            }
            return View(tipoManuntecao);
        }

        // POST: TipoManuntecaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTManutencao,TManutencao")] TipoManuntecao tipoManuntecao)
        {
            if (id != tipoManuntecao.IdTManutencao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoManuntecao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoManuntecaoExists(tipoManuntecao.IdTManutencao))
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
            return View(tipoManuntecao);
        }

        // GET: TipoManuntecaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoManuntecao = await _context.TipoManuntecao
                .SingleOrDefaultAsync(m => m.IdTManutencao == id);
            if (tipoManuntecao == null)
            {
                return NotFound();
            }

            return View(tipoManuntecao);
        }

        // POST: TipoManuntecaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoManuntecao = await _context.TipoManuntecao.SingleOrDefaultAsync(m => m.IdTManutencao == id);
            _context.TipoManuntecao.Remove(tipoManuntecao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoManuntecaoExists(int id)
        {
            return _context.TipoManuntecao.Any(e => e.IdTManutencao == id);
        }
    }
}
