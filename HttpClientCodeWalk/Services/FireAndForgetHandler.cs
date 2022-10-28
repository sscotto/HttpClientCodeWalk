namespace HttpClientCodeWalk.Services
{
    public class FireAndForgetHandler
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public FireAndForgetHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task Execute<T>(Func<T,Task> asyncWork) where T :class
        {
            return Task.Run(async () =>
            {
                try
                {
                    using var scope = _serviceScopeFactory.CreateScope();
                    //Send the records to the service bus
                    var service = scope.ServiceProvider.GetRequiredService<T>();
                    await asyncWork(service);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }
    }
}
