namespace Raffle.Raffle.Domain.Ports
{
    public interface IQueryWrapper
    {
        Task ExecuteAsync(string resourceItemDescription, object parameters);
    }
}
