using SchoolAPI.Business.Enum;
using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;
using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Business.Services;

public class ProfessorService : IProfessorService
{
    private readonly IProfessorRepository _repository;

    public ProfessorService(IProfessorRepository repository) => (_repository) = (repository);

    public async Task<bool> Delete(Professor obj)
    {
        if (obj.Id == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);

        await _repository.Delete(obj);

        return obj.Id > 0 ? true : false;
    }

    public async Task<ICollection<Professor>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<Professor> GetById(int id)
    {
        if (id == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);

        return await _repository.GetById(id);
    }

    public async Task<ICollection<Professor>> GetSearch(string value)
    {
        return await _repository.GetSearch(value);
    }

    public async Task<bool> Post(Professor obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        await _repository.Post(obj);

        return obj.Id > 0 ? true : false;
    }

    public async Task<bool> Put(Professor obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        await _repository.Put(obj);

        return obj.Id > 0 ? true : false;
    }
}
