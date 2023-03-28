using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;

namespace SchoolAPI.Data.EFCore;

public class AddressEF : IAddressRepository
{
    private readonly SchoolContext _context;

    public AddressEF(SchoolContext context) => (_context) = (context);

    public async Task Delete(Address obj)
    {
        _context.Remove(obj);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Address>> GetAll()
    {
        return await _context.Address.ToListAsync();
    }

    public async Task<Address> GetById(int id)
    {
        return await _context.Address.FirstAsync(x => x.Id == id);
    }

    public async Task<ICollection<Address>> GetSearch(string value)
    {
        return await _context.Address
             .Where(x => x.Cep.Contains(value) ||
              x.Neighborhood.Contains(value) ||
              x.City.Contains(value))
             .ToListAsync();
    }

    public async Task Post(Address obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
    }

    public async Task Put(Address obj)
    {
        _context.Update(obj);
        await _context.SaveChangesAsync();
    }
}
