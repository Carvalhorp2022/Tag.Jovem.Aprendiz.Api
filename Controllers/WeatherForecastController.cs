using Microsoft.AspNetCore.Mvc;

namespace Tag.Jovem.Aprendiz.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /*
     *  é um Controlador de previsão do tempo, possuem parâmetros como "Congelante", "Frio", "Suave", "Quente", não sei o que é "Balso", "Suaquente", "Estimulante", "Escaldante" faço uma ideia, Mas não consegui identificar como seria esse controle, por exemplo qual é a temperatura que seria considerada como FRIO.
     */
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}