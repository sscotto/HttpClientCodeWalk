using HttpClientCodeWalk.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HttpClientCodeWalk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WrongCatFactController : ControllerBase
    {    
        [HttpGet(Name = "NewCatFact")]
        public async Task<CatFactResponse> Get()
        {
            using var httpClient = new HttpClient() { BaseAddress = new Uri("https://catfact.ninja/fact?max_length=100") };
            var response = await httpClient.GetAsync("https://catfact.ninja/fact?max_length=100");
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<CatFactResponse>(responseBody)!;

        }
    }
}
