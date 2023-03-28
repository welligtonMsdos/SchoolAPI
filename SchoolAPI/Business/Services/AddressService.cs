using SchoolAPI.Business.Enum;
using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;
using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Business.Services;

public class AddressService : IServiceDefault<Address>
{
    private readonly IAddressRepository _repository;

    public AddressService(IAddressRepository repository) => (_repository) = (repository);
    
    public bool Delete(Address obj)
    {
        if (obj.Id == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);

        _repository.Delete(obj);

        return obj.Id > 0 ? true : false;
    }

    public ICollection<Address> GetAll()
    {
        return _repository.GetAll();
    }

    public Address GetById(int id)
    {
        if (id == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);

        return _repository.GetById(id);
    }

    public ICollection<Address> GetSearch(string value)
    {
        return _repository.GetSearch(value);
    }

    public bool Post(Address obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Post(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Put(Address obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Put(obj);

        return obj.Id > 0 ? true : false;
    }
}
