using SchoolAPI.Business.Enum;
using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;
using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Business.Services;

public class GradesService : IServiceDefault<Grades>
{
    private readonly IGradesRepository _repository;

    public GradesService(IGradesRepository repository) => (_repository) = (repository);
    
    public bool Delete(Grades obj)
    {
        if (obj.Id == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);

        _repository.Delete(obj);

        return obj.Id > 0 ? true : false;
    }

    public ICollection<Grades> GetAll()
    {
        return _repository.GetAll();
    }

    public Grades GetById(int id)
    {
        if (id == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);

        return _repository.GetById(id);
    }

    public ICollection<Grades> GetSearch(string value)
    {
        return _repository.GetSearch(value);
    }

    public bool Post(Grades obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Post(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Put(Grades obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Put(obj);

        return obj.Id > 0 ? true : false;
    }
}
