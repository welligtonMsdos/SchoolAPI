using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;

namespace SchoolAPI.Data.EFCore;

public class AddressEF : IAddressRepository
{
    private readonly SchoolContext _context;

    public AddressEF(SchoolContext context) => (_context) = (context);

    public void Delete(Address obj)
    {
        _context.Remove(obj);
        _context.SaveChanges();
    }

    public ICollection<Address> GetAll()
    {
        return _context.Address
            .ToList();
    }

    public Address GetById(int id)
    {
        return _context.Address
             .First(x => x.Id == id);
    }

    public ICollection<Address> GetSearch(string value)
    {
        return _context.Address
             .Where(x => x.Cep.Contains(value) ||
              x.Neighborhood.Contains(value) ||
              x.City.Contains(value))
             .ToList();
    }

    public void Post(Address obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Put(Address obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }
}
