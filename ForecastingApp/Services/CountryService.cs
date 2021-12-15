using ForecastingApp.Models;
using ForecastingApp.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForecastingApp.Services
{
  public class CountryService : ICountryService
  {
    public async Task<List<Country>> GetCountries()
    {
      var data = await System.IO.File.ReadAllTextAsync("Data/countries.json");
      return JsonConvert.DeserializeObject<List<Country>>(data);
    }
  }
}
