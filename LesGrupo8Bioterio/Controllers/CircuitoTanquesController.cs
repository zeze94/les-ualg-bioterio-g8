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
    public class CircuitoTanquesController : Controller
    {
        private readonly bd_lesContext _context;

        public CircuitoTanquesController(bd_lesContext context)
        {
            _context = context;
        } 

        // GET: CircuitoTanques
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.CircuitoTanque.Include(c => c.ProjetoIdProjetoNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: CircuitoTanques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circuitoTanque = await _context.CircuitoTanque
                .Include(c => c.ProjetoIdProjetoNavigation)
                .SingleOrDefaultAsync(m => m.IdCircuito == id);
            if (circuitoTanque == null)
            {
                return NotFound();
            }

            return View(circuitoTanque);
        }

        // GET: CircuitoTanques/Create
        public IActionResult Create()
        {
            ViewData["ProjetoIdProjeto"] = new SelectList(_context.Projeto, "IdProjeto", "Nome");
            return View();
        }

        // POST: CircuitoTanques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCircuito,ProjetoIdProjeto,CodigoCircuito,DataCriacao,DataFinal")] CircuitoTanque circuitoTanque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(circuitoTanque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjetoIdProjeto"] = new SelectList(_context.Projeto, "IdProjeto", "Nome", circuitoTanque.ProjetoIdProjeto);
            return View(circuitoTanque);
        }

        // GET: CircuitoTanques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circuitoTanque = await _context.CircuitoTanque.SingleOrDefaultAsync(m => m.IdCircuito == id);
            if (circuitoTanque == null)
            {
                return NotFound();
            }
            ViewData["ProjetoIdProjeto"] = new SelectList(_context.Projeto, "IdProjeto", "Nome", circuitoTanque.ProjetoIdProjeto);
            return View(circuitoTanque);
        }

        // POST: CircuitoTanques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCircuito,ProjetoIdProjeto,CodigoCircuito,DataCriacao,DataFinal")] CircuitoTanque circuitoTanque)
        {
            if (id != circuitoTanque.IdCircuito)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(circuitoTanque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CircuitoTanqueExists(circuitoTanque.IdCircuito))
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
            ViewData["ProjetoIdProjeto"] = new SelectList(_context.Projeto, "IdProjeto", "Nome", circuitoTanque.ProjetoIdProjeto);
            return View(circuitoTanque);
        }

        // GET: CircuitoTanques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circuitoTanque = await _context.CircuitoTanque
                .Include(c => c.ProjetoIdProjetoNavigation)
                .SingleOrDefaultAsync(m => m.IdCircuito == id);
            if (circuitoTanque == null)
            {
                return NotFound();
            }

            return View(circuitoTanque);
        }

        // POST: CircuitoTanques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var circuitoTanque = await _context.CircuitoTanque.SingleOrDefaultAsync(m => m.IdCircuito == id);
            _context.CircuitoTanque.Remove(circuitoTanque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CircuitoTanqueExists(int id)
        {
            return _context.CircuitoTanque.Any(e => e.IdCircuito == id);
        }
    }
}
