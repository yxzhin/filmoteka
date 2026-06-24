using filmotekaAPI.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace filmotekaAPI.Models
{
    public class Zanr : IEntity
    {
        [Required]
        public int Id { get; init; }

        [Required]
        [MaxLength(73)]
        public required string Naziv { get; set; }

        [Required]
        public ICollection<Film> Filmovi { get; set; } = [];
    }
}
