using System.ComponentModel.DataAnnotations;

namespace filmotekaAPI.Models
{
    public class Zanr
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(73)]
        public required string Naziv { get; set; }

        [Required]
        public ICollection<Film> Filmovi { get; set; } = [];
    }
}
