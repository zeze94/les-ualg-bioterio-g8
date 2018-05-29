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
    public class ProjetoesController : Controller
    {
        private readonly bd_lesContext _context;

        public ProjetoesController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Projetoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projeto.ToListAsync());
        }

        // GET: Projetoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto
                .SingleOrDefaultAsync(m => m.IdProjeto == id);
            
            var circuito = await _context.CircuitoTanque
                .SingleOrDefaultAsync(m => m.ProjetoIdProjeto == id);

            var ensaio = _context.Ensaio.Include(e => e.LoteIdLoteNavigation).Where(m => m.ProjetoIdProjeto == id);

            var elementoequipa = _context.Elementoequipa.Where(m => m.ProjetoIdProjeto == id);
            if(elementoequipa != null)
            {
                projeto.objetoEE = elementoequipa;
            }
            if (ensaio != null)
            {
                projeto.objetoEN = ensaio;
            }
            if (circuito != null)
            {
                projeto.objetoCT = circuito;
            }
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // GET: Projetoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projetoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProjeto,Nome,DataInicio,DataFim,AutorizacaoDgva,RefOrbea,SubmisInsEurop,NroAnimaisAutoriz")] Projeto projeto)
        {
            if(projeto.DataFim < projeto.DataInicio)
            {
                ModelState.AddModelError("DataFim", "A Data de Fim é menor que a Data de Inicio");
                ModelState.AddModelError("DataInicio", "A Data de Fim é menor que a Data de Inicio");
            }
            if (ModelState.IsValid)
            {
                
                _context.Add(projeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(projeto);
        }

        // GET: Projetoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto.SingleOrDefaultAsync(m => m.IdProjeto == id);
            if (projeto == null)
            {
                return NotFound();
            }
            return View(projeto);
        }

        // POST: Projetoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProjeto,Nome,DataInicio,DataFim,AutorizacaoDgva,RefOrbea,SubmisInsEurop,NroAnimaisAutoriz")] Projeto projeto)
        {
            if (id != projeto.IdProjeto)
            {
                return NotFound();
            }
            if (projeto.DataFim < projeto.DataInicio)
            {
                ModelState.AddModelError("DataFim", "A Data de Fim é menor que a Data de Inicio");
                ModelState.AddModelError("DataInicio", "A Data de Fim é menor que a Data de Inicio");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetoExists(projeto.IdProjeto))
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
            return View(projeto);
        }

        // GET: Projetoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto
                .SingleOrDefaultAsync(m => m.IdProjeto == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // POST: Projetoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projeto = await _context.Projeto.SingleOrDefaultAsync(m => m.IdProjeto == id);
            var ensaios = _context.Ensaio.Where(b => EF.Property<int>(b, "ProjetoIdProjeto") == id);
            var elementoequipa = _context.Elementoequipa.Where(b => EF.Property<int>(b, "ProjetoIdProjeto") == id);
            var circuitotanque = _context.CircuitoTanque.Where(b => EF.Property<int>(b, "ProjetoIdProjeto") == id);
           

            foreach(var ensaio in ensaios)
            {
                _context.Ensaio.Remove(ensaio);
            }
            foreach(var elementos in elementoequipa)
            {
                _context.Elementoequipa.Remove(elementos);
            }
            foreach(var circuito in circuitotanque)
            {
                _context.CircuitoTanque.Remove(circuito);

            }
            _context.Projeto.Remove(projeto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetoExists(int id)
        {
            return _context.Projeto.Any(e => e.IdProjeto == id);
        }
    }
}
