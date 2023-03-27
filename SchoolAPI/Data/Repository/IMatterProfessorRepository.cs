using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Data.Repository;

public interface IMatterProfessorRepository : IQuery<MatterProfessor>, ICommand<MatterProfessor>
{
}
