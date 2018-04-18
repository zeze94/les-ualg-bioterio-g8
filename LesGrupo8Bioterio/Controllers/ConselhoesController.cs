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
    public class ConselhoesController : Controller
    {
        private readonly bd_lesContext _context;

        public ConselhoesController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Conselhoes
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.Conselho.Include(c => c.Distrito);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: Conselhoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conselho = await _context.Conselho
                .Include(c => c.Distrito)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (conselho == null)
            {
                return NotFound();
            }

            return View(conselho);
        }

        // GET: Conselhoes/Create
        public IActionResult Create()
        {
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "Id", "Id");
            return View();
        }

        // POST: Conselhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeConselho,DistritoId")] Conselho conselho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conselho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "Id", "Id", conselho.DistritoId);
            return View(conselho);
        }

        // GET: Conselhoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conselho = await _context.Conselho.SingleOrDefaultAsync(m => m.Id == id);
            if (conselho == null)
            {
                return NotFound();
            }
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "Id", "Id", conselho.DistritoId);
            return View(conselho);
        }

        // POST: Conselhoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeConselho,DistritoId")] Conselho conselho)
        {
            if (id != conselho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conselho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConselhoExists(conselho.Id))
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
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "Id", "Id", conselho.DistritoId);
            return View(conselho);
        }

        // GET: Conselhoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conselho = await _context.Conselho
                .Include(c => c.Distrito)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (conselho == null)
            {
                return NotFound();
            }

            return View(conselho);
        }

        // POST: Conselhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conselho = await _context.Conselho.SingleOrDefaultAsync(m => m.Id == id);
            _context.Conselho.Remove(conselho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConselhoExists(int id)
        {
            return _context.Conselho.Any(e => e.Id == id);
        }
    }
}
