using SchoolAPI.Data.Model;

namespace SchoolAPI.Data.Interface;

public interface IMatterProfessorService : IServiceDefault<MatterProfessor>
{
    Task<ICollection<MatterProfessor>> GetByProfessorId(int professorId);
}
