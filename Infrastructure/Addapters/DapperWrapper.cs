using System.ComponentModel;
using System.Data;
using System.Globalization;
using Dapper;
using Raffle.Raffle.Domain.Ports;

namespace Raffle.Raffle.Infrastructure.Addapters
{
    public class DapperWrapper : IQueryWrapper
    {
        private readonly IDbConnection _connection;
        private readonly ComponentResourceManager _componentResourceManager;

        public DapperWrapper(IDbConnection connection)
        {
            _connection = connection;
            _componentResourceManager = new(typeof(Constants.MessageConstants));
        }

        public async Task ExecuteAsync(string resourceItemDescription, object parameters)
        {
            string query = GetQuery(resourceItemDescription);

            await _connection.ExecuteAsync(query, parameters);
        }

        private string GetQuery(string resourceItemDescription, object[]? args = null)
        {
            if (args is null)
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    _componentResourceManager.GetString(resourceItemDescription)!
                );
            }

            return string.Format(
                CultureInfo.InvariantCulture,
                _componentResourceManager.GetString(resourceItemDescription)!,
                args!
            );
        }
    }
}
