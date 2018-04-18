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
    public class LotesController : Controller
    {
        private readonly bd_lesContext _context;

        public LotesController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Lotes
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.Lote.Include(l => l.FuncionarioIdFuncionarioNavigation).Include(l => l.RegNovosAnimaisIdRegAnimalNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: Lotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lote = await _context.Lote
                .Include(l => l.FuncionarioIdFuncionarioNavigation)
                .Include(l => l.RegNovosAnimaisIdRegAnimalNavigation)
                .SingleOrDefaultAsync(m => m.IdLote == id);
            if (lote == null)
            {
                return NotFound();
            }

            return View(lote);
        }

        // GET: Lotes/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto");
            ViewData["RegNovosAnimaisIdRegAnimal"] = new SelectList(_context.RegNovosAnimais, "IdRegAnimal", "IdRegAnimal");
            return View();
        }

        // POST: Lotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLote,CodigoLote,DataInicio,DataFim,Observacoes,RegNovosAnimaisIdRegAnimal,FuncionarioIdFuncionario")] Lote lote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto", lote.FuncionarioIdFuncionario);
            ViewData["RegNovosAnimaisIdRegAnimal"] = new SelectList(_context.RegNovosAnimais, "IdRegAnimal", "IdRegAnimal", lote.RegNovosAnimaisIdRegAnimal);
            return View(lote);
        }

        // GET: Lotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lote = await _context.Lote.SingleOrDefaultAsync(m => m.IdLote == id);
            if (lote == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto", lote.FuncionarioIdFuncionario);
            ViewData["RegNovosAnimaisIdRegAnimal"] = new SelectList(_context.RegNovosAnimais, "IdRegAnimal", "IdRegAnimal", lote.RegNovosAnimaisIdRegAnimal);
            return View(lote);
        }

        // POST: Lotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLote,CodigoLote,DataInicio,DataFim,Observacoes,RegNovosAnimaisIdRegAnimal,FuncionarioIdFuncionario")] Lote lote)
        {
            if (id != lote.IdLote)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoteExists(lote.IdLote))
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
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto", lote.FuncionarioIdFuncionario);
            ViewData["RegNovosAnimaisIdRegAnimal"] = new SelectList(_context.RegNovosAnimais, "IdRegAnimal", "IdRegAnimal", lote.RegNovosAnimaisIdRegAnimal);
            return View(lote);
        }

        // GET: Lotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lote = await _context.Lote
                .Include(l => l.FuncionarioIdFuncionarioNavigation)
                .Include(l => l.RegNovosAnimaisIdRegAnimalNavigation)
                .SingleOrDefaultAsync(m => m.IdLote == id);
            if (lote == null)
            {
                return NotFound();
            }

            return View(lote);
        }

        // POST: Lotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lote = await _context.Lote.SingleOrDefaultAsync(m => m.IdLote == id);
            _context.Lote.Remove(lote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoteExists(int id)
        {
            return _context.Lote.Any(e => e.IdLote == id);
        }
    }
}
