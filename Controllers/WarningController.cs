using Microsoft.AspNetCore.Mvc;
using WarningApi.Business;

namespace WarningApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarningController : ControllerBase
{       
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Kontrollern funkar:)");
    }

    [HttpGet("{city}/{date}")]
    public IActionResult GetDetails(string city, DateOnly date)
    {
        var service = new WarningService();
        return Ok
        (
            service.GetWarning(DebugWeatherInfo(city, date))
        );
    }

    private WeatherInfo DebugWeatherInfo(string city, DateOnly date)
    {
        return new WeatherInfo()
        {
            City = city,
            Date = date,
            WindSpeed = Random.Shared.Next(0, 100),
            Temperature = Random.Shared.Next(-100, 100),
            Description = "Slumpmässigt genererat debug väder"
        };
    }
}
