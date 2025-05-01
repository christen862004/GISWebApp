namespace GISWebApp.Repository
{
    public interface IRepository<T>
    {
        //CRUD
        List<T> GetAll(string includes="");
        T GetById(int id);
        void Add(T obj);
        void Update(T obj);
        void Delete(int id);
        void Save(); //separate ADD ,Update ,Delete
    }
}
