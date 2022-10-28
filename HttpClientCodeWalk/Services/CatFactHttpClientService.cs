using HttpClientCodeWalk.Models;
using System.Text.Json;

namespace HttpClientCodeWalk.Services
{
    public interface ICatFactHttpClientService
    {
        Task<CatFactResponse> GetResponse(string length);
    }
    public class CatFactHttpClientService : ICatFactHttpClientService
    {
        private readonly HttpClient _httpClient;

        public CatFactHttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CatFactResponse> GetResponse(string length)
        {
            var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}fact?max_length={length}");            
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<CatFactResponse>(responseBody)!;
        }
    }
}
