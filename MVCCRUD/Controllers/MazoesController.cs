using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCRUD.Models;

namespace MVCCRUD.Controllers
{
    public class MazoesController : Controller
    {
        private readonly MvccrudContext _context;

        public MazoesController(MvccrudContext context)
        {
            _context = context;
        }

        // GET: Mazoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mazos.ToListAsync());
        }

        // GET: Mazoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mazo = await _context.Mazos
                .FirstOrDefaultAsync(m => m.IdMazo == id);
            if (mazo == null)
            {
                return NotFound();
            }

            return View(mazo);
        }

        // GET: Mazoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mazoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMazo,MazoNombre")] Mazo mazo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mazo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mazo);
        }

        // GET: Mazoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mazo = await _context.Mazos.FindAsync(id);
            if (mazo == null)
            {
                return NotFound();
            }
            return View(mazo);
        }

        // POST: Mazoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMazo,MazoNombre")] Mazo mazo)
        {
            if (id != mazo.IdMazo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mazo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MazoExists(mazo.IdMazo))
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
            return View(mazo);
        }

        // GET: Mazoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mazo = await _context.Mazos
                .FirstOrDefaultAsync(m => m.IdMazo == id);
            if (mazo == null)
            {
                return NotFound();
            }

            return View(mazo);
        }

        // POST: Mazoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mazo = await _context.Mazos.FindAsync(id);
            if (mazo != null)
            {
                _context.Mazos.Remove(mazo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MazoExists(int id)
        {
            return _context.Mazos.Any(e => e.IdMazo == id);
        }
    }
}
