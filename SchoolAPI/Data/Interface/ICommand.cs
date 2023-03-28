namespace SchoolAPI.Data.Interface;

public interface ICommand<T>
{
    Task Post(T obj);
    Task Put(T obj);
    Task Delete(T obj);
}
