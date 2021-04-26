using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using copave.Data;
using copave.Models;

namespace Controllers
{
    public class MaquinaController : Controller
    {
        private readonly CopaveContext _context;
        public MaquinaController(CopaveContext context)
        {
            _context = context;
        }
        
        // GET: Maquina
        public async Task<IActionResult> Index(string bucarMaquina)
        {
            var copaveContext = _context.Maquina.Include(m => m.Tipo);
            if (!String.IsNullOrEmpty(bucarMaquina))
            {
                copaveContext = _context.Maquina.Where(m => m.Id == Convert.ToInt32(bucarMaquina)).Include(m => m.Tipo);
            }
            return View(await copaveContext.ToListAsync());
        }

        // GET: Maquina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquina
                .Include(m => m.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maquina == null)
            {  
                return NotFound();
            }
            return View(maquina);
        }

        // GET: Maquina/Create
        public IActionResult Create()
        {
            ViewData["TipoId"] = new SelectList(_context.TipoMaquina, "TipoId", "Descricao");
            return View();
        }
        // POST: Maquina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,TipoId,Instalacao,Valor")] Maquina maquina)
        {
            if (ModelState.IsValid)
            {
                maquina.Descricao = maquina.Descricao.ToUpper();
                _context.Add(maquina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoId"] = new SelectList(_context.TipoMaquina, "TipoId", "Descricao", maquina.TipoId);
            return View(maquina);
        }

        // GET: Maquina/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquina.FindAsync(id);
            if (maquina == null)
            {
                return NotFound();
            }
            ViewData["TipoId"] = new SelectList(_context.TipoMaquina, "TipoId", "Descricao", maquina.TipoId);
            return View(maquina);
        }

        // POST: Maquina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,TipoId,Instalacao,Valor")] Maquina maquina)
        {
            if (id != maquina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    maquina.Descricao = maquina.Descricao.ToUpper();
                    _context.Update(maquina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaquinaExists(maquina.Id))
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
            ViewData["TipoId"] = new SelectList(_context.TipoMaquina, "TipoId", "Descricao", maquina.TipoId);
            return View(maquina);
        }

        // GET: Maquina/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var maquina = await _context.Maquina
                .Include(m => m.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maquina == null)
            {
                return NotFound();
            }
            return View(maquina);
        }

        // POST: Maquina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maquina = await _context.Maquina.FindAsync(id);
            _context.Maquina.Remove(maquina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaquinaExists(int id)
        {
            return _context.Maquina.Any(e => e.Id == id);
        }
    }
}
