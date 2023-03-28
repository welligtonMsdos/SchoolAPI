namespace SchoolAPI.Data.Interface;

public interface IServiceDefault<T>
{
    Task<ICollection<T>> GetAll();
    Task<ICollection<T>> GetSearch(string value);
    Task<T> GetById(int id);
    Task<bool> Post(T obj);
    Task<bool> Put(T obj);
    Task<bool> Delete(T obj);
}
