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
    public class RegManutencaosController : Controller
    {
        private readonly bd_lesContext _context;

        public RegManutencaosController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: RegManutencaos
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.RegManutencao.Include(r => r.TanqueIdTanqueNavigation).Include(r => r.TipoManuntecaoIdTManutencaoNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: RegManutencaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regManutencao = await _context.RegManutencao
                .Include(r => r.TanqueIdTanqueNavigation)
                .Include(r => r.TipoManuntecaoIdTManutencaoNavigation)
                .SingleOrDefaultAsync(m => m.IdRegMan == id);
            if (regManutencao == null)
            {
                return NotFound();
            }

            return View(regManutencao);
        }

        // GET: RegManutencaos/Create
        public IActionResult Create()
        {
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque, "IdTanque", "Sala");
            ViewData["TipoManuntecaoIdTManutencao"] = new SelectList(_context.TipoManuntecao, "IdTManutencao", "IdTManutencao");
            return View();
        }

        // POST: RegManutencaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegMan,Data,TipoManuntecaoIdTManutencao,TanqueIdTanque")] RegManutencao regManutencao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regManutencao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque, "IdTanque", "Sala", regManutencao.TanqueIdTanque);
            ViewData["TipoManuntecaoIdTManutencao"] = new SelectList(_context.TipoManuntecao, "IdTManutencao", "IdTManutencao", regManutencao.TipoManuntecaoIdTManutencao);
            return View(regManutencao);
        }

        // GET: RegManutencaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regManutencao = await _context.RegManutencao.SingleOrDefaultAsync(m => m.IdRegMan == id);
            if (regManutencao == null)
            {
                return NotFound();
            }
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque, "IdTanque", "Sala", regManutencao.TanqueIdTanque);
            ViewData["TipoManuntecaoIdTManutencao"] = new SelectList(_context.TipoManuntecao, "IdTManutencao", "IdTManutencao", regManutencao.TipoManuntecaoIdTManutencao);
            return View(regManutencao);
        }

        // POST: RegManutencaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegMan,Data,TipoManuntecaoIdTManutencao,TanqueIdTanque")] RegManutencao regManutencao)
        {
            if (id != regManutencao.IdRegMan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regManutencao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegManutencaoExists(regManutencao.IdRegMan))
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
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque, "IdTanque", "Sala", regManutencao.TanqueIdTanque);
            ViewData["TipoManuntecaoIdTManutencao"] = new SelectList(_context.TipoManuntecao, "IdTManutencao", "IdTManutencao", regManutencao.TipoManuntecaoIdTManutencao);
            return View(regManutencao);
        }

        // GET: RegManutencaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regManutencao = await _context.RegManutencao
                .Include(r => r.TanqueIdTanqueNavigation)
                .Include(r => r.TipoManuntecaoIdTManutencaoNavigation)
                .SingleOrDefaultAsync(m => m.IdRegMan == id);
            if (regManutencao == null)
            {
                return NotFound();
            }

            return View(regManutencao);
        }

        // POST: RegManutencaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regManutencao = await _context.RegManutencao.SingleOrDefaultAsync(m => m.IdRegMan == id);
            _context.RegManutencao.Remove(regManutencao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegManutencaoExists(int id)
        {
            return _context.RegManutencao.Any(e => e.IdRegMan == id);
        }
    }
}
