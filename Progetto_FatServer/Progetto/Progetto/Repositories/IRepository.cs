namespace Progetto.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T Get(int id);
        bool Insert(T t);
        bool Update(T t);
        bool Delete(T t);
    }
}
