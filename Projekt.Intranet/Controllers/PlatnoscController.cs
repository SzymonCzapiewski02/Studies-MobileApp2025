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
    public class PlatnoscController : Controller
    {
        private readonly ProjektIntranetContext _context;

        public PlatnoscController(ProjektIntranetContext context)
        {
            _context = context;
        }

        // GET: Platnosc
        public async Task<IActionResult> Index()
        {
            var projektIntranetContext = _context.Platnosc.Include(p => p.Rezerwacja);
            return View(await projektIntranetContext.ToListAsync());
        }

        // GET: Platnosc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platnosc = await _context.Platnosc
                .Include(p => p.Rezerwacja)
                .FirstOrDefaultAsync(m => m.IdPlatnosc == id);
            if (platnosc == null)
            {
                return NotFound();
            }

            return View(platnosc);
        }

        // GET: Platnosc/Create
        public IActionResult Create()
        {
            ViewData["IdRezerwacja"] = new SelectList(_context.Rezerwacje, "IdRezerwacja", "IdRezerwacja");
            return View();
        }

        // POST: Platnosc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPlatnosc,IdRezerwacja,Kwota,Data,MetodaPlatnosci")] Platnosc platnosc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(platnosc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRezerwacja"] = new SelectList(_context.Rezerwacje, "IdRezerwacja", "IdRezerwacja", platnosc.IdRezerwacja);
            return View(platnosc);
        }

        // GET: Platnosc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platnosc = await _context.Platnosc.FindAsync(id);
            if (platnosc == null)
            {
                return NotFound();
            }
            ViewData["IdRezerwacja"] = new SelectList(_context.Rezerwacje, "IdRezerwacja", "IdRezerwacja", platnosc.IdRezerwacja);
            return View(platnosc);
        }

        // POST: Platnosc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPlatnosc,IdRezerwacja,Kwota,Data,MetodaPlatnosci")] Platnosc platnosc)
        {
            if (id != platnosc.IdPlatnosc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(platnosc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatnoscExists(platnosc.IdPlatnosc))
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
            ViewData["IdRezerwacja"] = new SelectList(_context.Rezerwacje, "IdRezerwacja", "IdRezerwacja", platnosc.IdRezerwacja);
            return View(platnosc);
        }

        // GET: Platnosc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platnosc = await _context.Platnosc
                .Include(p => p.Rezerwacja)
                .FirstOrDefaultAsync(m => m.IdPlatnosc == id);
            if (platnosc == null)
            {
                return NotFound();
            }

            return View(platnosc);
        }

        // POST: Platnosc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var platnosc = await _context.Platnosc.FindAsync(id);
            if (platnosc != null)
            {
                _context.Platnosc.Remove(platnosc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlatnoscExists(int id)
        {
            return _context.Platnosc.Any(e => e.IdPlatnosc == id);
        }
    }
}
