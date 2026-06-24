using filmotekaAPI.Models;

namespace filmotekaAPI.DTOs
{
    public class KorisnikServiceGetManyDTO : BaseResponseDTO
    {
        public required List<Korisnik> Korisnici { get; init; }

        public static KorisnikServiceGetManyDTO Ok(List<Korisnik> korisnici, string message)
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
