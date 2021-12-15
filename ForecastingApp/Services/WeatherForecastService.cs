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
    public async Task<WeatherForecast> GetWeather(string City)
    {
      var _url = _configuration.GetValue<string>("api_url");
      var _apiKey = _configuration.GetValue<string>("api_key");
      var strUrl = string.Format(_url, _apiKey, City);
      var response = await _httpClient.GetAsync(strUrl);
      var data = await response.Content.ReadAsStringAsync();
      var result = JsonConvert.DeserializeObject<WeatherForecast>(data);
      return result;
    }
  }
}
