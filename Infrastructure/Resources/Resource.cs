using Polly.Retry;
using Polly;
using Serilog;
using Raffle.Domain.IResources;

namespace Raffle.Infrastructure.Resources
{
    public class Resource : IResource
    {
        private readonly IConfigProvider _configProvider;
        private readonly ILogger _logger;

        private const int EXPONENT = 2;

        public Resource(
            IConfigProvider configProvider,
            ILogger logger)
        {
            _configProvider = configProvider;
            _logger = logger;
        }

        public AsyncRetryPolicy GetRetryPolicy(string method)
        {
            return Policy.Handle<Exception>().
                WaitAndRetryAsync(_configProvider.GetRetryCount(), retryCount => TimeSpan.FromSeconds(Math.Pow(EXPONENT, _configProvider.GetRetrySeconds())), onRetry: (timespan, retryCount) =>
                {
                    _logger.Information($"{method} realizando reintento de ejecucion numero {retryCount}");
                });
        }
    }
}
