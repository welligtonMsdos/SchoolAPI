using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Data.Dto.Address;
using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : BaseController
{
    private readonly IAddressService _service;
    private readonly IMapper _mapper;

    public AddressController(IAddressService service, IMapper mapper) => (_service,_mapper) = (service,mapper);

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            return Ok(_mapper.Map<ICollection<ReadAddressDto>>(await _service.GetAll()));
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
            return Ok(_mapper.Map<ReadAddressDto>(await _service.GetById(id)));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<PostUpdateAddressDto>> Post([FromBody] PostUpdateAddressDto model)
    {
        if (!ModelState.IsValid) return Response("ModelState = false");

        try
        {
            var result = _mapper.Map<Address>(model);

            await _service.Post(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<PostUpdateAddressDto>> Put([FromBody] PostUpdateAddressDto model)
    {
        if (!ModelState.IsValid) return Response("ModelState = false");

        try
        {
            var result = _mapper.Map<Address>(model);

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

            return Ok("successfully deleted");
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }
}
