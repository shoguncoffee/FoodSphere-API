using Food.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food.Controllers;

[ApiController]
[Route("food")]
public class FoodController(ILogger<FoodController> logger) : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    private readonly ILogger<FoodController> _logger = logger;

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<FoodItem> Get()
    {
        return [.. Enumerable.Range(1, 5).Select(index => new FoodItem
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })];
    }
}
