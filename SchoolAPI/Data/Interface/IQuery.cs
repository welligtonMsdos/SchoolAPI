namespace SchoolAPI.Data.Interface;

public interface IQuery<T>
{
    ICollection<T> GetAll();
    ICollection<T> GetSearch(string value);
    T GetById(int id);
}
