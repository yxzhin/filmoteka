using filmotekaAPI.Models;

namespace filmotekaAPI.Interfaces
{
    public interface IKorisnikRepository : IRepository<Korisnik>
    {
        new Task<Korisnik?> GetById(int id);
        new Task<List<Korisnik>> GetMany(int offset = 0, int limit = 10);
        Task<Korisnik?> GetByEmail(string email);
        new Task Save(Korisnik entity);
        new Task Delete(Korisnik entity);
    }
}
