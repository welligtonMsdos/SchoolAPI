using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Data.Repository;

public interface IGradesRepository : IQuery<Grades>, ICommand<Grades>
{
}
