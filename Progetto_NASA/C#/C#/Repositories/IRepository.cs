namespace C_.Repositories
{
    public interface IRepository<T>
    {
        bool DeleteByID(int id);
        List<T> GetAll();
        public bool Insert(T t);
        public bool Update(T t);
        public T? GetByID(int id);


    }
}
