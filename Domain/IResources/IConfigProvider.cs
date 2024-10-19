namespace Raffle.Domain.IResources
{
    public interface IConfigProvider
    {
        #region RetryPolicy
        int GetRetryCount();
        double GetRetrySeconds();
        #endregion
    }
}
