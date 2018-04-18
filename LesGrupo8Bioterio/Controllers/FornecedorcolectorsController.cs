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
    public class FornecedorcolectorsController : Controller
    {
        private readonly bd_lesContext _context;

        public FornecedorcolectorsController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Fornecedorcolectors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fornecedorcolector.ToListAsync());
        }

        // GET: Fornecedorcolectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorcolector = await _context.Fornecedorcolector
                .SingleOrDefaultAsync(m => m.IdFornColect == id);
            if (fornecedorcolector == null)
            {
                return NotFound();
            }

            return View(fornecedorcolector);
        }

        // GET: Fornecedorcolectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedorcolectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFornColect,Tipo,Nome,Nif,NroLicenca,Morada,Telefone")] Fornecedorcolector fornecedorcolector)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedorcolector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorcolector);
        }

        // GET: Fornecedorcolectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorcolector = await _context.Fornecedorcolector.SingleOrDefaultAsync(m => m.IdFornColect == id);
            if (fornecedorcolector == null)
            {
                return NotFound();
            }
            return View(fornecedorcolector);
        }

        // POST: Fornecedorcolectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFornColect,Tipo,Nome,Nif,NroLicenca,Morada,Telefone")] Fornecedorcolector fornecedorcolector)
        {
            if (id != fornecedorcolector.IdFornColect)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fornecedorcolector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorcolectorExists(fornecedorcolector.IdFornColect))
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
            return View(fornecedorcolector);
        }

        // GET: Fornecedorcolectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorcolector = await _context.Fornecedorcolector
                .SingleOrDefaultAsync(m => m.IdFornColect == id);
            if (fornecedorcolector == null)
            {
                return NotFound();
            }

            return View(fornecedorcolector);
        }

        // POST: Fornecedorcolectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedorcolector = await _context.Fornecedorcolector.SingleOrDefaultAsync(m => m.IdFornColect == id);
            _context.Fornecedorcolector.Remove(fornecedorcolector);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorcolectorExists(int id)
        {
            return _context.Fornecedorcolector.Any(e => e.IdFornColect == id);
        }
    }
}
