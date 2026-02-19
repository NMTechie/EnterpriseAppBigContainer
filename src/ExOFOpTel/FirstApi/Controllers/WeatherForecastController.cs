using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory httpClientFactory) : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger = logger;
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Generating weather forecast data.");
        var client = _httpClientFactory.CreateClient();
        var apiUrl = "https://localhost:7134/WeatherForecast";
        HttpResponseMessage response = await client.GetAsync(apiUrl);
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadAsStringAsync();
            // Deserialize/handle the data as needed, e.g.:
            // var result = JsonConvert.DeserializeObject<YourModel>(data);
            return Content(data); // Just as an example
        }
        else
        {
            _logger.LogError("Failed to call external API: {StatusCode}", response.StatusCode);
            return StatusCode((int)response.StatusCode, "Error calling external API");
        }
    }
}
