using ForecastingApp.Services;
using ForecastingApp.Services.Interfaces;
using System;
using Xunit;

namespace ForecastingApp.Tests
{
  public class ServiceTest
  {
    [Fact]
    public async void Check_if_Country_Exist()
    {
      ICountryService countryService = new CountryService();
      var countries = await countryService.GetCountries();
      Assert.NotNull(countries);
    }

  }
}
