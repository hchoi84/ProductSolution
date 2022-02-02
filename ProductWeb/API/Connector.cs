using Newtonsoft.Json.Linq;
using ProductWeb.Models;
using System.Net.Http.Headers;

namespace ProductWeb.API
{
  public class Connector : IConnector
  {
    private const string _url = @"https://localhost:7076/swagger/index.html";
    private HttpClient _client;

    public HttpClient Client
    {
      get { return _client; }
    }

    public Connector()
    {
      _client = new HttpClient();
      _client.BaseAddress = new Uri(_url);
      _client.DefaultRequestHeaders.Accept.Clear();
      _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<List<Product>> GetAllAsync()
    {
      HttpResponseMessage res = await _client.GetAsync("/product/getall");
      string content = await res.Content.ReadAsStringAsync();

      if (res.IsSuccessStatusCode)
      {
        return JArray.Parse(content).ToObject<List<Product>>();
      }
      else
      {
        throw new Exception(content);
      }
    }


  }
}
