using ForecastingApp.Models;
using ForecastingApp.Services;
using ForecastingApp.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ForecastingApp.Tests
{
  public class ServiceTest
  {
    [Fact]
    public async void Check_if_Country_Not_Null()
    {
      ICountryService countryService = new CountryService();
      var countries = await countryService.GetCountries();
      Assert.NotNull(countries);
    }

    [Fact]
    public async void Check_if_city_Not_Null()
    {
      ICityService cityService = new CityService();
      var cities = await cityService.GetCities("UK");

      Assert.True(cities.Count > 0);
    }
    [Theory]
    [InlineData(68,20)]
    [InlineData(75.2,24)]
    public void Check_if_celcius_true(double f, double c)
    {
      var myConfiguration = new Dictionary<string, string>();
      myConfiguration.Add("api_url", "https://api.openweathermap.org/data/2.5/weather?q={1}&appid={0}&units=imperial");
      myConfiguration.Add("api_key", "566344d5cd2efdb38b2c3d1f3cb3dc3f");

      var configuration = new ConfigurationBuilder()
          .AddInMemoryCollection(myConfiguration)
          .Build();
      IHttpClientProvider httpClient = new FakeHttpclientProvider();
      IWeatherForecastService service = new WeatherForecastService(configuration, httpClient);
      var result = service.FahrenheitToCelcius(f);
      Assert.Equal(c, result);
    }

    [Fact]
    public async void Check_weather_exist()
    {
      var myConfiguration = new Dictionary<string, string>();
      myConfiguration.Add("api_url", "https://api.openweathermap.org/data/2.5/weather?q={1}&appid={0}&units=imperial");
      myConfiguration.Add("api_key", "566344d5cd2efdb38b2c3d1f3cb3dc3f");

      var configuration = new ConfigurationBuilder()
          .AddInMemoryCollection(myConfiguration)
          .Build();
      IHttpClientProvider httpClient = new FakeHttpclientProvider();
      IWeatherForecastService service = new WeatherForecastService(configuration, httpClient);
      var result = await service.GetWeather("London");
      Assert.NotNull(result);
    }

  }

  public class FakeHttpclientProvider : IHttpClientProvider
  {
    public async Task<HttpResponseMessage> GetAsync(string requestUri)
    {
      var content = "{\"coord\":{\"lon\":-0.1257,\"lat\":51.5085},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04n\"}],\"base\":\"stations\",\"main\":{\"temp\":51.57,\"feels_like\":50.23,\"temp_min\":49.17,\"temp_max\":53.01,\"pressure\":1036,\"humidity\":81},\"visibility\":10000,\"wind\":{\"speed\":3.44,\"deg\":258,\"gust\":3.53},\"clouds\":{\"all\":89},\"dt\":1639621050,\"sys\":{\"type\":2,\"id\":2019646,\"country\":\"GB\",\"sunrise\":1639641643,\"sunset\":1639669905},\"timezone\":0,\"id\":2643743,\"name\":\"London\",\"cod\":200}";
      var fakeResponse = new HttpResponseMessage(HttpStatusCode.OK);
      fakeResponse.Content = new StringContent(content,System.Text.Encoding.UTF8, "application/json");
      await Task.Delay(100);
      return fakeResponse;
    }
  }
}
