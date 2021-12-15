using ForecastingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForecastingApp.Services.Interfaces
{
  public interface ICityService
  {
    Task<List<City>> GetCities(string CountryCode);
  }
}
