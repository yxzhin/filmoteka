using filmotekaAPI.DTOs;

namespace filmotekaAPI.Interfaces
{
    public interface IKorisnikService
    {
        Task<KorisnikServiceGetByIdDTO> GetById(int id);
        Task<KorisnikServiceGetManyDTO> GetMany(int offset = 0, int limit = 10);
        Task<BaseResponseDTO> Register(string ime, string prezime,
            string email, string password);
        Task<KorisnikServiceLoginDTO> Login(string email, string password);
    }
}
