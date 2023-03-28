using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;

namespace SchoolAPI.Data.EFCore;

public class ProfessorEF : IProfessorRepository
{
    private readonly SchoolContext _context;

    public ProfessorEF(SchoolContext context) => (_context) = (context);
    
    public async Task Delete(Professor obj)
    {
        _context.Remove(obj);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Professor>> GetAll()
    {
        return await _context.professors
            .Include(x=>x.matterProfessors)
            .ToListAsync();
    }

    public async Task<Professor> GetById(int id)
    {
        return await _context.professors
            .Include(x => x.matterProfessors)
            .FirstAsync(x => x.Id == id);
    }

    public async Task<ICollection<Professor>> GetSearch(string value)
    {
        return await _context.professors
           .Include(x => x.matterProfessors)
           .Where(x => x.Name.Contains(value))
           .ToListAsync();
    }

    public async Task Post(Professor obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
    }

    public async Task Put(Professor obj)
    {
        _context.Update(obj);
        await _context.SaveChangesAsync();
    }
}
