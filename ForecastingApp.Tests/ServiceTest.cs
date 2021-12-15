using ForecastingApp.Services;
using ForecastingApp.Services.Interfaces;
using System;
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

  }
}
