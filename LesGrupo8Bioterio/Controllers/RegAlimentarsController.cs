﻿using System;
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
    public class RegAlimentarsController : Controller
    {
        private readonly bd_lesContext _context;

        public RegAlimentarsController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: RegAlimentars
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.RegAlimentar.Include(r => r.PlanoAlimentarIdPlanAlimNavigation).Include(r => r.TanqueIdTanqueNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: RegAlimentars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regAlimentar = await _context.RegAlimentar
                .Include(r => r.PlanoAlimentarIdPlanAlimNavigation)
                .Include(r => r.TanqueIdTanqueNavigation)
                .SingleOrDefaultAsync(m => m.IdRegAlim == id);
            if (regAlimentar == null || regAlimentar.isarchived == 1)
            {
                return NotFound();
            }
            regAlimentar.data = regAlimentar.Data.Day + "/" + regAlimentar.Data.Month + "/" + regAlimentar.Data.Year;
            return View(regAlimentar);
        }

        // GET: RegAlimentars/Create
        public IActionResult Create()
        {
            ViewData["PlanoAlimentarIdPlanAlim"] = new SelectList(_context.PlanoAlimentar, "IdPlanAlim", "Nome");
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque.Where(p => p.isarchived == 0), "IdTanque", "codidenttanque");
            return View();
        }

        // POST: RegAlimentars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegAlim,Data,Peso,Sobras,PlanoAlimentarIdPlanAlim,TanqueIdTanque")] RegAlimentar regAlimentar)
        {
            if (regAlimentar.Peso < 0)
            {
                ModelState.AddModelError("Peso", string.Format("Este valor tem de ser positivo", regAlimentar.Peso));
            }
            if (regAlimentar.Sobras < 0)
            {
                ModelState.AddModelError("Sobras", string.Format("Este valor tem de ser positivo", regAlimentar.Sobras));
            }
            if (ModelState.IsValid)
            {
                _context.Add(regAlimentar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlanoAlimentarIdPlanAlim"] = new SelectList(_context.PlanoAlimentar, "IdPlanAlim", "Nome", regAlimentar.PlanoAlimentarIdPlanAlim);
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque.Where(p => p.isarchived == 0), "IdTanque", "codidenttanque", regAlimentar.TanqueIdTanque);
            return View(regAlimentar);
        }

        // GET: RegAlimentars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

         
            var regAlimentar = await _context.RegAlimentar.SingleOrDefaultAsync(m => m.IdRegAlim == id);
            if (regAlimentar == null || regAlimentar.isarchived == 1)
            {
                return NotFound();
            }
            ViewData["PlanoAlimentarIdPlanAlim"] = new SelectList(_context.PlanoAlimentar, "IdPlanAlim", "Nome", regAlimentar.PlanoAlimentarIdPlanAlim);
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque.Where(p => p.isarchived == 0), "IdTanque", "codidenttanque", regAlimentar.TanqueIdTanque);
            return View(regAlimentar);
        }

        // POST: RegAlimentars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegAlim,Data,Peso,Sobras,PlanoAlimentarIdPlanAlim,TanqueIdTanque")] RegAlimentar regAlimentar)
        {
            if (id != regAlimentar.IdRegAlim)
            {
                return NotFound();
            }

            if (regAlimentar.Peso < 0)
            {
                ModelState.AddModelError("Peso", string.Format("Este valor tem de ser positivo", regAlimentar.Peso));
            }
            if (regAlimentar.Sobras < 0)
            {
                ModelState.AddModelError("Sobras", string.Format("Este valor tem de ser positivo", regAlimentar.Sobras));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regAlimentar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegAlimentarExists(regAlimentar.IdRegAlim))
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
            ViewData["PlanoAlimentarIdPlanAlim"] = new SelectList(_context.PlanoAlimentar, "IdPlanAlim", "Nome", regAlimentar.PlanoAlimentarIdPlanAlim);
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque.Where(p => p.isarchived == 0), "IdTanque", "codidenttanque", regAlimentar.TanqueIdTanque);
            return View(regAlimentar);
        }

        // GET: RegAlimentars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regAlimentar = await _context.RegAlimentar
                .Include(r => r.PlanoAlimentarIdPlanAlimNavigation)
                .Include(r => r.TanqueIdTanqueNavigation)
                .SingleOrDefaultAsync(m => m.IdRegAlim == id);
            if (regAlimentar == null || regAlimentar.isarchived == 1)
            {
                return NotFound();
            }
            regAlimentar.data = regAlimentar.Data.Day + "/" + regAlimentar.Data.Month + "/" + regAlimentar.Data.Year;
            return View(regAlimentar);
        }

        // POST: RegAlimentars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regAlimentar = await _context.RegAlimentar.SingleOrDefaultAsync(m => m.IdRegAlim == id);
            _context.RegAlimentar.Remove(regAlimentar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegAlimentarExists(int id)
        {
            return _context.RegAlimentar.Any(e => e.IdRegAlim == id);
        }
    }
}
