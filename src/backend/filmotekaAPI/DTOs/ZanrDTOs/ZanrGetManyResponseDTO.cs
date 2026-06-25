using filmotekaAPI.Models;

namespace filmotekaAPI.DTOs.ZanrDTOs
{
    public class ZanrGetManyResponseDTO : BaseResponseDTO
    {
        public required List<Zanr> Zanrovi { get; init; }

        public static ZanrGetManyResponseDTO Ok(List<Zanr> zanrovi, string message)
        {
            return new()
            {
                Message = message,
                Success = true,
                Zanrovi = zanrovi
            };
        }
    }
}
