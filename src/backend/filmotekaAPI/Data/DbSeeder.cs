using filmotekaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace filmotekaAPI.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (await context.Filmovi.AnyAsync())
            {
                return;
            }

            Zanr akcija = new() { Naziv = "Akcija" };
            Zanr drama = new() { Naziv = "Drama" };
            Zanr komedija = new() { Naziv = "Komedija" };

            context.Zanrovi.AddRange(
                akcija,
                drama,
                komedija
            );

            Reziser nolan = new()
            {
                Naziv = "Christopher Nolan",
                Uzrast = 55
            };

            Reziser spielberg = new()
            {
                Naziv = "Steven Spielberg",
                Uzrast = 79
            };

            Reziser tarantino = new()
            {
                Naziv = "Quentin Tarantino",
                Uzrast = 63
            };

            context.Reziseri.AddRange(
                nolan,
                spielberg,
                tarantino
            );

            _ = await context.SaveChangesAsync();

            List<Film> filmovi =
            [
            new()
            {
                Naziv = "Inception",
                GodinaIzdanja = 2010,
                Zanr = akcija,
                ZanrId = akcija.Id,
                Reziseri =
                [
                    nolan
                ]
            },

            new()
            {
                Naziv = "Interstellar",
                GodinaIzdanja = 2014,
                Zanr = drama,
                ZanrId = drama.Id,
                Reziseri =
                [
                    nolan
                ]
            },

            new()
            {
                Naziv = "Jurassic Park",
                GodinaIzdanja = 1993,
                Zanr = akcija,
                ZanrId = akcija.Id,
                Reziseri =
                [
                    spielberg
                ]
            },

            new()
            {
                Naziv = "Pulp Fiction",
                GodinaIzdanja = 1994,
                Zanr = drama,
                ZanrId = drama.Id,
                Reziseri =
                [
                    tarantino
                ]
            },

            new()
            {
                Naziv = "Django Unchained",
                GodinaIzdanja = 2012,
                Zanr = drama,
                ZanrId = drama.Id,
                Reziseri =
                [
                    tarantino
                ]
            }
        ];

            context.Filmovi.AddRange(filmovi);

            _ = await context.SaveChangesAsync();
        }
    }
}
