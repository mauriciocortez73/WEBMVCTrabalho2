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
    public class Conta_BancariaController : Controller
    {
        private readonly Contexto _context;

        public Conta_BancariaController(Contexto context)
        {
            _context = context;
        }

        // GET: Conta_Bancaria
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Conta_Bancaria.Include(c => c.bancos);
            return View(await contexto.ToListAsync());
        }

        // GET: Conta_Bancaria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conta_Bancaria == null)
            {
                return NotFound();
            }

            var conta_Bancaria = await _context.Conta_Bancaria
                .Include(c => c.bancos)
                .FirstOrDefaultAsync(m => m.id == id);
            if (conta_Bancaria == null)
            {
                return NotFound();
            }

            return View(conta_Bancaria);
        }

        // GET: Conta_Bancaria/Create
        public IActionResult Create()
        {
            ViewData["bancosID"] = new SelectList(_context.Bancos, "id", "descricao");
            return View();
        }

        // POST: Conta_Bancaria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,bancosID,descricao,Saldo")] Conta_Bancaria conta_Bancaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conta_Bancaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["bancosID"] = new SelectList(_context.Bancos, "id", "descricao", conta_Bancaria.bancosID);
            return View(conta_Bancaria);
        }

        // GET: Conta_Bancaria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conta_Bancaria == null)
            {
                return NotFound();
            }

            var conta_Bancaria = await _context.Conta_Bancaria.FindAsync(id);
            if (conta_Bancaria == null)
            {
                return NotFound();
            }
            ViewData["bancosID"] = new SelectList(_context.Bancos, "id", "descricao", conta_Bancaria.bancosID);
            return View(conta_Bancaria);
        }

        // POST: Conta_Bancaria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,bancosID,descricao,Saldo")] Conta_Bancaria conta_Bancaria)
        {
            if (id != conta_Bancaria.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conta_Bancaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Conta_BancariaExists(conta_Bancaria.id))
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
            ViewData["bancosID"] = new SelectList(_context.Bancos, "id", "descricao", conta_Bancaria.bancosID);
            return View(conta_Bancaria);
        }

        // GET: Conta_Bancaria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conta_Bancaria == null)
            {
                return NotFound();
            }

            var conta_Bancaria = await _context.Conta_Bancaria
                .Include(c => c.bancos)
                .FirstOrDefaultAsync(m => m.id == id);
            if (conta_Bancaria == null)
            {
                return NotFound();
            }

            return View(conta_Bancaria);
        }

        // POST: Conta_Bancaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conta_Bancaria == null)
            {
                return Problem("Entity set 'Contexto.Conta_Bancaria'  is null.");
            }
            var conta_Bancaria = await _context.Conta_Bancaria.FindAsync(id);
            if (conta_Bancaria != null)
            {
                _context.Conta_Bancaria.Remove(conta_Bancaria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Conta_BancariaExists(int id)
        {
          return _context.Conta_Bancaria.Any(e => e.id == id);
        }
    }
}
