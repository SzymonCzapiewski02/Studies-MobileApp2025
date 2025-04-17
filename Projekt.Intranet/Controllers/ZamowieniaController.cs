using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt.Intranet.Data;
using Projekt.Intranet.Models.Sklep;

namespace Projekt.Intranet.Controllers
{
    public class ZamowieniaController : Controller
    {
        private readonly ProjektIntranetContext _context;

        public ZamowieniaController(ProjektIntranetContext context)
        {
            _context = context;
        }

        // GET: Zamowienia
        public async Task<IActionResult> Index()
        {
            var projektIntranetContext = _context.Zamowienia.Include(z => z.Klient).Include(z => z.Produkt);
            return View(await projektIntranetContext.ToListAsync());
        }

        // GET: Zamowienia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienia = await _context.Zamowienia
                .Include(z => z.Klient)
                .Include(z => z.Produkt)
                .FirstOrDefaultAsync(m => m.IdZamowienia == id);
            if (zamowienia == null)
            {
                return NotFound();
            }

            return View(zamowienia);
        }

        // GET: Zamowienia/Create
        public IActionResult Create()
        {
            ViewData["IdKlient"] = new SelectList(_context.Klient, "IdKlient", "Email");
            ViewData["IdProduktu"] = new SelectList(_context.Produkt, "IdProdukt", "Nazwa");
            return View();
        }

        // POST: Zamowienia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZamowienia,IdKlient,IdProduktu")] Zamowienia zamowienia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zamowienia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKlient"] = new SelectList(_context.Klient, "IdKlient", "Email", zamowienia.IdKlient);
            ViewData["IdProduktu"] = new SelectList(_context.Produkt, "IdProdukt", "Nazwa", zamowienia.IdProduktu);
            return View(zamowienia);
        }

        // GET: Zamowienia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienia = await _context.Zamowienia.FindAsync(id);
            if (zamowienia == null)
            {
                return NotFound();
            }
            ViewData["IdKlient"] = new SelectList(_context.Klient, "IdKlient", "Email", zamowienia.IdKlient);
            ViewData["IdProduktu"] = new SelectList(_context.Produkt, "IdProdukt", "Nazwa", zamowienia.IdProduktu);
            return View(zamowienia);
        }

        // POST: Zamowienia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZamowienia,IdKlient,IdProduktu")] Zamowienia zamowienia)
        {
            if (id != zamowienia.IdZamowienia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamowienia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamowieniaExists(zamowienia.IdZamowienia))
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
            ViewData["IdKlient"] = new SelectList(_context.Klient, "IdKlient", "Email", zamowienia.IdKlient);
            ViewData["IdProduktu"] = new SelectList(_context.Produkt, "IdProdukt", "Nazwa", zamowienia.IdProduktu);
            return View(zamowienia);
        }

        // GET: Zamowienia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienia = await _context.Zamowienia
                .Include(z => z.Klient)
                .Include(z => z.Produkt)
                .FirstOrDefaultAsync(m => m.IdZamowienia == id);
            if (zamowienia == null)
            {
                return NotFound();
            }

            return View(zamowienia);
        }

        // POST: Zamowienia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zamowienia = await _context.Zamowienia.FindAsync(id);
            if (zamowienia != null)
            {
                _context.Zamowienia.Remove(zamowienia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZamowieniaExists(int id)
        {
            return _context.Zamowienia.Any(e => e.IdZamowienia == id);
        }
    }
}
