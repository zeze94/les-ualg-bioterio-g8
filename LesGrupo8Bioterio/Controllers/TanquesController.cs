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
    public class TanquesController : Controller
    {
        private readonly bd_lesContext _context;

        public TanquesController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Tanques
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.Tanque.Include(t => t.CircuitoTanqueIdCircuitoNavigation).Include(t => t.LoteIdLoteNavigation);
            return View(await bd_lesContext.ToListAsync());
        }
        private Tanque setRelations(Tanque tanque, int? id)
        {
            
            var findTratamentos = _context.RegTratamento.Include(r => r.AgenteTratIdAgenTraNavigation).Include(r => r.FinalidadeIdFinalidadeNavigation).Include(r => r.TanqueIdTanqueNavigation).Where(b => EF.Property<int>(b, "TanqueIdTanque") == id);
            var regRemocoes = _context.RegRemocoes.Include(r => r.MotivoIdMotivoNavigation).Where(b => EF.Property<int>(b, "TanqueIdTanque") == id);
            var regAmostragens = _context.RegAmostragens.Where(b => EF.Property<int>(b, "TanqueIdTanque") == id);
            var regManu = _context.RegManutencao.Include(r => r.TipoManuntecaoIdTManutencaoNavigation).Where(b => EF.Property<int>(b, "TanqueIdTanque") == id);
            var regAli = _context.RegAlimentar.Include(r => r.PlanoAlimentarIdPlanAlimNavigation).Where(b => EF.Property<int>(b, "TanqueIdTanque") == id);

            tanque.Tratamentos = findTratamentos;

            tanque.regRemocoes = regRemocoes;

            tanque.regAmostragem = regAmostragens;

            tanque.regManutencao = regManu;

            tanque.regAlimentar = regAli;

            if (tanque.Tratamentos.Any() || tanque.regRemocoes.Any()|| tanque.regAmostragem.Any()|| tanque.regManutencao.Any()|| tanque.regAlimentar.Any())
            {
                tanque.isDeletable = false;
            }
            else
            {
                tanque.isDeletable = true;
            }
            return tanque;
        }
        // GET: Tanques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tanque = await _context.Tanque
               .Include(t => t.CircuitoTanqueIdCircuitoNavigation)
               .Include(t => t.LoteIdLoteNavigation)
               .SingleOrDefaultAsync(m => m.IdTanque == id);
            if (tanque == null)
            {
                return NotFound();
            }
            tanque = setRelations(tanque, id);
            
            return View(tanque);
        }

        // GET: Tanques/Create
        public IActionResult Create()
        {
            ViewData["CircuitoTanqueIdCircuito"] = new SelectList(_context.CircuitoTanque, "IdCircuito", "CodigoCircuito");
            ViewData["LoteIdLote"] = new SelectList(_context.Lote, "IdLote", "CodigoLote");
            return View();
        }

        // POST: Tanques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTanque,codidenttanque,NroAnimais,Sala,Observacoes,LoteIdLote,CircuitoTanqueIdCircuito")] Tanque tanque)
        {
            var tanqueCodefindany = _context.Tanque.Where(b => EF.Property<string>(b, "codidenttanque").Equals(tanque.codidenttanque));
            if (tanqueCodefindany.Any())
            {
                ModelState.AddModelError("codidenttanque", string.Format("Já Existe um Tanque com este Identificador", tanque.codidenttanque));
            }
            if (ModelState.IsValid)
            {
                _context.Add(tanque);
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CircuitoTanqueIdCircuito"] = new SelectList(_context.CircuitoTanque, "IdCircuito", "CodigoCircuito", tanque.CircuitoTanqueIdCircuito);
            ViewData["LoteIdLote"] = new SelectList(_context.Lote, "IdLote", "CodigoLote", tanque.LoteIdLote);
            return View(tanque);
        }

        // GET: Tanques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tanque = await _context.Tanque.SingleOrDefaultAsync(m => m.IdTanque == id);
            if (tanque == null)
            {
                return NotFound();
            }
            ViewData["CircuitoTanqueIdCircuito"] = new SelectList(_context.CircuitoTanque, "IdCircuito", "CodigoCircuito", tanque.CircuitoTanqueIdCircuito);
            ViewData["LoteIdLote"] = new SelectList(_context.Lote, "IdLote", "CodigoLote", tanque.LoteIdLote);
            return View(tanque);
        }

        // POST: Tanques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTanque,codidenttanque,NroAnimais,Sala,Observacoes,LoteIdLote,CircuitoTanqueIdCircuito")] Tanque tanque)
        {
            if (id != tanque.IdTanque)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tanque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TanqueExists(tanque.IdTanque))
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
            ViewData["CircuitoTanqueIdCircuito"] = new SelectList(_context.CircuitoTanque, "IdCircuito", "CodigoCircuito", tanque.CircuitoTanqueIdCircuito);
            ViewData["LoteIdLote"] = new SelectList(_context.Lote, "IdLote", "CodigoLote", tanque.LoteIdLote);
            return View(tanque);
        }

        // GET: Tanques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tanque = await _context.Tanque
                .Include(t => t.CircuitoTanqueIdCircuitoNavigation)
                .Include(t => t.LoteIdLoteNavigation)
                .SingleOrDefaultAsync(m => m.IdTanque == id);
            tanque = setRelations(tanque, tanque.IdTanque);
            if (tanque == null)
            {
                return NotFound();
            }

            return View(tanque);
        }

        // POST: Tanques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var tanque = await _context.Tanque.SingleOrDefaultAsync(m => m.IdTanque == id);
            var regRemocoes = _context.RegRemocoes.Where(b => EF.Property<int>(b, "TanqueIdTanque") == id);
            var regAmostragens =  _context.RegAmostragens.Where(b => EF.Property<int>(b, "TanqueIdTanque") == id);
            var regManu =  _context.RegManutencao.Where(b => EF.Property<int>(b, "TanqueIdTanque") == id);
            var regTrat =  _context.RegTratamento.Where(b => EF.Property<int>(b, "TanqueIdTanque") == id);
            var regAli =  _context.RegAlimentar.Where(b => EF.Property<int>(b, "TanqueIdTanque") == id);
            foreach (var regRemocao in regRemocoes)
            {
               
                _context.RegRemocoes.Remove(regRemocao);
            }
            foreach (var regAmostragem in regAmostragens)
            {
                _context.RegAmostragens.Remove(regAmostragem);
            }
            foreach (var regManutencao in regManu)
            {
                _context.RegManutencao.Remove(regManutencao);
            }
            foreach (var regTratamento in regTrat)
            {
                _context.RegTratamento.Remove(regTratamento);
            }
            foreach (var regAlimentacao in regAli)
            {
                _context.RegAlimentar.Remove(regAlimentacao);
            }
           
            _context.Tanque.Remove(tanque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TanqueExists(int id)
        {
            return _context.Tanque.Any(e => e.IdTanque == id);
        }
    }
}
