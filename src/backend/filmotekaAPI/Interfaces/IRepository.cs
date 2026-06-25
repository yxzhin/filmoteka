namespace filmotekaAPI.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T?> GetById(int id);
        Task<List<T>> GetMany(int offset = 0, int limit = 10);
        Task Save(T entity);
        Task Delete(T entity);
    }
}
