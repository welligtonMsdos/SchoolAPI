using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Data.Repository;

public interface IProfessorRepository : IQuery<Professor>, ICommand<Professor>
{
}
