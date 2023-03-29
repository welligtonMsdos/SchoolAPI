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
