using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;

namespace SchoolAPI.Data.EFCore;

public class StudentEF : IStudentRepository
{
    private readonly SchoolContext _context;

    public StudentEF(SchoolContext context) => (_context) = (context);

    public void Delete(Student obj)
    {
        _context.Remove(obj);
        _context.SaveChanges();
    }

    public ICollection<Student> GetAll()
    {
        return _context.Students
            .Include(x=>x.Grades)
            .ToList();
    }

    public Student GetById(int id)
    {
        return _context.Students
            .Include(x => x.Grades)
            .First(x => x.Id == id);
    }

    public ICollection<Student> GetSearch(string value)
    {
        return _context.Students
            .Include(x => x.Grades)
            .Where(x=>x.Name.Contains(value))
            .ToList();
    }

    public void Post(Student obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Put(Student obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }
}
