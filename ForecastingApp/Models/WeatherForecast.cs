using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForecastingApp.Models
{
  public class WeatherForecast
  {
    public Coord coord { get; set; }
    public List<Weather> weather { get; set; }
    public string @base { get; set; }
    public Main main { get; set; }
    public Main celcius
    {
      get
      {
        return new Main
        {
          temp = (main.temp - 32) * 5 / 9,
          feels_like = (main.feels_like - 32) * 5 / 9,
          temp_min = (main.temp_min - 32) * 5 / 9,
          temp_max = (main.temp_max - 32) * 5 / 9,
          pressure = main.pressure,
          humidity = main.humidity
        };
      }
    }
    public int visibility { get; set; }
    public Wind wind { get; set; }
    public Clouds clouds { get; set; }
    public int dt { get; set; }
    public Sys sys { get; set; }
    public int timezone { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public int cod { get; set; }
  }
}
