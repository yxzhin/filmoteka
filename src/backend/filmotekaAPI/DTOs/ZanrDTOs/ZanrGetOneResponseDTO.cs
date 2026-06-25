using filmotekaAPI.Models;

namespace filmotekaAPI.DTOs.ZanrDTOs
{
    public class ZanrGetOneResponseDTO : BaseResponseDTO
    {
        public Zanr? Zanr { get; init; }

        public static ZanrGetOneResponseDTO Ok(Zanr zanr, string message)
        {
            return new()
            {
                Message = message,
                Success = true,
                Zanr = zanr
            };
        }

        public static new ZanrGetOneResponseDTO Error(string message)
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
