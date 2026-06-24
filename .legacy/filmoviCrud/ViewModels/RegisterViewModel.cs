using System.ComponentModel.DataAnnotations;

namespace filmoviCrud.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Ime { get; set; } = "";

        [Required]
        public string Prezime { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
    }
}
