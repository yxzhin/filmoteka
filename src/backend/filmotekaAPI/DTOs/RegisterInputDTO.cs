using System.ComponentModel.DataAnnotations;

namespace filmotekaAPI.DTOs
{
    public class RegisterInputDTO
    {
        [Required]
        [MaxLength(73)]
        public required string Ime { get; set; }

        [Required]
        [MaxLength(73)]
        public required string Prezime { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(73)]
        public required string Password { get; set; }
    }
}
