using System.ComponentModel.DataAnnotations;

namespace filmotekaAPI.DTOs.ReziserDTOs
{
    public class ReziserCreateInputDTO
    {
        [Required]
        [MaxLength(73)]
        public required string Name { get; init; }

        [Required]
        public required int Age { get; init; }
    }
}
