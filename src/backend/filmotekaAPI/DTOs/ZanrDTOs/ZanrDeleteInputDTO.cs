using System.ComponentModel.DataAnnotations;

namespace filmotekaAPI.DTOs.ZanrDTOs
{
    public class ZanrDeleteInputDTO
    {
        [Required]
        public required int Id { get; init; }
    }
}
