using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBMVCTrabalho2.Models;

namespace WEBMVCTrabalho2.Controllers
{
    public class Categoria_GastosController : Controller
    {
        private readonly Contexto _context;

        public Categoria_GastosController(Contexto context)
        {
            _context = context;
        }

        // GET: Categoria_Gastos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Categoria_Gastos.ToListAsync());
        }

        // GET: Categoria_Gastos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Categoria_Gastos == null)
            {
                return NotFound();
            }

            var categoria_Gastos = await _context.Categoria_Gastos
                .FirstOrDefaultAsync(m => m.id == id);
            if (categoria_Gastos == null)
            {
                return NotFound();
            }

            return View(categoria_Gastos);
        }

        // GET: Categoria_Gastos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoria_Gastos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao")] Categoria_Gastos categoria_Gastos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria_Gastos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria_Gastos);
        }

        // GET: Categoria_Gastos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Categoria_Gastos == null)
            {
                return NotFound();
            }

            var categoria_Gastos = await _context.Categoria_Gastos.FindAsync(id);
            if (categoria_Gastos == null)
            {
                return NotFound();
            }
            return View(categoria_Gastos);
        }

        // POST: Categoria_Gastos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao")] Categoria_Gastos categoria_Gastos)
        {
            if (id != categoria_Gastos.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria_Gastos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Categoria_GastosExists(categoria_Gastos.id))
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
            return View(categoria_Gastos);
        }

        // GET: Categoria_Gastos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Categoria_Gastos == null)
            {
                return NotFound();
            }

            var categoria_Gastos = await _context.Categoria_Gastos
                .FirstOrDefaultAsync(m => m.id == id);
            if (categoria_Gastos == null)
            {
                return NotFound();
            }

            return View(categoria_Gastos);
        }

        // POST: Categoria_Gastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categoria_Gastos == null)
            {
                return Problem("Entity set 'Contexto.Categoria_Gastos'  is null.");
            }
            var categoria_Gastos = await _context.Categoria_Gastos.FindAsync(id);
            if (categoria_Gastos != null)
            {
                _context.Categoria_Gastos.Remove(categoria_Gastos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Categoria_GastosExists(int id)
        {
          return _context.Categoria_Gastos.Any(e => e.id == id);
        }
    }
}
