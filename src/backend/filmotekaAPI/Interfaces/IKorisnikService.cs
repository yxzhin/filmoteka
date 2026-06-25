using filmotekaAPI.DTOs;

namespace filmotekaAPI.Interfaces
{
    public interface IKorisnikService
    {
        Task<KorisnikGetByIdResponseDTO> GetById(int id);
        Task<KorisnikGetManyResponseDTO> GetMany(int offset = 0, int limit = 10);
        Task<BaseResponseDTO> Register(string ime, string prezime,
            string email, string password);
        Task<LoginResponseDTO> Login(string email, string password);
    }
}
