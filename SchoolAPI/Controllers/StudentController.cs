using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Business.Enum;
using SchoolAPI.Data.Dto.Student;
using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : BaseController
{
    private readonly IStudentService _service;
    private readonly IMapper _mapper;

    public StudentController(IStudentService service, IMapper mapper) => (_service,_mapper) = (service,mapper);

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            return Ok(_mapper.Map<ICollection<ReadStudentDto>>(await _service.GetAll()));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(_mapper.Map<ReadStudentDto>(await _service.GetById(id)));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<PostUpdateStudentDto>> Post([FromBody] PostUpdateStudentDto model)
    {
        if (!ModelState.IsValid) return Response(Messages.MODELSTATE_FALSE);

        try
        {
            var result = _mapper.Map<Student>(model);

            await _service.Post(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<PostUpdateStudentDto>> Put([FromBody] PostUpdateStudentDto model)
    {
        if (!ModelState.IsValid) return Response(Messages.MODELSTATE_FALSE);

        try
        {
            var result = _mapper.Map<Student>(model);

            await _service.Put(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _service.Delete(id);

            return Ok(Messages.SUCCESSFULLY_DELETED);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }
}
