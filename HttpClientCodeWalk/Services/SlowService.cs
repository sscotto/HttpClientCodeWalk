namespace HttpClientCodeWalk.Services
{
    public interface ISlowService
    {
        Task SlowTask();
    }
    public class SlowService : ISlowService
    {
        public async Task SlowTask()
        {
            await Task.Delay(10000);
        }
    }
}
