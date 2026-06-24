using filmotekaAPI.Models;

namespace filmotekaAPI.DTOs
{
    public class KorisnikServiceDTO : BaseResponseDTO
    {
        public Korisnik? Korisnik { get; init; }

        public static KorisnikServiceDTO Ok(Korisnik korisnik, string message)
        {
            return new() { Message = message, Success = true, Korisnik = korisnik };
        }

        public static new KorisnikServiceDTO Error(string message)
        {
            return new() { Message = message, Success = false, Korisnik = null };
        }
    }
}
