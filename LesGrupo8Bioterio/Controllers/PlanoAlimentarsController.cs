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
    public class PlanoAlimentarsController : Controller
    {
        private readonly bd_lesContext _context;

        public PlanoAlimentarsController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: PlanoAlimentars
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlanoAlimentar.ToListAsync());
        }

        // GET: PlanoAlimentars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoAlimentar = await _context.PlanoAlimentar
                .SingleOrDefaultAsync(m => m.IdPlanAlim == id);
            if (planoAlimentar == null)
            {
                return NotFound();
            }

            return View(planoAlimentar);
        }

        // GET: PlanoAlimentars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlanoAlimentars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPlanAlim,Nome,MarcaAlim,Tipo,Temperatura,Racao,RacaoDia")] PlanoAlimentar planoAlimentar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planoAlimentar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planoAlimentar);
        }

        // GET: PlanoAlimentars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoAlimentar = await _context.PlanoAlimentar.SingleOrDefaultAsync(m => m.IdPlanAlim == id);
            if (planoAlimentar == null)
            {
                return NotFound();
            }
            return View(planoAlimentar);
        }

        // POST: PlanoAlimentars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPlanAlim,Nome,MarcaAlim,Tipo,Temperatura,Racao,RacaoDia")] PlanoAlimentar planoAlimentar)
        {
            if (id != planoAlimentar.IdPlanAlim)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planoAlimentar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanoAlimentarExists(planoAlimentar.IdPlanAlim))
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
            return View(planoAlimentar);
        }

        // GET: PlanoAlimentars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoAlimentar = await _context.PlanoAlimentar
                .SingleOrDefaultAsync(m => m.IdPlanAlim == id);
            if (planoAlimentar == null)
            {
                return NotFound();
            }

            return View(planoAlimentar);
        }

        // POST: PlanoAlimentars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planoAlimentar = await _context.PlanoAlimentar.SingleOrDefaultAsync(m => m.IdPlanAlim == id);
            _context.PlanoAlimentar.Remove(planoAlimentar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanoAlimentarExists(int id)
        {
            return _context.PlanoAlimentar.Any(e => e.IdPlanAlim == id);
        }
    }
}
