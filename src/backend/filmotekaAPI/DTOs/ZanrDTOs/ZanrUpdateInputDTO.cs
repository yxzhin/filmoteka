using System.ComponentModel.DataAnnotations;

namespace filmotekaAPI.DTOs.ZanrDTOs
{
    public class ZanrUpdateInputDTO
    {
        [Required]
        public required int Id { get; init; }

        [Required]
        [MaxLength(73)]
        public required string NewName { get; init; }
    }
}
