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

        private Projeto SetRelations(Projeto projeto, int? id)
        {

            var ensaios = _context.Ensaio.Where(b => EF.Property<int>(b, "ProjetoIdProjeto") == id);
            var elementoequipa = _context.Elementoequipa.Where(b => EF.Property<int>(b, "ProjetoIdProjeto") == id);
            var circuitotanque = _context.CircuitoTanque.Where(b => EF.Property<int>(b, "ProjetoIdProjeto") == id);

            projeto.objetoEN = ensaios;
            projeto.CircuitoQuery = circuitotanque;
            projeto.objetoEE = elementoequipa;

            if (projeto.objetoEN.Any() || projeto.objetoEE.Any() || circuitotanque.Any())
            {
                projeto.deletable = false;
            }
            else
            {
                projeto.deletable = true;
            }
            return projeto;
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
            
            var circuito =  _context.CircuitoTanque
                .Include(e => e.ProjetoIdProjetoNavigation).Where(m => m.ProjetoIdProjeto == id);

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
                projeto.CircuitoQuery = circuito;
            }
            if (projeto == null)
            {
                return NotFound();
            }

            projeto.data = projeto.DataInicio.Day + "/" + projeto.DataInicio.Month + "/" + projeto.DataInicio.Year;
            projeto.data2 = projeto.DataFim.Day + "/" + projeto.DataFim.Month + "/" + projeto.DataFim.Year;
            if (projeto.SubmisInsEurop.Equals(true))
            {
                projeto.auto_Euro = "Sim";

            }
            else
            {
                projeto.auto_Euro = "Não";
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

            if (projeto == null || projeto.isarchived == 1)
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
            if (id != projeto.IdProjeto || projeto.isarchived == 1)
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

            projeto = SetRelations(projeto, projeto.IdProjeto);
            projeto.data = projeto.DataInicio.Day + "/" + projeto.DataInicio.Month + "/" + projeto.DataInicio.Year;
            projeto.data2 = projeto.DataFim.Day + "/" + projeto.DataFim.Month + "/" + projeto.DataFim.Year;
            if (projeto.SubmisInsEurop.Equals(true))
            {
                projeto.auto_Euro = "Sim";

            }
            else
            {
                projeto.auto_Euro = "Não";
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

            
            foreach (var ensaio in ensaios)
            {
                ensaio.isarchived = 1;
                _context.Ensaio.Update(ensaio);
            }
            foreach(var elementos in elementoequipa)
            {
                elementos.isarchived = 1;
                _context.Elementoequipa.Update(elementos);
            }
            foreach (var circuito in circuitotanque)
            {
                var tanques = _context.Tanque.Where(b => EF.Property<int>(b, "CircuitoTanqueIdCircuito") == circuito.IdCircuito);
                var regCondAmb = _context.RegCondAmb.Where(b => EF.Property<int>(b, "CircuitoTanqueIdCircuito") == id);

                foreach (var tanque in tanques) { 
                var regRemocoes = _context.RegRemocoes.Where(b => EF.Property<int>(b, "TanqueIdTanque") == tanque.IdTanque);
                var regAmostragens = _context.RegAmostragens.Where(b => EF.Property<int>(b, "TanqueIdTanque") == tanque.IdTanque);
                var regManu = _context.RegManutencao.Where(b => EF.Property<int>(b, "TanqueIdTanque") == tanque.IdTanque);
                var regTrat = _context.RegTratamento.Where(b => EF.Property<int>(b, "TanqueIdTanque") == tanque.IdTanque);
                var regAli = _context.RegAlimentar.Where(b => EF.Property<int>(b, "TanqueIdTanque") == tanque.IdTanque);

                    foreach (var regRemocao in regRemocoes)
                    {
                        regRemocao.isarchived = 1;
                        _context.RegRemocoes.Update(regRemocao);
                    }
                    foreach (var regAmostragem in regAmostragens)
                    {
                        regAmostragem.isarchived = 1;
                        _context.RegAmostragens.Update(regAmostragem);
                    }
                    foreach (var regManutencao in regManu)
                    {
                        regManutencao.isarchived = 1;
                        _context.RegManutencao.Update(regManutencao);
                    }
                    foreach (var regTratamento in regTrat)
                    {
                        regTratamento.isarchived = 1;
                        _context.RegTratamento.Update(regTratamento);
                    }
                    foreach (var regAlimentacao in regAli)
                    {
                        regAlimentacao.isarchived = 1;
                        _context.RegAlimentar.Update(regAlimentacao);
                    }
                    tanque.isarchived = 1;
                    _context.Tanque.Update(tanque);
                }

                foreach (var condAmb in regCondAmb)
                {
                    condAmb.isarchived = 1;
                    _context.RegCondAmb.Update(condAmb);
                }
            

                circuito.isarchived = 1;
                _context.CircuitoTanque.Update(circuito);
            }

            projeto.isarchived = 1;
            _context.Projeto.Update(projeto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetoExists(int id)
        {
            return _context.Projeto.Any(e => e.IdProjeto == id);
        }
    }
}
