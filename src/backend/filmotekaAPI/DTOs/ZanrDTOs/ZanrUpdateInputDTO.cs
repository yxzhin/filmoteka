using System.ComponentModel.DataAnnotations;

namespace filmotekaAPI.DTOs.ZanrDTOs
{
    public class ZanrUpdateInputDTO
    {
        [Required]
        public required string OldName { get; init; }

        [Required]
        [MaxLength(73)]
        public required string NewName { get; init; }
    }
}
