using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Business.Enum;
using SchoolAPI.Data.Dto.MatterProfessor;
using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MatterProfessorController : BaseController
{
    private readonly IMatterProfessorService _service;
    private readonly IMapper _mapper;

    public MatterProfessorController(IMatterProfessorService service, IMapper mapper) => (_service,_mapper) = (service,mapper);

    /// <summary>
    /// returns all matteres and professors
    /// </summary>
    /// <returns>ActionResult</returns>
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            return Ok(_mapper.Map<ICollection<ReadMatterProfessorDto>>(await _service.GetAll()));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// returns all matteres and professors by id
    /// </summary>
    /// <param name="id">matter and professor id</param>
    /// <returns>IActionResult</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(_mapper.Map<ReadMatterProfessorDto>(await _service.GetById(id)));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// returns all matteres and professors by professor id
    /// </summary>
    /// <param name="professorId">professor id</param>
    /// <returns>ActionResult</returns>
    [HttpGet("[Action]/{professorId}")]
    public async Task<ActionResult> GetByProfessorId(int professorId)
    {
        try
        {
            return Ok(_mapper.Map<ICollection<ReadMatterProfessorDto>>(await _service.GetByProfessorId(professorId)));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Add an matter and professor
    /// </summary>
    /// <param name="model">object with the required fields</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Insert successfully</response>
    [HttpPost]
    public async Task<ActionResult<PostUpdateMatterProfessorDto>> Post([FromBody] PostUpdateMatterProfessorDto model)
    {
        if (!ModelState.IsValid) return Response(Messages.MODELSTATE_FALSE);

        try
        {
            var result = _mapper.Map<MatterProfessor>(model);

            await _service.Post(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// updates an matter and professor
    /// </summary>
    /// <param name="model">object with the required fields</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">updated successfully</response>
    [HttpPut]
    public async Task<ActionResult<PostUpdateMatterProfessorDto>> Put([FromBody] PostUpdateMatterProfessorDto model)
    {
        if (!ModelState.IsValid) return Response(Messages.MODELSTATE_FALSE);

        try
        {
            var result = _mapper.Map<MatterProfessor>(model);

            await _service.Put(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// delete an matter and professor
    /// </summary>
    /// <param name="id">matter and professor id</param>
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
