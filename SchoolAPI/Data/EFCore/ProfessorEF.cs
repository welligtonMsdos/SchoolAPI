using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;

namespace SchoolAPI.Data.EFCore;

public class ProfessorEF : IProfessorRepository
{
    private readonly SchoolContext _context;

    public ProfessorEF(SchoolContext context) => (_context) = (context);
    
    public void Delete(Professor obj)
    {
        _context.Remove(obj);
        _context.SaveChanges();
    }

    public ICollection<Professor> GetAll()
    {
        return _context.professors
            .Include(x=>x.matterProfessors)
            .ToList();
    }

    public Professor GetById(int id)
    {
        return _context.professors
            .Include(x => x.matterProfessors)
            .First(x => x.Id == id);
    }

    public ICollection<Professor> GetSearch(string value)
    {
        return _context.professors
           .Include(x => x.matterProfessors)
           .Where(x => x.Name.Contains(value))
           .ToList();
    }

    public void Post(Professor obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Put(Professor obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }
}
