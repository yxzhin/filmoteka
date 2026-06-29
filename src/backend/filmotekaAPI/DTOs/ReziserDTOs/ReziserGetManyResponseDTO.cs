using filmotekaAPI.Models;

namespace filmotekaAPI.DTOs.ReziserDTOs
{
    public class ReziserGetManyResponseDTO : BaseResponseDTO
    {
        public required List<Reziser> Reziseri { get; init; }

        public static ReziserGetManyResponseDTO Ok(List<Reziser> reziseri, string message)
        {
            return new()
            {
                Message = message,
                Success = true,
                Reziseri = reziseri
            };
        }
    }
}
