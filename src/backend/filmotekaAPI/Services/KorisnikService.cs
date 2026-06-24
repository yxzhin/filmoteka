using filmotekaAPI.DTOs;
using filmotekaAPI.Interfaces;
using filmotekaAPI.Repositories;

namespace filmotekaAPI.Services
{
    public class KorisnikService(KorisnikRepository repository) : IKorisnikService
    {
        private readonly KorisnikRepository _repository = repository;

        public Task<KorisnikServiceGetByIdDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<KorisnikServiceGetManyDTO> GetMany(int offset = 0, int limit = 10)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseDTO> Register(string ime, string prezime, string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<KorisnikServiceLoginDTO> Login(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
