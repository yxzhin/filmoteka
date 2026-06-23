using filmoviCrud.Data;
using filmoviCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace filmoviCrud.Controllers
{

    public class FilmController : Controller
    {
        private readonly AppDbContext _context;

        public FilmController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 10;

            var totalItems = await _context.Filmovi.CountAsync();

            var filmovi = await _context.Filmovi
                .Include(f => f.Zanr)
                .Include(f => f.Reziseri)
                .OrderBy(f => f.Naziv)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            return View(filmovi);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var film = await _context.Filmovi
                .Include(f => f.Zanr)
                .Include(f => f.Reziseri)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (film == null) return NotFound();

            return View(film);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Zanrovi = new SelectList(await _context.Zanrovi.ToListAsync(), "Id", "Naziv");
            ViewBag.Reziseri = new MultiSelectList(await _context.Reziseri.ToListAsync(), "Id", "Naziv");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FilmFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Zanrovi = new SelectList(await _context.Zanrovi.ToListAsync(), "Id", "Naziv", model.ZanrId);
                ViewBag.Reziseri = new MultiSelectList(await _context.Reziseri.ToListAsync(), "Id", "Naziv", model.ReziserIds);
                return View(model);
            }

            Zanr zanr = await _context.Zanrovi.FirstAsync(z => z.Id == model.ZanrId);

            var film = new Film
            {
                Naziv = model.Naziv,
                ZanrId = model.ZanrId,
                Zanr = zanr,
                GodinaIzdanja = model.GodinaIzdanja,
                Reziseri = new List<Reziser>()
            };

            if (model.ReziserIds.Any())
            {
                film.Reziseri = await _context.Reziseri
                    .Where(r => model.ReziserIds.Contains(r.Id))
                    .ToListAsync();
            }

            _context.Filmovi.Add(film);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var film = await _context.Filmovi
                .Include(f => f.Reziseri)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (film == null) return NotFound();

            var model = new FilmFormViewModel
            {
                Id = film.Id,
                Naziv = film.Naziv,
                ZanrId = film.ZanrId,
                GodinaIzdanja = film.GodinaIzdanja,
                ReziserIds = film.Reziseri.Select(r => r.Id).ToList()
            };

            ViewBag.Zanrovi = new SelectList(await _context.Zanrovi.ToListAsync(), "Id", "Naziv", model.ZanrId);
            ViewBag.Reziseri = new MultiSelectList(await _context.Reziseri.ToListAsync(), "Id", "Naziv", model.ReziserIds);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FilmFormViewModel model)
        {
            if (id != model.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.Zanrovi = new SelectList(await _context.Zanrovi.ToListAsync(), "Id", "Naziv", model.ZanrId);
                ViewBag.Reziseri = new MultiSelectList(await _context.Reziseri.ToListAsync(), "Id", "Naziv", model.ReziserIds);
                return View(model);
            }

            var film = await _context.Filmovi
                .Include(f => f.Reziseri)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (film == null) return NotFound();

            film.Naziv = model.Naziv;
            film.ZanrId = model.ZanrId;
            film.GodinaIzdanja = model.GodinaIzdanja;

            film.Reziseri.Clear();

            var noviReziseri = await _context.Reziseri
                .Where(r => model.ReziserIds.Contains(r.Id))
                .ToListAsync();

            foreach (var reziser in noviReziseri)
            {
                film.Reziseri.Add(reziser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var film = await _context.Filmovi
                .Include(f => f.Zanr)
                .Include(f => f.Reziseri)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (film == null) return NotFound();

            return View(film);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _context.Filmovi.FindAsync(id);
            if (film != null)
            {
                _context.Filmovi.Remove(film);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
