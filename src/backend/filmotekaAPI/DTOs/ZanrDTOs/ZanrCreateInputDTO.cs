using System.ComponentModel.DataAnnotations;

namespace filmotekaAPI.DTOs.ZanrDTOs
{
    public class ZanrCreateInputDTO
    {
        [Required]
        [MaxLength(73)]
        public required string Name { get; init; }
    }
}
