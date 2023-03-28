using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Data.Dto.Address;
using SchoolAPI.Data.Interface;

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
}
