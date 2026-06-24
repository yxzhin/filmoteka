namespace filmotekaAPI.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        T GetById(int id);
        List<T> GetMany(int offset = 0, int limit = 10);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
