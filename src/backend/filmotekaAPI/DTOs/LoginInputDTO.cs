using System.ComponentModel.DataAnnotations;

namespace filmotekaAPI.DTOs
{
    public class LoginInputDTO
    {
        [Required]
        [EmailAddress]
        public required string Email { get; init; }

        [Required]
        public required string Password { get; init; }
    }
}
