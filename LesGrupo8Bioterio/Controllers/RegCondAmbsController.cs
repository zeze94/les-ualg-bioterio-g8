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
            if (regCondAmb == null || regCondAmb.isarchived == 1)
            {
                return NotFound();
            }
            regCondAmb = setdisplaydate(regCondAmb);
            return View(regCondAmb);
        }

        // GET: RegCondAmbs/Create
        public IActionResult Create()
        {
            ViewData["CircuitoTanqueIdCircuito"] = new SelectList(_context.CircuitoTanque.Where(p => p.isarchived == 0), "IdCircuito", "CodigoCircuito");
            return View();
        }

        // POST: RegCondAmbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegCondAmb,Data,Temperatura,VolAgua,SalinidadeAgua,NivelO2,CircuitoTanqueIdCircuito")] RegCondAmb regCondAmb)
        {
            if (regCondAmb.VolAgua < 0)
            {
                ModelState.AddModelError("VolAgua", string.Format("Este valor tem de ser positivo", regCondAmb.VolAgua));
            }
            if (regCondAmb.SalinidadeAgua < 0)
            {
                ModelState.AddModelError("SalinidadeAgua", string.Format("Este valor tem de ser positivo", regCondAmb.SalinidadeAgua));
            }
            if (regCondAmb.NivelO2 < 0)
            {
                ModelState.AddModelError("NivelO2", string.Format("Este valor tem de ser positivo", regCondAmb.NivelO2));
            }
            if (ModelState.IsValid)
            {
                _context.Add(regCondAmb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CircuitoTanqueIdCircuito"] = new SelectList(_context.CircuitoTanque.Where(p => p.isarchived == 0), "IdCircuito", "CodigoCircuito", regCondAmb.CircuitoTanqueIdCircuito);
            return View(regCondAmb);
        }

        public RegCondAmb setdisplaydate(RegCondAmb t)
        {
            t.data = t.Data.Day + "/" + t.Data.Month + "/" + t.Data.Year;
            return t;
        }
        // GET: RegCondAmbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regCondAmb = await _context.RegCondAmb.SingleOrDefaultAsync(m => m.IdRegCondAmb == id);
            if (regCondAmb == null || regCondAmb.isarchived == 1)
            {
                return NotFound();
            }
            ViewData["CircuitoTanqueIdCircuito"] = new SelectList(_context.CircuitoTanque.Where(p => p.isarchived == 0), "IdCircuito", "CodigoCircuito", regCondAmb.CircuitoTanqueIdCircuito);
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
            if (regCondAmb.VolAgua < 0)
            {
                ModelState.AddModelError("VolAgua", string.Format("Este valor tem de ser positivo", regCondAmb.VolAgua));
            }
            if (regCondAmb.SalinidadeAgua < 0)
            {
                ModelState.AddModelError("SalinidadeAgua", string.Format("Este valor tem de ser positivo", regCondAmb.SalinidadeAgua));
            }
            if (regCondAmb.NivelO2 < 0)
            {
                ModelState.AddModelError("NivelO2", string.Format("Este valor tem de ser positivo", regCondAmb.NivelO2));
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
            ViewData["CircuitoTanqueIdCircuito"] = new SelectList(_context.CircuitoTanque.Where(p => p.isarchived == 0), "IdCircuito", "CodigoCircuito", regCondAmb.CircuitoTanqueIdCircuito);
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
            regCondAmb = setdisplaydate(regCondAmb);

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
