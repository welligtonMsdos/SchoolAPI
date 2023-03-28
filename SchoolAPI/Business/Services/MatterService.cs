using SchoolAPI.Business.Enum;
using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;
using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Business.Services;

public class MatterService : IMatterService
{
    private readonly IMatterRepository _repository;

    public MatterService(IMatterRepository repository) => (_repository) = (repository);

    public async Task<bool> Delete(Matter obj)
    {
        if (obj.Id == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);

        await _repository.Delete(obj);

        return obj.Id > 0 ? true : false;
    }

    public async Task<ICollection<Matter>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<Matter> GetById(int id)
    {
        if (id == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);

        return await _repository.GetById(id);
    }

    public async Task<ICollection<Matter>> GetSearch(string value)
    {
        return await _repository.GetSearch(value);
    }

    public async Task<bool> Post(Matter obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        await _repository.Post(obj);

        return obj.Id > 0 ? true : false;
    }

    public async Task<bool> Put(Matter obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        await _repository.Put(obj);

        return obj.Id > 0 ? true : false;
    }
}
