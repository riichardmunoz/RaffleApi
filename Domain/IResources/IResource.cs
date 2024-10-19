using Polly.Retry;

namespace Raffle.Domain.IResources
{
    public interface IResource
    {
        AsyncRetryPolicy GetRetryPolicy(string method);
    }
}
