using Microsoft.AspNetCore.Mvc;
using OpenExam.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace OpenExam.WebUI.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}
