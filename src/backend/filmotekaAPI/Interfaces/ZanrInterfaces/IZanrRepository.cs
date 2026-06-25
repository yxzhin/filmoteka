using filmotekaAPI.Models;

namespace filmotekaAPI.Interfaces.ZanrInterfaces
{
    public interface IZanrRepository : IRepository<Zanr>
    {
        new Task<Zanr?> GetById(int id);
        new Task<List<Zanr>> GetMany(int offset = 0, int limit = 10);
        Task<Zanr?> GetByName(string name);
        new Task Save(Zanr entity);
        new Task Delete(Zanr entity);
    }
}
