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
    public class RegNovosAnimaisController : Controller
    {
        private readonly bd_lesContext _context;

        public RegNovosAnimaisController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: RegNovosAnimais
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.RegNovosAnimais.Include(r => r.FornecedorIdFornColectNavigation).Include(r => r.FuncionarioIdFuncionario1Navigation).Include(r => r.FuncionarioIdFuncionarioNavigation).Include(r => r.TOrigemIdTOrigemNavigation).Include(r => r.TipoEstatutoGeneticoIdTipoEstatutoGeneticoNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: RegNovosAnimais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regNovosAnimais = await _context.RegNovosAnimais
                .Include(r => r.FornecedorIdFornColectNavigation)
                .Include(r => r.FuncionarioIdFuncionario1Navigation)
                .Include(r => r.FuncionarioIdFuncionarioNavigation)
                .Include(r => r.TOrigemIdTOrigemNavigation)
                .Include(r => r.TipoEstatutoGeneticoIdTipoEstatutoGeneticoNavigation)
                .SingleOrDefaultAsync(m => m.IdRegAnimal == id);
            if (regNovosAnimais == null)
            {
                return NotFound();
            }

            return View(regNovosAnimais);
        }

        // GET: RegNovosAnimais/Create
        public IActionResult Create()
        {
            ViewData["FornecedorIdFornColect"] = new SelectList(_context.Fornecedorcolector, "IdFornColect", "Tipo");
            ViewData["FuncionarioIdFuncionario1"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto");
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto");
            ViewData["TOrigemIdTOrigem"] = new SelectList(_context.TOrigem, "IdTOrigem", "IdTOrigem");
            ViewData["TipoEstatutoGeneticoIdTipoEstatutoGenetico"] = new SelectList(_context.Tipoestatutogenetico, "IdTipoEstatutoGenetico", "IdTipoEstatutoGenetico");
            return View();
        }

        // POST: RegNovosAnimais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegAnimal,NroExemplares,NroMachos,NroFemeas,Imaturos,Juvenis,Larvas,Ovos,DataNasc,Idade,PesoMedio,CompMedio,DuracaoViagem,TempPartida,TempChegada,NroContentores,TipoContentor,VolContentor,VolAgua,NroCaixasIsoter,NroMortosCheg,SatO2transp,Anestesico,Gelo,AdicaoO2,Arejamento,Refrigeracao,Sedação,RespTransporte,EspecieIdEspecie,FornecedorIdFornColect,TOrigemIdTOrigem,LocalCapturaIdLocalCaptura,TipoEstatutoGeneticoIdTipoEstatutoGenetico,FuncionarioIdFuncionario,FuncionarioIdFuncionario1")] RegNovosAnimais regNovosAnimais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regNovosAnimais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FornecedorIdFornColect"] = new SelectList(_context.Fornecedorcolector, "IdFornColect", "Tipo", regNovosAnimais.FornecedorIdFornColect);
            ViewData["FuncionarioIdFuncionario1"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto", regNovosAnimais.FuncionarioIdFuncionario1);
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto", regNovosAnimais.FuncionarioIdFuncionario);
            ViewData["TOrigemIdTOrigem"] = new SelectList(_context.TOrigem, "IdTOrigem", "IdTOrigem", regNovosAnimais.TOrigemIdTOrigem);
            ViewData["TipoEstatutoGeneticoIdTipoEstatutoGenetico"] = new SelectList(_context.Tipoestatutogenetico, "IdTipoEstatutoGenetico", "IdTipoEstatutoGenetico", regNovosAnimais.TipoEstatutoGeneticoIdTipoEstatutoGenetico);
            return View(regNovosAnimais);
        }

        // GET: RegNovosAnimais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regNovosAnimais = await _context.RegNovosAnimais.SingleOrDefaultAsync(m => m.IdRegAnimal == id);
            if (regNovosAnimais == null)
            {
                return NotFound();
            }
            ViewData["FornecedorIdFornColect"] = new SelectList(_context.Fornecedorcolector, "IdFornColect", "Tipo", regNovosAnimais.FornecedorIdFornColect);
            ViewData["FuncionarioIdFuncionario1"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto", regNovosAnimais.FuncionarioIdFuncionario1);
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto", regNovosAnimais.FuncionarioIdFuncionario);
            ViewData["TOrigemIdTOrigem"] = new SelectList(_context.TOrigem, "IdTOrigem", "IdTOrigem", regNovosAnimais.TOrigemIdTOrigem);
            ViewData["TipoEstatutoGeneticoIdTipoEstatutoGenetico"] = new SelectList(_context.Tipoestatutogenetico, "IdTipoEstatutoGenetico", "IdTipoEstatutoGenetico", regNovosAnimais.TipoEstatutoGeneticoIdTipoEstatutoGenetico);
            return View(regNovosAnimais);
        }

        // POST: RegNovosAnimais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegAnimal,NroExemplares,NroMachos,NroFemeas,Imaturos,Juvenis,Larvas,Ovos,DataNasc,Idade,PesoMedio,CompMedio,DuracaoViagem,TempPartida,TempChegada,NroContentores,TipoContentor,VolContentor,VolAgua,NroCaixasIsoter,NroMortosCheg,SatO2transp,Anestesico,Gelo,AdicaoO2,Arejamento,Refrigeracao,Sedação,RespTransporte,EspecieIdEspecie,FornecedorIdFornColect,TOrigemIdTOrigem,LocalCapturaIdLocalCaptura,TipoEstatutoGeneticoIdTipoEstatutoGenetico,FuncionarioIdFuncionario,FuncionarioIdFuncionario1")] RegNovosAnimais regNovosAnimais)
        {
            if (id != regNovosAnimais.IdRegAnimal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regNovosAnimais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegNovosAnimaisExists(regNovosAnimais.IdRegAnimal))
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
            ViewData["FornecedorIdFornColect"] = new SelectList(_context.Fornecedorcolector, "IdFornColect", "Tipo", regNovosAnimais.FornecedorIdFornColect);
            ViewData["FuncionarioIdFuncionario1"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto", regNovosAnimais.FuncionarioIdFuncionario1);
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto", regNovosAnimais.FuncionarioIdFuncionario);
            ViewData["TOrigemIdTOrigem"] = new SelectList(_context.TOrigem, "IdTOrigem", "IdTOrigem", regNovosAnimais.TOrigemIdTOrigem);
            ViewData["TipoEstatutoGeneticoIdTipoEstatutoGenetico"] = new SelectList(_context.Tipoestatutogenetico, "IdTipoEstatutoGenetico", "IdTipoEstatutoGenetico", regNovosAnimais.TipoEstatutoGeneticoIdTipoEstatutoGenetico);
            return View(regNovosAnimais);
        }

        // GET: RegNovosAnimais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regNovosAnimais = await _context.RegNovosAnimais
                .Include(r => r.FornecedorIdFornColectNavigation)
                .Include(r => r.FuncionarioIdFuncionario1Navigation)
                .Include(r => r.FuncionarioIdFuncionarioNavigation)
                .Include(r => r.TOrigemIdTOrigemNavigation)
                .Include(r => r.TipoEstatutoGeneticoIdTipoEstatutoGeneticoNavigation)
                .SingleOrDefaultAsync(m => m.IdRegAnimal == id);
            if (regNovosAnimais == null)
            {
                return NotFound();
            }

            return View(regNovosAnimais);
        }

        // POST: RegNovosAnimais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regNovosAnimais = await _context.RegNovosAnimais.SingleOrDefaultAsync(m => m.IdRegAnimal == id);
            _context.RegNovosAnimais.Remove(regNovosAnimais);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegNovosAnimaisExists(int id)
        {
            return _context.RegNovosAnimais.Any(e => e.IdRegAnimal == id);
        }
    }
}
