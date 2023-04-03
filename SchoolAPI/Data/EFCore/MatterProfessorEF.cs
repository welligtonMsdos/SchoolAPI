using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;

namespace SchoolAPI.Data.EFCore;

public class MatterProfessorEF : IMatterProfessorRepository
{
    private readonly SchoolContext _context;

    public MatterProfessorEF(SchoolContext context) => (_context) = (context);

    public async Task Delete(MatterProfessor obj)
    {
        _context.Remove(obj);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<MatterProfessor>> GetAll()
    {
        return await _context.MatterProfessors
            .Include(x => x.Matter)
            .Include(x => x.Professor)
             .ToListAsync();
    }

    public async Task<MatterProfessor> GetById(int id)
    {
        return await _context.MatterProfessors
          .Include(x => x.Matter)
          .Include(x => x.Professor)
           .FirstAsync(x => x.Id == id);
    }

    public async Task<ICollection<MatterProfessor>> GetSearch(string value)
    {
        return await _context.MatterProfessors
          .Include(x => x.Matter)
          .Include(x => x.Professor)
          .Where(x => x.Matter.Name.Contains(value) ||
          x.Professor.Name.Contains(value))
           .ToListAsync();
    }

    public async Task Post(MatterProfessor obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
    }

    public async Task Put(MatterProfessor obj)
    {
        _context.Update(obj);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<MatterProfessor>> GetByProfessorId(int professorId)
    {
        return await _context.MatterProfessors
       .Include(x => x.Matter)
       .Include(x => x.Professor)
       .Where(x => x.ProfessorId == professorId)
       .ToListAsync();
    }
}
