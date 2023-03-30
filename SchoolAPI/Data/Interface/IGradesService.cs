using SchoolAPI.Data.Model;

namespace SchoolAPI.Data.Interface;

public interface IGradesService : IServiceDefault<Grades>
{
    Task<ICollection<Grades>> GetGradesByStudentId(int studentId);
}
