using SchoolAPI.Business.Enum;
using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;
using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Business.Services;

public class ProfessorService : IServiceDefault<Professor>
{
    private readonly IProfessorRepository _repository;

    public ProfessorService(IProfessorRepository repository) => (_repository) = (repository);
    
    public bool Delete(Professor obj)
    {
        if (obj.Id == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);

        _repository.Delete(obj);

        return obj.Id > 0 ? true : false;
    }

    public ICollection<Professor> GetAll()
    {
        return _repository.GetAll();
    }

    public Professor GetById(int id)
    {
        if (id == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);

        return _repository.GetById(id);
    }

    public ICollection<Professor> GetSearch(string value)
    {
        return _repository.GetSearch(value);
    }

    public bool Post(Professor obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Post(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Put(Professor obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Put(obj);

        return obj.Id > 0 ? true : false;
    }
}
