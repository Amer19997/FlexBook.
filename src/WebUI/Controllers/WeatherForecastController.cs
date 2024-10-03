using Microsoft.AspNetCore.Mvc;
using Waqfi.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace Waqfi.WebUI.Controllers;
public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}
