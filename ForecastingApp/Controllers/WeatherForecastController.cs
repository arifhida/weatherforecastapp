using ForecastingApp.Models;
using ForecastingApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForecastingApp.Controllers
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
    private readonly ICountryService _countryService;
    private readonly ICityService _cityService;
    private readonly IWeatherForecastService _weatherForecastService;
    public WeatherForecastController(ILogger<WeatherForecastController> logger, ICountryService countryService,
      ICityService cityService, IWeatherForecastService weatherForecastService)
    {
      _logger = logger;
      _countryService = countryService;
      _cityService = cityService;
      _weatherForecastService = weatherForecastService;

    }
    [HttpGet("countries")]
    public async Task<IEnumerable<Country>> GetCountries()
    {
      return await _countryService.GetCountries();
    }

    [HttpGet("cities/{countrycode}")]
    public async Task<IEnumerable<City>> GetCities(string countrycode)
    {
      return await _cityService.GetCities(countrycode);
    }

    [HttpGet("forecast/{city}")]
    public async Task<WeatherForecast> GetWeather(string city)
    {
      return await _weatherForecastService.GetWeather(city);
    }
    //[HttpGet]
    //public IEnumerable<WeatherForecast> Get()
    //{
    //  var rng = new Random();
    //  return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //  {
    //    Date = DateTime.Now.AddDays(index),
    //    TemperatureC = rng.Next(-20, 55),
    //    Summary = Summaries[rng.Next(Summaries.Length)]
    //  })
    //  .ToArray();
    //}
  }
}
