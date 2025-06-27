using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalDW.Data;
using ProyectoFinalDW.Models;

namespace ProyectoFinalDW.Controllers
{
    public class PeseController : Controller
    {
        private readonly ReseñasDbContext _context;

        public PeseController(ReseñasDbContext context)
        {
            _context = context;
        }

        // GET: Pese
        public async Task<IActionResult> Index()
        {
            var reseñasDbContext = _context.Peses;
            return View(await reseñasDbContext.ToListAsync());
        }

        // GET: Pese/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pese = await _context.Peses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pese == null)
            {
                return NotFound();
            }

            return View(pese);
        }

        // GET: Pese/Create
        public IActionResult Create()
        {
          
            return View();
        }

        // POST: Pese/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Genero,Año,AutorId")] Pese pese)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pese);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(pese);
        }

        // GET: Pese/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pese = await _context.Peses.FindAsync(id);
            if (pese == null)
            {
                return NotFound();
            }
          
            return View(pese);
        }

        // POST: Pese/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Genero,Año,AutorId")] Pese pese)
        {
            if (id != pese.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pese);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeseExists(pese.Id))
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
            
            return View(pese);
        }

        // GET: Pese/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pese = await _context.Peses
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pese == null)
            {
                return NotFound();
            }

            return View(pese);
        }

        // POST: Pese/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pese = await _context.Peses.FindAsync(id);
            if (pese != null)
            {
                _context.Peses.Remove(pese);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeseExists(int id)
        {
            return _context.Peses.Any(e => e.Id == id);
        }
    }
}
