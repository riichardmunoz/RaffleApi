using Microsoft.Extensions.Configuration;
using Raffle.Domain.IResources;

namespace Raffle.Infrastructure.Resources
{
    public class ConfigProvider : IConfigProvider
    {
        private readonly IConfiguration _configuration;

        public ConfigProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region RetryPolicy
        public int GetRetryCount()
        {
            var retryCount = _configuration.GetSection("RetryPolicy:RetryCount").Value;

            if (!int.TryParse(retryCount, out var result))
            {
                throw new InvalidCastException($"El valor de la variable de configuracion RetryCount: {retryCount} no es valido ");
            }

            return result;
        }
        public double GetRetrySeconds()
        {
            var retrySeconds = _configuration.GetSection("RetryPolicy:RetrySeconds").Value;

            if (!double.TryParse(retrySeconds, out var result))
            {
                throw new InvalidCastException($"El valor de la variable de configuracion RetrySeconds: {retrySeconds} no es valido");
            }

            return result;
        }
        #endregion
    }
}
