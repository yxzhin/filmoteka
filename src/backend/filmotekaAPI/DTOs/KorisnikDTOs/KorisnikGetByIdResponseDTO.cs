using filmotekaAPI.Models;

namespace filmotekaAPI.DTOs.KorisnikDTOs
{
    public class KorisnikGetByIdResponseDTO : BaseResponseDTO
    {
        public Korisnik? Korisnik { get; init; }

        public static KorisnikGetByIdResponseDTO Ok(Korisnik korisnik, string message)
        {
            return new()
            {
                Message = message,
                Success = true,
                Korisnik = korisnik
            };
        }

        public static new KorisnikGetByIdResponseDTO Error(string message)
        {
            return new()
            {
                Message = message,
                Success = false,
                Korisnik = null
            };
        }
    }
}
