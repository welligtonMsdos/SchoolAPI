using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Business.Enum;
using SchoolAPI.Data.Dto.Professor;
using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfessorController : BaseController
{
    private readonly IProfessorService _service;
    private readonly IMapper _mapper;

    public ProfessorController(IProfessorService service, IMapper mapper) => (_service,_mapper) = (service,mapper);

    /// <summary>
    /// returns all professors
    /// </summary>
    /// <returns>ActionResult</returns>
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            return Ok(_mapper.Map<ICollection<ReadProfessorDto>>(await _service.GetAll()));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// returns all professors by id
    /// </summary>
    /// <param name="id">professor id</param>
    /// <returns>IActionResult</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(_mapper.Map<ReadProfessorDto>(await _service.GetById(id)));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Add an professor
    /// </summary>
    /// <param name="model">object with the required fields</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Insert successfully</response>
    [HttpPost]
    public async Task<ActionResult<PostUpdateProfessorDto>> Post([FromBody] PostUpdateProfessorDto model)
    {
        if (!ModelState.IsValid) return Response(Messages.MODELSTATE_FALSE);

        try
        {
            var result = _mapper.Map<Professor>(model);

            await _service.Post(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// updates an professor
    /// </summary>
    /// <param name="model">object with the required fields</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">updated successfully</response>
    [HttpPut]
    public async Task<ActionResult<PostUpdateProfessorDto>> Put([FromBody] PostUpdateProfessorDto model)
    {
        if (!ModelState.IsValid) return Response(Messages.MODELSTATE_FALSE);

        try
        {
            var result = _mapper.Map<Professor>(model);

            await _service.Put(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// delete an professor
    /// </summary>
    /// <param name="id">professor id</param>
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
