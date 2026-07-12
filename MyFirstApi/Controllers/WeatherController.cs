using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class WeatherController: ControllerBase
{
    private static readonly string[] Summarise = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1,8).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            Summarise[Random.Shared.Next(Summarise.Length)]

        ))
        .ToArray();
    }

[HttpGet("{id}")]
    public ActionResult<WeatherForecast> GetById(int id)
    {
        if (id < 1 || id >8)
        {
            return NotFound();
        }
        var forecast = new WeatherForecast
        ( 
            DateOnly.FromDateTime(DateTime.Now.AddDays(id)),
            Random.Shared.Next(-20, 55),
            Summarise[Random.Shared.Next(Summarise.Length)]
        );
        return Ok(forecast);
       
    }
}
    public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

