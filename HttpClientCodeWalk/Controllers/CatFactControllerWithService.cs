using HttpClientCodeWalk.Models;
using HttpClientCodeWalk.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HttpClientCodeWalk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatFactControllerWithService : ControllerBase
    {
        private readonly ICatFactHttpClientService _catFactHttpClientService;

        public CatFactControllerWithService(ICatFactHttpClientService catFactHttpClientService)
        {
            _catFactHttpClientService = catFactHttpClientService;
        }   

        [HttpGet(Name = "NewCatFactWithServiceInjected")]
        public async Task<CatFactResponse> Get(string length)
        {
            var response = await _catFactHttpClientService.GetResponse(length);
            return response;

        }
    }
}
