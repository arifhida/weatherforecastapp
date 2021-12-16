using ForecastingApp.Models;
using ForecastingApp.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ForecastingApp.Services
{
  public class WeatherForecastService : IWeatherForecastService
  {
    private readonly IHttpClientProvider _httpClient;
    private readonly IConfiguration _configuration;
    public WeatherForecastService(IConfiguration configuration, IHttpClientProvider httpClient)
    {
      _httpClient = httpClient;
      _configuration = configuration;
    }

    public double FahrenheitToCelcius(double f)
    {
      return Math.Round((f - 32) * 5 / 9,2);
    }

    public async Task<WeatherForecast> GetWeather(string City)
    {
      var _url = _configuration.GetValue<string>("api_url");
      var _apiKey = _configuration.GetValue<string>("api_key");
      var strUrl = string.Format(_url, _apiKey, City);
      var response = await _httpClient.GetAsync(strUrl);
      var data = await response.Content.ReadAsStringAsync();
      var result = JsonConvert.DeserializeObject<WeatherForecast>(data);
      result.celcius = new Main();
      result.celcius.temp = FahrenheitToCelcius(result.main.temp);
      result.celcius.feels_like = FahrenheitToCelcius(result.main.feels_like);
      result.celcius.temp_min = FahrenheitToCelcius(result.main.temp_min);
      result.celcius.temp_max = FahrenheitToCelcius(result.main.temp_max);
      result.celcius.pressure = result.main.pressure;
      result.celcius.humidity = result.main.humidity;
      return result;
    }
  }
}
