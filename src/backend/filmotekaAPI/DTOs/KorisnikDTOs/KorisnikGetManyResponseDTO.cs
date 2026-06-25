using filmotekaAPI.Models;

namespace filmotekaAPI.DTOs.KorisnikDTOs
{
    public class KorisnikGetManyResponseDTO : BaseResponseDTO
    {
        public required List<Korisnik> Korisnici { get; init; }

        public static KorisnikGetManyResponseDTO Ok(List<Korisnik> korisnici, string message)
        {
            return new()
            {
                Message = message,
                Success = true,
                Korisnici = korisnici
            };
        }
    }
}
