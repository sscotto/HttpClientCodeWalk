using HttpClientCodeWalk.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HttpClientCodeWalk.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FireAndForgetController : ControllerBase
    {
        private readonly ISlowService _slowService;
        private readonly FireAndForgetHandler _fireAndForgetHandler;

        public FireAndForgetController(ISlowService slowService, FireAndForgetHandler fireAndForgetHandler)
        {
            this._slowService = slowService;
            this._fireAndForgetHandler = fireAndForgetHandler;
        }

        [HttpGet]
        [ActionName("SlowTask")]
        public async Task<IActionResult> SlowTask()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            await _slowService.SlowTask();
            sw.Stop();
            return Ok($"Slow Taks Finished in {sw.ElapsedMilliseconds}ms");
        }

        [HttpGet]
        [ActionName("FireAndForgetTask")]
        public async Task<IActionResult> FireAndForget()
        {        
            _ = _fireAndForgetHandler.Execute<ISlowService>(async slowService =>
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                await _slowService.SlowTask();
                sw.Stop();
                Debug.WriteLine($"Other Thread Slow Taks finished in {sw.ElapsedMilliseconds}ms");
            });

            return Ok();
        }
    }
}
