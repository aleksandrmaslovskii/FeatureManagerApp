using FeatureManagerApp.Models;
using FeatureManagerApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FeatureManagerApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    [HttpGet(Name = "GetWeather")]
    public async Task<WeatherResponse> Get( 
        [FromServices] IWeatherService weatherService, 
        [FromQuery] string city)
    {
        return await weatherService.GetByCityAsync(city);
    } 
}