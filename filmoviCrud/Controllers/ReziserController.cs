using filmoviCrud.Data;
using filmoviCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace filmoviCrud.Controllers
{

    public class ReziserController : Controller
    {
        private readonly AppDbContext _context;

        public ReziserController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Reziseri.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var reziser = await _context.Reziseri
                .FirstOrDefaultAsync(m => m.Id == id);

            if (reziser == null) return NotFound();

            return View(reziser);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Uzrast")] Reziser reziser)
        {
            if (!ModelState.IsValid) return View(reziser);

            _context.Add(reziser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var reziser = await _context.Reziseri.FindAsync(id);
            if (reziser == null) return NotFound();

            return View(reziser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Uzrast")] Reziser reziser)
        {
            if (id != reziser.Id) return NotFound();

            if (!ModelState.IsValid) return View(reziser);

            try
            {
                _context.Update(reziser);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ReziserExists(reziser.Id)) return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var reziser = await _context.Reziseri
                .FirstOrDefaultAsync(m => m.Id == id);

            if (reziser == null) return NotFound();

            return View(reziser);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reziser = await _context.Reziseri.FindAsync(id);
            if (reziser != null)
            {
                _context.Reziseri.Remove(reziser);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ReziserExists(int id)
        {
            return await _context.Reziseri.AnyAsync(e => e.Id == id);
        }
    }
}
