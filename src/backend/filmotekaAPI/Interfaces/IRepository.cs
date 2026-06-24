namespace filmotekaAPI.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T?> GetById(int id);
        Task<List<T>> GetMany(int offset = 0, int limit = 10);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
