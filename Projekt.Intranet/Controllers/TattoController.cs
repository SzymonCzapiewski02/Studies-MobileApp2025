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
    public class TattoController : Controller
    {
        private readonly ProjektIntranetContext _context;

        public TattoController(ProjektIntranetContext context)
        {
            _context = context;
        }

        // GET: Tatto
        public async Task<IActionResult> Index()
        {
            var projektIntranetContext = _context.Tatto.Include(t => t.Klient).Include(t => t.TattoArtists);
            return View(await projektIntranetContext.ToListAsync());
        }

        // GET: Tatto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatto = await _context.Tatto
                .Include(t => t.Klient)
                .Include(t => t.TattoArtists)
                .FirstOrDefaultAsync(m => m.IdTattoo == id);
            if (tatto == null)
            {
                return NotFound();
            }

            return View(tatto);
        }

        // GET: Tatto/Create
        public IActionResult Create()
        {
            ViewData["IdKlient"] = new SelectList(_context.Klient, "IdKlient", "Email");
            ViewData["IdTattoArtists"] = new SelectList(_context.TattoArtists, "IdTattoArtists", "Przydomek");
            return View();
        }

        // POST: Tatto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTattoo,IdKlient,IdTattoArtists,Styl,Data,Cena")] Tatto tatto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tatto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKlient"] = new SelectList(_context.Klient, "IdKlient", "Email", tatto.IdKlient);
            ViewData["IdTattoArtists"] = new SelectList(_context.TattoArtists, "IdTattoArtists", "Przydomek", tatto.IdTattoArtists);
            return View(tatto);
        }

        // GET: Tatto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatto = await _context.Tatto.FindAsync(id);
            if (tatto == null)
            {
                return NotFound();
            }
            ViewData["IdKlient"] = new SelectList(_context.Klient, "IdKlient", "Email", tatto.IdKlient);
            ViewData["IdTattoArtists"] = new SelectList(_context.TattoArtists, "IdTattoArtists", "Przydomek", tatto.IdTattoArtists);
            return View(tatto);
        }

        // POST: Tatto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTattoo,IdKlient,IdTattoArtists,Styl,Data,Cena")] Tatto tatto)
        {
            if (id != tatto.IdTattoo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tatto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TattoExists(tatto.IdTattoo))
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
            ViewData["IdKlient"] = new SelectList(_context.Klient, "IdKlient", "Email", tatto.IdKlient);
            ViewData["IdTattoArtists"] = new SelectList(_context.TattoArtists, "IdTattoArtists", "Przydomek", tatto.IdTattoArtists);
            return View(tatto);
        }

        // GET: Tatto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatto = await _context.Tatto
                .Include(t => t.Klient)
                .Include(t => t.TattoArtists)
                .FirstOrDefaultAsync(m => m.IdTattoo == id);
            if (tatto == null)
            {
                return NotFound();
            }

            return View(tatto);
        }

        // POST: Tatto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tatto = await _context.Tatto.FindAsync(id);
            if (tatto != null)
            {
                _context.Tatto.Remove(tatto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TattoExists(int id)
        {
            return _context.Tatto.Any(e => e.IdTattoo == id);
        }
    }
}
