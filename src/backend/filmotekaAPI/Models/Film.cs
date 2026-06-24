using System.ComponentModel.DataAnnotations;

namespace filmotekaAPI.Models
{
    public class Film
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(73)]
        public required string Naziv { get; set; }

        [Required]
        public required int ZanrId { get; set; }

        [Required]
        public required Zanr Zanr { get; set; }

        [Required]
        public required ICollection<Reziser> Reziseri { get; set; }

        [Required]
        public required int GodinaIzdanja { get; set; }
    }
}
