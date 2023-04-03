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

    /// <summary>
    /// returns all students
    /// </summary>
    /// <returns>ActionResult</returns>
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

    /// <summary>
    /// returns all students by id
    /// </summary>
    /// <param name="id">students id</param>
    /// <returns>IActionResult</returns>
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

    /// <summary>
    /// Add an student
    /// </summary>
    /// <param name="model">object with the required fields</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Insert successfully</response>
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

    /// <summary>
    /// updates an student
    /// </summary>
    /// <param name="model">object with the required fields</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">updated successfully</response>
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

    /// <summary>
    /// delete an student
    /// </summary>
    /// <param name="id">student id</param>
    /// <returns>ActionResult</returns>
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
