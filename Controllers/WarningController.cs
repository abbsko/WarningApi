using Microsoft.AspNetCore.Mvc;
using WarningApi.Business;

namespace WarningApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarningController : ControllerBase
{    
    private readonly IHttpClientFactory httpClientFactory;
    private readonly WarningService service;

    private const string BaseWeatherApi = "http://10.27.1.180:5266";

    public WarningController(IHttpClientFactory httpClientFactory, WarningService service)
    {
        this.httpClientFactory = httpClientFactory;
        this.service = service;
    }   

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Lägg Till /Stad/Datum för en varning");
    }

    [HttpGet("{city}/{date}")]
    public async Task<IActionResult> GetDetails(string city, DateOnly date)
    {
        var info = await GetWeatherInfo(city, date);

        if (info == null)
        {
            return NotFound($"Kunde inte hitta väderrapport för {city} under {date}");
        }

        return Ok( service.GetWarning(info) );
    }

    private async Task<WeatherInfo?> GetWeatherInfo(string city, DateOnly date)
    {
        var client = httpClientFactory.CreateClient();
        var apiUrl = $"{BaseWeatherApi}/api/weather/?city={city}";

        try
        {
            var weatherInfo = await client.GetFromJsonAsync<WeatherInfo>(apiUrl);
            return weatherInfo;
        }
        catch (System.Exception)
        {
            return null;
        }
    }
}
