using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using copave.Data;
using copave.Models;

namespace Controllers
{
    public class TipoMaquinaController : Controller
    {
        private readonly CopaveContext _context;

        public TipoMaquinaController(CopaveContext context)
        {
            _context = context;
        }

        // GET: TipoMaquina
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoMaquina.ToListAsync());
        }

        // GET: TipoMaquina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMaquina = await _context.TipoMaquina
                .FirstOrDefaultAsync(m => m.TipoId == id);
            if (tipoMaquina == null)
            {
                return NotFound();
            }

            return View(tipoMaquina);
        }

        // GET: TipoMaquina/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMaquina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoId,Descricao")] TipoMaquina tipoMaquina)
        {
            if (ModelState.IsValid)
            {
                tipoMaquina.Descricao = tipoMaquina.Descricao.ToUpper();
                _context.Add(tipoMaquina);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Tipo cadastrado com sucesso!";
                TempData["Titulo"] = "Parabens!";
                TempData["Tipo"] = "success";
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMaquina);
        }

        // GET: TipoMaquina/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMaquina = await _context.TipoMaquina.FindAsync(id);
            if (tipoMaquina == null)
            {
                return NotFound();
            }
            tipoMaquina.Descricao = tipoMaquina.Descricao.ToUpper();
            return View(tipoMaquina);
        }

        // POST: TipoMaquina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoId,Descricao")] TipoMaquina tipoMaquina)
        {
            if (id != tipoMaquina.TipoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tipoMaquina.Descricao = tipoMaquina.Descricao.ToUpper();
                    _context.Update(tipoMaquina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMaquinaExists(tipoMaquina.TipoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["Message"] = "Registro alterado com sucesso!";
                TempData["Titulo"] = "Parabens!";
                TempData["Tipo"] = "success";

                return RedirectToAction(nameof(Index));
            }
            return View(tipoMaquina);
        }

        // GET: TipoMaquina/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMaquina = await _context.TipoMaquina
                .FirstOrDefaultAsync(m => m.TipoId == id);
            if (tipoMaquina == null)
            {
                return NotFound();
            }

            return View(tipoMaquina);
        }

        // POST: TipoMaquina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoMaquina = await _context.TipoMaquina.FindAsync(id);
            _context.TipoMaquina.Remove(tipoMaquina);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Registro deletado com sucesso!";
            TempData["Titulo"] = "Oops!";
            TempData["Tipo"] = "success";
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMaquinaExists(int id)
        {
            return _context.TipoMaquina.Any(e => e.TipoId == id);
        }
    }
}
