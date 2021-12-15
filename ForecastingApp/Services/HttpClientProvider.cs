using ForecastingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ForecastingApp.Services
{
  public class HttpClientProvider : IHttpClientProvider
  {
    private readonly HttpClient _httpClient;
    public HttpClientProvider()
    {
      _httpClient = new HttpClient();
    }
    public async Task<HttpResponseMessage> GetAsync(string requestUri)
    {
      return await _httpClient.GetAsync(requestUri);
    }
  }
}
