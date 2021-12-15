using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ForecastingApp.Services.Interfaces
{
  public interface IHttpClientProvider
  {
    Task<HttpResponseMessage> GetAsync(string requestUri);
  }
}
