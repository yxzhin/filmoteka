using System.ComponentModel.DataAnnotations;

namespace filmotekaAPI.DTOs.ReziserDTOs
{
    public class ReziserUpdateInputDTO
    {
        [Required]
        public required int Id { get; init; }

        [MaxLength(73)]
        public string? NewName { get; init; }

        public int? NewAge { get; init; }
    }
}
