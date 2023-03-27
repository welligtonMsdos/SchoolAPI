using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;

namespace SchoolAPI.Data.EFCore;

public class MatterEF : IMatterRepository
{
    private readonly SchoolContext _context;

    public MatterEF(SchoolContext context) => (_context) = (context);
    
    public void Delete(Matter obj)
    {
        _context.Remove(obj);
        _context.SaveChanges();
    }

    public ICollection<Matter> GetAll()
    {
        return _context.Matters
            .Include(x => x.matterProfessors)
            .Include(x => x.Grades)
            .ToList();
    }

    public Matter GetById(int id)
    {
        return _context.Matters
           .Include(x => x.matterProfessors)
           .Include(x => x.Grades)
           .First(x => x.Id == id);
    }

    public ICollection<Matter> GetSearch(string value)
    {
        return _context.Matters
           .Include(x => x.matterProfessors)
           .Include(x => x.Grades)
           .Where(x=>x.Name.Contains(value))
           .ToList();
    }

    public void Post(Matter obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Put(Matter obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }
}
