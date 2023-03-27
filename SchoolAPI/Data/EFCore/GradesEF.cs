using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;

namespace SchoolAPI.Data.EFCore;

public class GradesEF : IGradesRepository
{
    private readonly SchoolContext _context;

    public GradesEF(SchoolContext context) => (_context) = (context);

    public void Delete(Grades obj)
    {
        _context.Remove(obj);
        _context.SaveChanges();
    }

    public ICollection<Grades> GetAll()
    {
        return _context.Grades
            .Include(x => x.Students)
            .Include(x => x.Matters)
            .ToList();
    }

    public Grades GetById(int id)
    {
        return _context.Grades
            .Include(x => x.Students)
            .Include(x => x.Matters)
           .First(x => x.Id == id);
    }

    public ICollection<Grades> GetSearch(string value)
    {
        return _context.Grades
           .Include(x => x.Students)
           .Include(x => x.Matters)
           .Where(x => x.Students.Name.Contains(value) || 
           x.Matters.Name.Contains(value))
           .ToList();
    }

    public void Post(Grades obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Put(Grades obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }
}
