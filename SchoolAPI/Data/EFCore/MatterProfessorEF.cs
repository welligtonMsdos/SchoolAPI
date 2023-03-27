using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;

namespace SchoolAPI.Data.EFCore;

public class MatterProfessorEF : IMatterProfessorRepository
{
    private readonly SchoolContext _context;

    public MatterProfessorEF(SchoolContext context) => (_context) = (context);

    public void Delete(MatterProfessor obj)
    {
        _context.Remove(obj);
        _context.SaveChanges();
    }

    public ICollection<MatterProfessor> GetAll()
    {
        return _context.MatterProfessors
            .Include(x => x.Matter)
            .Include(x => x.Professor)
             .ToList();
    }

    public MatterProfessor GetById(int id)
    {
        return _context.MatterProfessors
          .Include(x => x.Matter)
          .Include(x => x.Professor)
           .First(x => x.Id == id);
    }

    public ICollection<MatterProfessor> GetSearch(string value)
    {
        return _context.MatterProfessors
          .Include(x => x.Matter)
          .Include(x => x.Professor)
          .Where(x => x.Matter.Name.Contains(value) ||
          x.Professor.Name.Contains(value))
           .ToList();
    }

    public void Post(MatterProfessor obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Put(MatterProfessor obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }
}
