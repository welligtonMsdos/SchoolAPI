namespace SchoolAPI.Data.Interface;

public interface IQuery<T>
{
    Task<ICollection<T>> GetAll();
    Task<ICollection<T>> GetSearch(string value);
    Task<T> GetById(int id);
}
