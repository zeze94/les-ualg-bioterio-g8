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
    public class AgenteTratsController : Controller
    {
        private readonly bd_lesContext _context;

        public AgenteTratsController(bd_lesContext context)
        {
            _context = context;
        }

        private AgenteTrat setRelations(AgenteTrat agente, int? id)
        {
            var regTratamento = _context.RegTratamento.Where(b => EF.Property<int>(b, "AgenteTratIdAgenTra") == id);
            agente.regAgente = regTratamento;

            if (agente.regAgente.Any())
            {
                agente.isDeletable = false;
            }
            else
            {
                agente.isDeletable = true;
            }
            return agente;
        }

        // GET: AgenteTrats
        public async Task<IActionResult> Index()
        {
            return View(await _context.AgenteTrat.ToListAsync());
        }

        // GET: AgenteTrats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenteTrat = await _context.AgenteTrat
                .SingleOrDefaultAsync(m => m.IdAgenTra == id);
            if (agenteTrat == null)
            {
                return NotFound();
            }

            return View(agenteTrat);
        }

        // GET: AgenteTrats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AgenteTrats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAgenTra,NomeAgenTra")] AgenteTrat agenteTrat)
        {
            var cTCodefindany = _context.AgenteTrat.Where(b => EF.Property<string>(b, "NomeAgenTra").Equals(agenteTrat.NomeAgenTra));
            if (cTCodefindany.Any())
            {
                ModelState.AddModelError("NomeAgenTra", string.Format("Este Agente de Tratamento já existe.", agenteTrat.NomeAgenTra));
            }
            if (ModelState.IsValid)
            {
                _context.Add(agenteTrat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agenteTrat);
        }

        // GET: AgenteTrats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenteTrat = await _context.AgenteTrat.SingleOrDefaultAsync(m => m.IdAgenTra == id);
            if (agenteTrat == null)
            {
                return NotFound();
            }
            return View(agenteTrat);
        }

        // POST: AgenteTrats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAgenTra,NomeAgenTra")] AgenteTrat agenteTrat)
        {
            if (id != agenteTrat.IdAgenTra)
            {
                return NotFound();
            }
            var cTCodefindany = _context.AgenteTrat.Where(b => EF.Property<string>(b, "NomeAgenTra").Equals(agenteTrat.NomeAgenTra));
            if (cTCodefindany.Any())
            {
                ModelState.AddModelError("NomeAgenTra", string.Format("Este Agente de Tratamento já existe.", agenteTrat.NomeAgenTra));
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agenteTrat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgenteTratExists(agenteTrat.IdAgenTra))
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
            return View(agenteTrat);
        }

        // GET: AgenteTrats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenteTrat = await _context.AgenteTrat
                .SingleOrDefaultAsync(m => m.IdAgenTra == id);
            agenteTrat = setRelations(agenteTrat, agenteTrat.IdAgenTra);
            if (agenteTrat == null)
            {
                return NotFound();
            }

            return View(agenteTrat);
        }

        // POST: AgenteTrats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agenteTrat = await _context.AgenteTrat.SingleOrDefaultAsync(m => m.IdAgenTra == id);
            _context.AgenteTrat.Remove(agenteTrat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgenteTratExists(int id)
        {
            return _context.AgenteTrat.Any(e => e.IdAgenTra == id);
        }
    }
}
