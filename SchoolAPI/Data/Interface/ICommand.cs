namespace SchoolAPI.Data.Interface;

public interface ICommand<T>
{
    void Post(T obj);
    void Put(T obj);
    void Delete(T obj);
}
