namespace SchoolAPI.Data.Interface;

public interface IServiceDefault<T>
{
    ICollection<T> GetAll();
    ICollection<T> GetSearch(string value);
    T GetById(int id);
    bool Post(T obj);
    bool Put(T obj);
    bool Delete(T obj);
}
