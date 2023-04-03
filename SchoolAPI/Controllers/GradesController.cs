using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Business.Enum;
using SchoolAPI.Data.Dto.Grades;
using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GradesController : BaseController
{
    private readonly IGradesService _service;
    private readonly IMapper _mapper;

    public GradesController(IGradesService service, IMapper mapper) => (_service,_mapper) = (service,mapper);

    /// <summary>
    /// returns all student grades
    /// </summary>
    /// <returns>ActionResult</returns>
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            return Ok(_mapper.Map<ICollection<ReadGradesDto>>(await _service.GetAll()));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// returns all student grades by grade id
    /// </summary>
    /// <param name="id">grades id</param>
    /// <returns>IActionResult</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(_mapper.Map<ReadGradesDto>(await _service.GetById(id)));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// returns all grades by studentId
    /// </summary>
    /// <param name="id">student id</param>
    /// <returns>IActionResult</returns>
    [HttpGet("[Action]/{studentId}")]
    public async Task<ActionResult> GetGradesByStudentId(int studentId)
    {
        try
        {
            return Ok(_mapper.Map<ICollection<ReadGradesByStudentIdDto>>(await _service.GetGradesByStudentId(studentId)));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// add student grades
    /// </summary>
    /// <param name="model">object with the required fields</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Insert successfully</response>
    [HttpPost]
    public async Task<ActionResult<PostUpdateGradesDto>> Post([FromBody] PostUpdateGradesDto model)
    {
        if (!ModelState.IsValid) return Response(Messages.MODELSTATE_FALSE);

        try
        {
            var result = _mapper.Map<Grades>(model);

            await _service.Post(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// updates student grades
    /// </summary>
    /// <param name="model">object with the required fields</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">updated successfully</response>
    [HttpPut]
    public async Task<ActionResult<PostUpdateGradesDto>> Put([FromBody] PostUpdateGradesDto model)
    {
        if (!ModelState.IsValid) return Response(Messages.MODELSTATE_FALSE);

        try
        {
            var result = _mapper.Map<Grades>(model);

            await _service.Put(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// delete student grades
    /// </summary>
    /// <param name="id">address id</param>
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
