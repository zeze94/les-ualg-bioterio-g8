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
    public class OrigemsController : Controller
    {
        private readonly bd_lesContext _context;

        public OrigemsController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Origems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Origem.ToListAsync());
        }

        // GET: Origems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origem = await _context.Origem
                .SingleOrDefaultAsync(m => m.IdOrigem == id);
            if (origem == null)
            {
                return NotFound();
            }

            return View(origem);
        }

        // GET: Origems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Origems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrigem,TipoOrigem")] Origem origem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(origem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(origem);
        }

        // GET: Origems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origem = await _context.Origem.SingleOrDefaultAsync(m => m.IdOrigem == id);
            if (origem == null)
            {
                return NotFound();
            }
            return View(origem);
        }

        // POST: Origems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrigem,TipoOrigem")] Origem origem)
        {
            if (id != origem.IdOrigem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(origem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrigemExists(origem.IdOrigem))
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
            return View(origem);
        }

        // GET: Origems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origem = await _context.Origem
                .SingleOrDefaultAsync(m => m.IdOrigem == id);
            if (origem == null)
            {
                return NotFound();
            }

            return View(origem);
        }

        // POST: Origems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var origem = await _context.Origem.SingleOrDefaultAsync(m => m.IdOrigem == id);
            _context.Origem.Remove(origem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrigemExists(int id)
        {
            return _context.Origem.Any(e => e.IdOrigem == id);
        }
    }
}
