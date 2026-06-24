using filmotekaAPI.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace filmotekaAPI.Models
{
    public class Korisnik : IEntity
    {
        [Required]
        public int Id { get; init; }

        [Required]
        [MaxLength(73)]
        public required string Ime { get; set; }

        [Required]
        [MaxLength(73)]
        public required string Prezime { get; set; }

        public string PunoIme => $"{Ime} {Prezime}";

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(73)]
        public required string Password { get; set; }

        [Required]
        public required Uloga Uloga { get; set; }
    }

    public enum Uloga
    {
        user,
        admin,
    }
}
