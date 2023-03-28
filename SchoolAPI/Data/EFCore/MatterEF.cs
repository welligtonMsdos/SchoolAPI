using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;

namespace SchoolAPI.Data.EFCore;

public class MatterEF : IMatterRepository
{
    private readonly SchoolContext _context;

    public MatterEF(SchoolContext context) => (_context) = (context);
    
    public async Task Delete(Matter obj)
    {
        _context.Remove(obj);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Matter>> GetAll()
    {
        return await _context.Matters
            .Include(x => x.matterProfessors)
            .Include(x => x.Grades)
            .ToListAsync();
    }

    public async Task<Matter> GetById(int id)
    {
        return await _context.Matters
           .Include(x => x.matterProfessors)
           .Include(x => x.Grades)
           .FirstAsync(x => x.Id == id);
    }

    public async Task<ICollection<Matter>> GetSearch(string value)
    {
        return await _context.Matters
           .Include(x => x.matterProfessors)
           .Include(x => x.Grades)
           .Where(x=>x.Name.Contains(value))
           .ToListAsync();
    }

    public async Task Post(Matter obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
    }

    public async Task Put(Matter obj)
    {
        _context.Update(obj);
        await _context.SaveChangesAsync();
    }
}
