using filmotekaAPI.DTOs;
using filmotekaAPI.Interfaces;
using filmotekaAPI.Models;

namespace filmotekaAPI.Services
{
    public class KorisnikService(
        IKorisnikRepository repository,
        IAuthService authService
    ) : IKorisnikService
    {
        private readonly IKorisnikRepository _repository = repository;
        private readonly IAuthService _authService = authService;

        public async Task<KorisnikGetByIdResponseDTO> GetById(int id)
        {
            Korisnik? korisnik = await _repository.GetById(id);

            return korisnik is null
                ? KorisnikGetByIdResponseDTO.Error("korisnik nije pronadjen")
                : KorisnikGetByIdResponseDTO.Ok(korisnik, "korisnik je uspesno pronadjen");
        }

        public async Task<KorisnikGetManyResponseDTO> GetMany(int offset = 0, int limit = 10)
        {
            List<Korisnik> korisnici = await _repository.GetMany(offset, limit);
            return KorisnikGetManyResponseDTO.Ok(korisnici, "korisnici su uspesno izlistani");
        }

        public async Task<BaseResponseDTO> Register(string ime, string prezime, string email, string password)
        {
            Korisnik? korisnik = await _repository.GetByEmail(email);
            if (korisnik is not null)
            {
                return BaseResponseDTO.Error("korisnik sa ovom elektronskom postom vec postoji");
            }
            korisnik = new()
            {
                Ime = ime,
                Prezime = prezime,
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                Uloga = Uloga.user
            };
            await _repository.Save(korisnik);
            return BaseResponseDTO.Ok("korisnik je uspesno kreiran");
        }

        public async Task<LoginResponseDTO> Login(string email, string password)
        {
            Korisnik? korisnik = await _repository.GetByEmail(email);
            if (korisnik is null
                || !BCrypt.Net.BCrypt.Verify(password, korisnik.Password))
            {
                return LoginResponseDTO.Error("neispravna elektronska posta ili sifra");
            }

            string accessToken = _authService.GenerateToken(korisnik);
            string tokenType = "Bearer";

            return LoginResponseDTO.Ok("korisnik je uspesno ulogovan", accessToken, tokenType);
        }
    }
}
