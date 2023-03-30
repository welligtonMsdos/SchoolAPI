using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;

namespace SchoolAPI.Data.EFCore;

public class GradesEF : IGradesRepository
{
    private readonly SchoolContext _context;

    public GradesEF(SchoolContext context) => (_context) = (context);

    public async Task Delete(Grades obj)
    {
        _context.Remove(obj);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Grades>> GetAll()
    {
        return await _context.Grades
            .Include(x => x.Students)
            .Include(x => x.Matters)
            .ToListAsync();
    }

    public async Task<Grades> GetById(int id)
    {
        return await _context.Grades
            .Include(x => x.Students)
            .Include(x => x.Matters)
           .FirstAsync(x => x.Id == id);
    }

    public async Task<ICollection<Grades>> GetGradesByStudentId(int studentId)
    {
        return await _context.Grades
           .Include(x => x.Students)
           .Include(x => x.Matters)
           .Where(x => x.StudentId == studentId)
           .OrderBy(x => x.Matters.Name)
           .ToListAsync();
    }

    public async Task<ICollection<Grades>> GetSearch(string value)
    {
        return await _context.Grades
           .Include(x => x.Students)
           .Include(x => x.Matters)
           .Where(x => x.Students.Name.Contains(value) || 
           x.Matters.Name.Contains(value))
           .ToListAsync();
    }

    public async Task Post(Grades obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
    }

    public async Task Put(Grades obj)
    {
        _context.Update(obj);
        await _context.SaveChangesAsync();
    }
}
