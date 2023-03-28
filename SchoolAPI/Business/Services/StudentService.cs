using SchoolAPI.Business.Enum;
using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;
using SchoolAPI.Data.Repository;
using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Business.Services;

public class StudentService : IServiceDefault<Student>
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository) => (_repository) = (repository);
    
    public bool Delete(Student obj)
    {
        if (obj.Id == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);

        _repository.Delete(obj);

        return obj.Id > 0 ? true : false;
    }

    public ICollection<Student> GetAll()
    {
        return _repository.GetAll();
    }

    public Student GetById(int id)
    {
        if (id == 0) throw new Exception(Messages.ID_CANNOT_BE_RESET);

        return _repository.GetById(id);
    }

    public ICollection<Student> GetSearch(string value)
    {
        return _repository.GetSearch(value);
    }

    public bool Post(Student obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Post(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Put(Student obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Put(obj);

        return obj.Id > 0 ? true : false;
    }
}
