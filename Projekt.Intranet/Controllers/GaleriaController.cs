using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt.Intranet.Data;
using Projekt.Intranet.Models.CMS;

namespace Projekt.Intranet.Controllers
{
    public class GaleriaController : Controller
    {
        private readonly ProjektIntranetContext _context;

        public GaleriaController(ProjektIntranetContext context)
        {
            _context = context;
        }

        // GET: Galeria
        public async Task<IActionResult> Index()
        {
            var projektIntranetContext = _context.Galeria.Include(g => g.TattoArtists);
            return View(await projektIntranetContext.ToListAsync());
        }

        // GET: Galeria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galeria = await _context.Galeria
                .Include(g => g.TattoArtists)
                .FirstOrDefaultAsync(m => m.IdGaleria == id);
            if (galeria == null)
            {
                return NotFound();
            }

            return View(galeria);
        }

        // GET: Galeria/Create
        public IActionResult Create()
        {
            ViewData["IdTattoArtists"] = new SelectList(_context.TattoArtists, "IdTattoArtists", "Przydomek");
            return View();
        }

        // POST: Galeria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGaleria,IdTattoArtists,UrlZdjecia")] Galeria galeria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(galeria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTattoArtists"] = new SelectList(_context.TattoArtists, "IdTattoArtists", "Przydomek", galeria.IdTattoArtists);
            return View(galeria);
        }

        // GET: Galeria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galeria = await _context.Galeria.FindAsync(id);
            if (galeria == null)
            {
                return NotFound();
            }
            ViewData["IdTattoArtists"] = new SelectList(_context.TattoArtists, "IdTattoArtists", "Przydomek", galeria.IdTattoArtists);
            return View(galeria);
        }

        // POST: Galeria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGaleria,IdTattoArtists,UrlZdjecia")] Galeria galeria)
        {
            if (id != galeria.IdGaleria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(galeria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GaleriaExists(galeria.IdGaleria))
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
            ViewData["IdTattoArtists"] = new SelectList(_context.TattoArtists, "IdTattoArtists", "Przydomek", galeria.IdTattoArtists);
            return View(galeria);
        }

        // GET: Galeria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galeria = await _context.Galeria
                .Include(g => g.TattoArtists)
                .FirstOrDefaultAsync(m => m.IdGaleria == id);
            if (galeria == null)
            {
                return NotFound();
            }

            return View(galeria);
        }

        // POST: Galeria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var galeria = await _context.Galeria.FindAsync(id);
            if (galeria != null)
            {
                _context.Galeria.Remove(galeria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GaleriaExists(int id)
        {
            return _context.Galeria.Any(e => e.IdGaleria == id);
        }
    }
}
