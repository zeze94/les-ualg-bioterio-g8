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
    public class TOrigemsController : Controller
    {
        private readonly bd_lesContext _context;

        public TOrigemsController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: TOrigems
        public async Task<IActionResult> Index()
        {
            return View(await _context.TOrigem.ToListAsync());
        }

        // GET: TOrigems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOrigem = await _context.TOrigem
                .SingleOrDefaultAsync(m => m.IdTOrigem == id);
            if (tOrigem == null)
            {
                return NotFound();
            }

            return View(tOrigem);
        }

        // GET: TOrigems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TOrigems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTOrigem,Descrição")] TOrigem tOrigem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tOrigem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tOrigem);
        }

        // GET: TOrigems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOrigem = await _context.TOrigem.SingleOrDefaultAsync(m => m.IdTOrigem == id);
            if (tOrigem == null)
            {
                return NotFound();
            }
            return View(tOrigem);
        }

        // POST: TOrigems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTOrigem,Descrição")] TOrigem tOrigem)
        {
            if (id != tOrigem.IdTOrigem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tOrigem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TOrigemExists(tOrigem.IdTOrigem))
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
            return View(tOrigem);
        }

        // GET: TOrigems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOrigem = await _context.TOrigem
                .SingleOrDefaultAsync(m => m.IdTOrigem == id);
            if (tOrigem == null)
            {
                return NotFound();
            }

            return View(tOrigem);
        }

        // POST: TOrigems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tOrigem = await _context.TOrigem.SingleOrDefaultAsync(m => m.IdTOrigem == id);
            _context.TOrigem.Remove(tOrigem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TOrigemExists(int id)
        {
            return _context.TOrigem.Any(e => e.IdTOrigem == id);
        }
    }
}
