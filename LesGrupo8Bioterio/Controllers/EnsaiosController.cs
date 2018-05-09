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
    public class EnsaiosController : Controller
    {
        private readonly bd_lesContext _context;

        public EnsaiosController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Ensaios
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.Ensaio.Include(e => e.LoteIdLoteNavigation).Include(e => e.ProjetoIdProjetoNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: Ensaios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ensaio = await _context.Ensaio
                .Include(e => e.LoteIdLoteNavigation)
                .Include(e => e.ProjetoIdProjetoNavigation)
                .SingleOrDefaultAsync(m => m.IdEnsaio == id);
            if (ensaio == null)
            {
                return NotFound();
            }

            return View(ensaio);
        }

        // GET: Ensaios/Create
        public IActionResult Create()
        {
            ViewData["LoteIdLote"] = new SelectList(_context.Lote, "IdLote", "CodigoLote");
            ViewData["ProjetoIdProjeto"] = new SelectList(_context.Projeto, "IdProjeto", "Nome");
            return View();
        }

        // POST: Ensaios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEnsaio,DataInicio,DataFim,DescTratamento,GrauSeveridade,ProjetoIdProjeto,LoteIdLote,MembroEquipaIdEquipa")] Ensaio ensaio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ensaio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoteIdLote"] = new SelectList(_context.Lote, "IdLote", "CodigoLote", ensaio.LoteIdLote);
            ViewData["ProjetoIdProjeto"] = new SelectList(_context.Projeto, "IdProjeto", "Nome", ensaio.ProjetoIdProjeto);
            return View(ensaio);
        }

        // GET: Ensaios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ensaio = await _context.Ensaio.SingleOrDefaultAsync(m => m.IdEnsaio == id);
            if (ensaio == null)
            {
                return NotFound();
            }
            ViewData["LoteIdLote"] = new SelectList(_context.Lote, "IdLote", "CodigoLote", ensaio.LoteIdLote);
            ViewData["ProjetoIdProjeto"] = new SelectList(_context.Projeto, "IdProjeto", "Nome", ensaio.ProjetoIdProjeto);
            return View(ensaio);
        }

        // POST: Ensaios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEnsaio,DataInicio,DataFim,DescTratamento,GrauSeveridade,ProjetoIdProjeto,LoteIdLote,MembroEquipaIdEquipa")] Ensaio ensaio)
        {
            if (id != ensaio.IdEnsaio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ensaio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnsaioExists(ensaio.IdEnsaio))
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
            ViewData["LoteIdLote"] = new SelectList(_context.Lote, "IdLote", "CodigoLote", ensaio.LoteIdLote);
            ViewData["ProjetoIdProjeto"] = new SelectList(_context.Projeto, "IdProjeto", "Nome", ensaio.ProjetoIdProjeto);
            return View(ensaio);
        }

        // GET: Ensaios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ensaio = await _context.Ensaio
                .Include(e => e.LoteIdLoteNavigation)
                .Include(e => e.ProjetoIdProjetoNavigation)
                .SingleOrDefaultAsync(m => m.IdEnsaio == id);
            if (ensaio == null)
            {
                return NotFound();
            }

            return View(ensaio);
        }

        // POST: Ensaios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ensaio = await _context.Ensaio.SingleOrDefaultAsync(m => m.IdEnsaio == id);
            _context.Ensaio.Remove(ensaio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnsaioExists(int id)
        {
            return _context.Ensaio.Any(e => e.IdEnsaio == id);
        }
    }
}
