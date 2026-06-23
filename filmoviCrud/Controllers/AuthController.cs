using filmoviCrud.Data;
using filmoviCrud.Models;
using filmoviCrud.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace filmoviCrud.Controllers;

public class AuthController : Controller
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        bool postoji = await _context.Korisnici
            .AnyAsync(x => x.Email == model.Email);

        if (postoji)
        {
            ModelState.AddModelError("", "Email vec postoji.");
            return View(model);
        }

        Korisnik korisnik = new()
        {
            Ime = model.Ime,
            Prezime = model.Prezime,
            Email = model.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
            Uloga = Uloga.user
        };

        _ = _context.Korisnici.Add(korisnik);
        _ = await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Login));
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        Korisnik? korisnik = await _context.Korisnici
            .FirstOrDefaultAsync(x => x.Email == model.Email);

        if (korisnik == null ||
            !BCrypt.Net.BCrypt.Verify(model.Password, korisnik.Password))
        {
            ModelState.AddModelError("", "Pogresan email ili lozinka.");
            return View(model);
        }

        List<Claim> claims =
        [
            new(ClaimTypes.NameIdentifier, korisnik.Id.ToString()),
            new(ClaimTypes.Name, korisnik.PunoIme),
            new(ClaimTypes.Email, korisnik.Email),
            new(ClaimTypes.Role, korisnik.Uloga.ToString())
        ];

        ClaimsIdentity identity = new(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity));

        return RedirectToAction("Index", "Film");
    }

    [HttpGet]
    public IActionResult Me()
    {
        return !User.Identity!.IsAuthenticated
            ? Unauthorized()
            : Json(new
            {
                Id = User.FindFirstValue(ClaimTypes.NameIdentifier),
                Ime = User.Identity.Name,
                Email = User.FindFirstValue(ClaimTypes.Email),
                Uloga = User.FindFirstValue(ClaimTypes.Role)
            });
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction(nameof(Login));
    }
}