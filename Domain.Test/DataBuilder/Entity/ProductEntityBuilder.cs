using Raffle.Domain.Entities.AssignedNumber;
using Raffle.Domain.Entities.Client;
using Raffle.Domain.Entities.Product;

namespace Domain.Test.DataBuilder.Entity
{
    public class ProductEntityBuilder
    {
        private string _name;
        private string? _description;
        private Guid _clientId;
        private DateTime _creationDateTime;
        private DateTime? _updateDateTime = null;
        private List<AssignedNumberEntity> _assignedNumbers;
        private ClientEntity _client;

        public ProductEntityBuilder()
        {
            _name = "Default Product Name";
            _description = "Default Description";
            _clientId = Guid.NewGuid();
            _creationDateTime = DateTime.UtcNow;
            _updateDateTime = null;
            _assignedNumbers = new List<AssignedNumberEntity>();
            _client = new ClientEntity();
        }

        public ProductEntity Build()
        {
            return new ProductEntity
            {
                Name = _name,
                Description = _description,
                ClientId = _clientId,
                CreationDateTime = _creationDateTime,
                UpdateDateTime = _updateDateTime,
                AssignedNumbers = _assignedNumbers,
                Client = _client
            };
        }

        public ProductEntityBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ProductEntityBuilder WithDescription(string? description)
        {
            _description = description;
            return this;
        }

        public ProductEntityBuilder WithClientId(Guid clientId)
        {
            _clientId = clientId;
            return this;
        }

        public ProductEntityBuilder WithCreationDateTime(DateTime creationDateTime)
        {
            _creationDateTime = creationDateTime;
            return this;
        }

        public ProductEntityBuilder WithUpdateDateTime(DateTime? updateDateTime)
        {
            _updateDateTime = updateDateTime;
            return this;
        }

        public ProductEntityBuilder WithAssignedNumbers(List<AssignedNumberEntity> assignedNumbers)
        {
            _assignedNumbers = assignedNumbers;
            return this;
        }

        public ProductEntityBuilder WithClient(ClientEntity client)
        {
            _client = client;
            return this;
        }
    }
}
