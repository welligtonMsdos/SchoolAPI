using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Data.Repository;

public interface IStudentRepository : IQuery<Student>, ICommand<Student>
{
}
