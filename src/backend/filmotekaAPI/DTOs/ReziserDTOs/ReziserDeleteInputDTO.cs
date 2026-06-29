using System.ComponentModel.DataAnnotations;

namespace filmotekaAPI.DTOs.ReziserDTOs
{
    public class ReziserDeleteInputDTO
    {
        [Required]
        public required int Id { get; init; }
    }
}
