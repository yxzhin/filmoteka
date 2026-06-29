using filmotekaAPI.Models;

namespace filmotekaAPI.DTOs.ReziserDTOs
{
    public class ReziserGetOneResponseDTO : BaseResponseDTO
    {
        public Reziser? Reziser { get; init; }

        public static ReziserGetOneResponseDTO Ok(Reziser reziser, string message)
        {
            return new()
            {
                Message = message,
                Success = true,
                Reziser = reziser
            };
        }

        public static new ReziserGetOneResponseDTO Error(string message)
        {
            return new()
            {
                Message = message,
                Success = false,
                Reziser = null
            };
        }
    }
}
