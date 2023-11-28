namespace AdoNetTask.Services
{
    public interface IBaseService<T>
    {
        ICollection<T> GetAll();
        T GetById(int id);
        int Create(T data);
        int Update(int id, T data);
        int Delete(int id);
    }
}
