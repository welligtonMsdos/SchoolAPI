using Microsoft.AspNetCore.Mvc;

namespace SchoolAPI.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected BaseController() { }

    protected new ActionResult Response(object result)
    {
        if(result.ToString().Contains("error") || 
           result.ToString().Contains("mapping") ||
           result.ToString().Contains("Sequence") ||
           result.ToString().Contains("cannot") ||
           result.ToString().Contains("severed") ||
           result.ToString().Contains("Id exists"))
        {
            return Ok(new
            {
                Success = false,
                Message = "Error",
                Data = result
            });
        }

        return Ok(new
        {
            Success = true,
            Message = "Success",
            Data = result
        });
    }
}
