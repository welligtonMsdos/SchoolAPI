using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;

namespace SchoolAPI.Data.EFCore;

public class StudentEF : IStudentRepository
{
    private readonly SchoolContext _context;

    public StudentEF(SchoolContext context) => (_context) = (context);

    public async Task Delete(Student obj)
    {
        _context.Remove(obj);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Student>> GetAll()
    {
        return await _context.Students
            .Include(x=>x.Grades)
            .ToListAsync();
    }

    public async Task<Student> GetById(int id)
    {
        return await _context.Students
            .Include(x => x.Grades)
            .FirstAsync(x => x.Id == id);
    }

    public async Task<ICollection<Student>> GetSearch(string value)
    {
        return await _context.Students
            .Include(x => x.Grades)
            .Where(x=>x.Name.Contains(value))
            .ToListAsync();
    }

    public async Task Post(Student obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
    }

    public async Task Put(Student obj)
    {
        _context.Update(obj);
        await _context.SaveChangesAsync();
    }
}
