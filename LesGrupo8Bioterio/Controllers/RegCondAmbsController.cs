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
    public class RegCondAmbsController : Controller
    {
        private readonly bd_lesContext _context;

        public RegCondAmbsController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: RegCondAmbs
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.RegCondAmb.Include(r => r.CircuitoTanqueIdCircuitoNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: RegCondAmbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regCondAmb = await _context.RegCondAmb
                .Include(r => r.CircuitoTanqueIdCircuitoNavigation)
                .SingleOrDefaultAsync(m => m.IdRegCondAmb == id);
            if (regCondAmb == null)
            {
                return NotFound();
            }

            return View(regCondAmb);
        }

        // GET: RegCondAmbs/Create
        public IActionResult Create()
        {
            ViewData["CircuitoTanqueIdCircuito"] = new SelectList(_context.CircuitoTanque, "IdCircuito", "IdCircuito");
            return View();
        }

        // POST: RegCondAmbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegCondAmb,Data,Temperatura,VolAgua,SalinidadeAgua,NivelO2,CircuitoTanqueIdCircuito")] RegCondAmb regCondAmb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regCondAmb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CircuitoTanqueIdCircuito"] = new SelectList(_context.CircuitoTanque, "IdCircuito", "IdCircuito", regCondAmb.CircuitoTanqueIdCircuito);
            return View(regCondAmb);
        }

        // GET: RegCondAmbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regCondAmb = await _context.RegCondAmb.SingleOrDefaultAsync(m => m.IdRegCondAmb == id);
            if (regCondAmb == null)
            {
                return NotFound();
            }
            ViewData["CircuitoTanqueIdCircuito"] = new SelectList(_context.CircuitoTanque, "IdCircuito", "IdCircuito", regCondAmb.CircuitoTanqueIdCircuito);
            return View(regCondAmb);
        }

        // POST: RegCondAmbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegCondAmb,Data,Temperatura,VolAgua,SalinidadeAgua,NivelO2,CircuitoTanqueIdCircuito")] RegCondAmb regCondAmb)
        {
            if (id != regCondAmb.IdRegCondAmb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regCondAmb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegCondAmbExists(regCondAmb.IdRegCondAmb))
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
            ViewData["CircuitoTanqueIdCircuito"] = new SelectList(_context.CircuitoTanque, "IdCircuito", "IdCircuito", regCondAmb.CircuitoTanqueIdCircuito);
            return View(regCondAmb);
        }

        // GET: RegCondAmbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regCondAmb = await _context.RegCondAmb
                .Include(r => r.CircuitoTanqueIdCircuitoNavigation)
                .SingleOrDefaultAsync(m => m.IdRegCondAmb == id);
            if (regCondAmb == null)
            {
                return NotFound();
            }

            return View(regCondAmb);
        }

        // POST: RegCondAmbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regCondAmb = await _context.RegCondAmb.SingleOrDefaultAsync(m => m.IdRegCondAmb == id);
            _context.RegCondAmb.Remove(regCondAmb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegCondAmbExists(int id)
        {
            return _context.RegCondAmb.Any(e => e.IdRegCondAmb == id);
        }
    }
}
