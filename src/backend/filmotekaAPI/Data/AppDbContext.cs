using filmotekaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace filmotekaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Film> Filmovi { get; set; }
        public DbSet<Zanr> Zanrovi { get; set; }
        public DbSet<Reziser> Reziseri { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Film>()
                .HasOne(f => f.Zanr)
                .WithMany(z => z.Filmovi)
                .HasForeignKey(f => f.ZanrId);

            _ = modelBuilder.Entity<Film>()
                .HasOne(f => f.Zanr)
                .WithMany(z => z.Filmovi)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
