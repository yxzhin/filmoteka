using filmotekaAPI.Models;

namespace filmotekaAPI.DTOs
{
    public class KorisnikServiceGetByIdDTO : BaseResponseDTO
    {
        public Korisnik? Korisnik { get; init; }

        public static KorisnikServiceGetByIdDTO Ok(Korisnik korisnik, string message)
        {
            return new()
            {
                Message = message,
                Success = true,
                Korisnik = korisnik
            };
        }

        public static new KorisnikServiceGetByIdDTO Error(string message)
        {
            return new() { Message = message, Success = false, Korisnik = null };
        }
    }
}
