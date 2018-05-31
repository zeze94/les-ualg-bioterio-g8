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
    public class RegTratamentoesController : Controller
    {
        private readonly bd_lesContext _context;

        public RegTratamentoesController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: RegTratamentoes
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.RegTratamento.Include(r => r.AgenteTratIdAgenTraNavigation).Include(r => r.FinalidadeIdFinalidadeNavigation).Include(r => r.TanqueIdTanqueNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: RegTratamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regTratamento = await _context.RegTratamento
                .Include(r => r.AgenteTratIdAgenTraNavigation)
                .Include(r => r.FinalidadeIdFinalidadeNavigation)
                .Include(r => r.TanqueIdTanqueNavigation)
                .SingleOrDefaultAsync(m => m.IdRegTra == id);
            regTratamento.data = regTratamento.Date.Day + "/" + regTratamento.Date.Month + "/" + regTratamento.Date.Year;
            if (regTratamento == null)
            {
                return NotFound();
            }

            return View(regTratamento);
        }

        // GET: RegTratamentoes/Create
        public IActionResult Create()
        {
            
            ViewData["AgenteTratIdAgenTra"] = new SelectList(_context.AgenteTrat, "IdAgenTra", "NomeAgenTra");
            ViewData["FinalidadeIdFinalidade"] = new SelectList(_context.Finalidade, "IdFinalidade", "TFinalidade");
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque, "IdTanque", "codidenttanque");
            return View();
        }

        // POST: RegTratamentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegTra,Date,Tempo,Concentracao,FinalidadeIdFinalidade,AgenteTratIdAgenTra,ConcAgenTra,TanqueIdTanque")] RegTratamento regTratamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regTratamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgenteTratIdAgenTra"] = new SelectList(_context.AgenteTrat, "IdAgenTra", "NomeAgenTra", regTratamento.AgenteTratIdAgenTra);
            ViewData["FinalidadeIdFinalidade"] = new SelectList(_context.Finalidade, "IdFinalidade", "TFinalidade", regTratamento.FinalidadeIdFinalidade);
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque, "IdTanque", "codidenttanque", regTratamento.TanqueIdTanque);
            return View(regTratamento);
        }

        // GET: RegTratamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regTratamento = await _context.RegTratamento.SingleOrDefaultAsync(m => m.IdRegTra == id);
            if (regTratamento == null)
            {
                return NotFound();
            }
            ViewData["AgenteTratIdAgenTra"] = new SelectList(_context.AgenteTrat, "IdAgenTra", "NomeAgenTra", regTratamento.AgenteTratIdAgenTra);
            ViewData["FinalidadeIdFinalidade"] = new SelectList(_context.Finalidade, "IdFinalidade", "TFinalidade", regTratamento.FinalidadeIdFinalidade);
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque, "IdTanque", "Sala", regTratamento.TanqueIdTanque);
            return View(regTratamento);
        }

        // POST: RegTratamentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegTra,Date,Tempo,Concentracao,FinalidadeIdFinalidade,AgenteTratIdAgenTra,ConcAgenTra,TanqueIdTanque")] RegTratamento regTratamento)
        {
            if (id != regTratamento.IdRegTra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regTratamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegTratamentoExists(regTratamento.IdRegTra))
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
            ViewData["AgenteTratIdAgenTra"] = new SelectList(_context.AgenteTrat, "IdAgenTra", "NomeAgenTra", regTratamento.AgenteTratIdAgenTra);
            ViewData["FinalidadeIdFinalidade"] = new SelectList(_context.Finalidade, "IdFinalidade", "IdFinalidade", regTratamento.FinalidadeIdFinalidade);
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque, "IdTanque", "Sala", regTratamento.TanqueIdTanque);
            return View(regTratamento);
        }

        // GET: RegTratamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regTratamento = await _context.RegTratamento
                .Include(r => r.AgenteTratIdAgenTraNavigation)
                .Include(r => r.FinalidadeIdFinalidadeNavigation)
                .Include(r => r.TanqueIdTanqueNavigation)
                .SingleOrDefaultAsync(m => m.IdRegTra == id);
            regTratamento.data = regTratamento.Date.Day + "/" + regTratamento.Date.Month + "/" + regTratamento.Date.Year;
            if (regTratamento == null)
            {
                return NotFound();
            }

            return View(regTratamento);
        }

        // POST: RegTratamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regTratamento = await _context.RegTratamento.SingleOrDefaultAsync(m => m.IdRegTra == id);
            _context.RegTratamento.Remove(regTratamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegTratamentoExists(int id)
        {
            return _context.RegTratamento.Any(e => e.IdRegTra == id);
        }
    }
}
