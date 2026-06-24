using filmotekaAPI.Models;

namespace filmotekaAPI.Interfaces
{
    public interface IKorisnikRepository : IRepository<Korisnik>
    {
        new Task<Korisnik?> GetById(int id);
        new Task<List<Korisnik>> GetMany(int offset = 0, int limit = 10);
        new void Create(Korisnik entity);
        new void Update(Korisnik entity);
        new void Delete(Korisnik entity);
    }
}
