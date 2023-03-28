using SchoolAPI.Business.Enum;
using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;
using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Business.Services;

public class MatterService : IServiceDefault<Matter>
{
    private readonly IMatterRepository _repository;

    public MatterService(IMatterRepository repository) => (_repository) = (repository);
    
    public bool Delete(Matter obj)
    {
        if (obj.Id == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);

        _repository.Delete(obj);

        return obj.Id > 0 ? true : false;
    }

    public ICollection<Matter> GetAll()
    {
        return _repository.GetAll();
    }

    public Matter GetById(int id)
    {
        if (id == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);

        return _repository.GetById(id);
    }

    public ICollection<Matter> GetSearch(string value)
    {
        return _repository.GetSearch(value);
    }

    public bool Post(Matter obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Post(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Put(Matter obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Put(obj);

        return obj.Id > 0 ? true : false;
    }
}
