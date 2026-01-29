using Microsoft.AspNetCore.Mvc;

namespace WarningApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarningController : ControllerBase
{       
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Warning from controller!");
    }

    [HttpGet("details")]
    public IActionResult GetDetails()
    {
        return Ok(new
        {
            Message = "Warning details",
            Level = "High"
        });
    }
}
