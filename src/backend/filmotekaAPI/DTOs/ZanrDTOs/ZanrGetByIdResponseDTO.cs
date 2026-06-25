using filmotekaAPI.Models;

namespace filmotekaAPI.DTOs.ZanrDTOs
{
    public class ZanrGetByIdResponseDTO : BaseResponseDTO
    {
        public Zanr? Zanr { get; init; }

        public static ZanrGetByIdResponseDTO Ok(Zanr zanr, string message)
        {
            return new()
            {
                Message = message,
                Success = true,
                Zanr = zanr
            };
        }

        public static new ZanrGetByIdResponseDTO Error(string message)
        {
            return new()
            {
                Message = message,
                Success = false,
                Zanr = null
            };
        }
    }
}
