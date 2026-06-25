using System.ComponentModel.DataAnnotations;

namespace filmotekaAPI.DTOs.AuthDTOs
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
