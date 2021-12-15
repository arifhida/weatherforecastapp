using ForecastingApp.Models;
using ForecastingApp.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForecastingApp.Services
{
  public class CityService : ICityService
  {
    public async Task<List<City>> GetCities(string CountryCode)
    {
      var data = await System.IO.File.ReadAllTextAsync("Data/cities.json");
      var cities =  JsonConvert.DeserializeObject<List<City>>(data);
      return cities.Where(x => x.CountryCode == CountryCode).ToList();
    }
  }
}
