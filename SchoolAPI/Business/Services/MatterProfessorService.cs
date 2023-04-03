using SchoolAPI.Business.Enum;
using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;
using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Business.Services;

public class MatterProfessorService : IMatterProfessorService
{
    private readonly IMatterProfessorRepository _repository;
    private readonly IGradesRepository _gradeRepository;

    public MatterProfessorService(IMatterProfessorRepository repository,
        IGradesRepository gradeRepository) => (_repository, _gradeRepository) = (repository, gradeRepository);

    public async Task<bool> Delete(int id)
    {
        if (id == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);       

        var obj = _repository.GetById(id);

        if (GradeExist(obj.Result.MatterId)) throw new Exception(Messages.ID_EXISTS);

        await _repository.Delete(await obj);

        return obj.Id > 0 ? true : false;
    }

    private bool GradeExist(int matterId)
    {
        return _gradeRepository.GetGradesByMatterId(matterId).Result.Count > 0 ? true : false;
    }

    public async Task<ICollection<MatterProfessor>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<MatterProfessor> GetById(int id)
    {
        if (id == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);

        return await _repository.GetById(id);
    }

    public async Task<ICollection<MatterProfessor>> GetSearch(string value)
    {
        return await _repository.GetSearch(value);
    }

    public async Task<bool> Post(MatterProfessor obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        await _repository.Post(obj);

        return obj.Id > 0 ? true : false;
    }

    public async Task<bool> Put(MatterProfessor obj)
    {
        if (obj.Id == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);

        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        await _repository.Put(obj);

        return obj.Id > 0 ? true : false;
    }

    public async Task<ICollection<MatterProfessor>> GetByProfessorId(int professorId)
    {
        if (professorId == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);

        return await _repository.GetByProfessorId(professorId);
    }
}
