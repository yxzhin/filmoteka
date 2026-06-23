using filmoviCrud.Data;
using filmoviCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace filmoviCrud.Controllers
{
    public class ZanrController : Controller
    {
        private readonly AppDbContext _context;

        public ZanrController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Zanrovi.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var zanr = await _context.Zanrovi
                .FirstOrDefaultAsync(m => m.Id == id);

            if (zanr == null) return NotFound();

            return View(zanr);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv")] Zanr zanr)
        {
            if (!ModelState.IsValid) return View(zanr);

            _context.Add(zanr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var zanr = await _context.Zanrovi.FindAsync(id);
            if (zanr == null) return NotFound();

            return View(zanr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv")] Zanr zanr)
        {
            if (id != zanr.Id) return NotFound();

            if (!ModelState.IsValid) return View(zanr);

            try
            {
                _context.Update(zanr);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ZanrExists(zanr.Id)) return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var zanr = await _context.Zanrovi
                .FirstOrDefaultAsync(m => m.Id == id);

            if (zanr == null) return NotFound();

            return View(zanr);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zanr = await _context.Zanrovi.FindAsync(id);
            if (zanr != null)
            {
                _context.Zanrovi.Remove(zanr);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ZanrExists(int id)
        {
            return await _context.Zanrovi.AnyAsync(e => e.Id == id);
        }
    }
}
