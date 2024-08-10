using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace practice_web_apis.Controllers
{
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
        private IEnumerable<WeatherForecast> getWeatherData()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var weatherData = this.getWeatherData();
            return Ok(weatherData);
        }

        [HttpGet("{summary}", Name ="GetWeatherBySummary")]
        public IActionResult getWeatherBySummary([FromRoute] string summary) { 
            var weatherData = this.getWeatherData();
            WeatherForecast? data = weatherData.FirstOrDefault(data => data.Summary == summary);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
