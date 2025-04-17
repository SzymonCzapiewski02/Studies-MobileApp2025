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
    public class RezerwacjeController : Controller
    {
        private readonly ProjektIntranetContext _context;

        public RezerwacjeController(ProjektIntranetContext context)
        {
            _context = context;
        }

        // GET: Rezerwacje
        public async Task<IActionResult> Index()
        {
            var projektIntranetContext = _context.Rezerwacje.Include(r => r.Klient).Include(r => r.TattoArtists);
            return View(await projektIntranetContext.ToListAsync());
        }

        // GET: Rezerwacje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacje = await _context.Rezerwacje
                .Include(r => r.Klient)
                .Include(r => r.TattoArtists)
                .FirstOrDefaultAsync(m => m.IdRezerwacja == id);
            if (rezerwacje == null)
            {
                return NotFound();
            }

            return View(rezerwacje);
        }

        // GET: Rezerwacje/Create
        public IActionResult Create()
        {
            ViewData["IdKlient"] = new SelectList(_context.Klient, "IdKlient", "Email");
            ViewData["IdTattoArtists"] = new SelectList(_context.TattoArtists, "IdTattoArtists", "Przydomek");
            return View();
        }

        // POST: Rezerwacje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRezerwacja,IdKlient,IdTattoArtists,Data,Godzina,Uwagi")] Rezerwacje rezerwacje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezerwacje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKlient"] = new SelectList(_context.Klient, "IdKlient", "Email", rezerwacje.IdKlient);
            ViewData["IdTattoArtists"] = new SelectList(_context.TattoArtists, "IdTattoArtists", "Przydomek", rezerwacje.IdTattoArtists);
            return View(rezerwacje);
        }

        // GET: Rezerwacje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacje = await _context.Rezerwacje.FindAsync(id);
            if (rezerwacje == null)
            {
                return NotFound();
            }
            ViewData["IdKlient"] = new SelectList(_context.Klient, "IdKlient", "Email", rezerwacje.IdKlient);
            ViewData["IdTattoArtists"] = new SelectList(_context.TattoArtists, "IdTattoArtists", "Przydomek", rezerwacje.IdTattoArtists);
            return View(rezerwacje);
        }

        // POST: Rezerwacje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRezerwacja,IdKlient,IdTattoArtists,Data,Godzina,Uwagi")] Rezerwacje rezerwacje)
        {
            if (id != rezerwacje.IdRezerwacja)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezerwacje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezerwacjeExists(rezerwacje.IdRezerwacja))
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
            ViewData["IdKlient"] = new SelectList(_context.Klient, "IdKlient", "Email", rezerwacje.IdKlient);
            ViewData["IdTattoArtists"] = new SelectList(_context.TattoArtists, "IdTattoArtists", "Przydomek", rezerwacje.IdTattoArtists);
            return View(rezerwacje);
        }

        // GET: Rezerwacje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacje = await _context.Rezerwacje
                .Include(r => r.Klient)
                .Include(r => r.TattoArtists)
                .FirstOrDefaultAsync(m => m.IdRezerwacja == id);
            if (rezerwacje == null)
            {
                return NotFound();
            }

            return View(rezerwacje);
        }

        // POST: Rezerwacje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezerwacje = await _context.Rezerwacje.FindAsync(id);
            if (rezerwacje != null)
            {
                _context.Rezerwacje.Remove(rezerwacje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezerwacjeExists(int id)
        {
            return _context.Rezerwacje.Any(e => e.IdRezerwacja == id);
        }
    }
}
