using filmoviCrud.Data;
using filmoviCrud.Models;
using filmoviCrud.ViewModels;
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

            int totalItems = await _context.Filmovi.CountAsync();

            FilmIndexViewModel model = new()
            {
                Filmovi = await _context.Filmovi
                    .Include(f => f.Zanr)
                    .Include(f => f.Reziseri)
                    .OrderBy(f => f.Naziv)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(),

                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
            };

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Film? film = await _context.Filmovi
                .Include(f => f.Zanr)
                .Include(f => f.Reziseri)
                .FirstOrDefaultAsync(m => m.Id == id);

            return film == null ? NotFound() : View(film);
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

            Film film = new()
            {
                Naziv = model.Naziv,
                ZanrId = model.ZanrId,
                Zanr = zanr,
                GodinaIzdanja = model.GodinaIzdanja,
                Reziseri = []
            };

            if (model.ReziserIds.Any())
            {
                film.Reziseri = await _context.Reziseri
                    .Where(r => model.ReziserIds.Contains(r.Id))
                    .ToListAsync();
            }

            _ = _context.Filmovi.Add(film);
            _ = await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Film? film = await _context.Filmovi
                .Include(f => f.Reziseri)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (film == null)
            {
                return NotFound();
            }

            FilmFormViewModel model = new()
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
            if (id != model.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Zanrovi = new SelectList(await _context.Zanrovi.ToListAsync(), "Id", "Naziv", model.ZanrId);
                ViewBag.Reziseri = new MultiSelectList(await _context.Reziseri.ToListAsync(), "Id", "Naziv", model.ReziserIds);
                return View(model);
            }

            Film? film = await _context.Filmovi
                .Include(f => f.Reziseri)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (film == null)
            {
                return NotFound();
            }

            film.Naziv = model.Naziv;
            film.ZanrId = model.ZanrId;
            film.GodinaIzdanja = model.GodinaIzdanja;

            film.Reziseri.Clear();

            List<Reziser> noviReziseri = await _context.Reziseri
                .Where(r => model.ReziserIds.Contains(r.Id))
                .ToListAsync();

            foreach (Reziser? reziser in noviReziseri)
            {
                film.Reziseri.Add(reziser);
            }

            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Film? film = await _context.Filmovi
                .Include(f => f.Zanr)
                .Include(f => f.Reziseri)
                .FirstOrDefaultAsync(m => m.Id == id);

            return film == null ? NotFound() : View(film);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Film? film = await _context.Filmovi.FindAsync(id);
            if (film != null)
            {
                _ = _context.Filmovi.Remove(film);
                _ = await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
