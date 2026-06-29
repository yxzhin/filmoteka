using filmotekaAPI.Models;

namespace filmotekaAPI.Interfaces.ReziserInterfaces
{
    public interface IReziserRepository : IRepository<Reziser>
    {
        new Task<Reziser?> GetById(int id);
        new Task<List<Reziser>> GetMany(int offset = 0, int limit = 10);
        Task<Reziser?> GetByName(string name);
        new Task Save(Reziser entity);
        new Task Delete(Reziser entity);
    }
}
