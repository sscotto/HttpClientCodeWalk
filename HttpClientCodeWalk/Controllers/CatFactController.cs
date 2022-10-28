using HttpClientCodeWalk.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace HttpClientCodeWalk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatFactController : ControllerBase
    {
        private readonly ILogger<CatFactController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public CatFactController(ILogger<CatFactController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet(Name = "NewCatFactCorrectImplementation")]
        public async Task<CatFactResponse> GetCorrect(string length)
        {
            var httpClient = _httpClientFactory.CreateClient("catFactClient");
            var response = await httpClient.GetAsync($"{httpClient.BaseAddress}fact?max_length={length}");
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<CatFactResponse>(responseBody)!;
        }
    }
}