using Raffle.Application.Feature.Product.Commands;

namespace Api.Test.DataBuilder.CQRS
{
    public class ProductCreateCommandBuilder
    {
        private string _name;
        private string? _description;
        private Guid _clientId;

        public ProductCreateCommandBuilder()
        {
            _name = "Default Product Name";
            _description = "Default Product Description";
            _clientId = Guid.NewGuid();
        }

        public ProductCreateCommand Build()
            => new(
                _name,
                _description,
                _clientId
            );

        public ProductCreateCommandBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ProductCreateCommandBuilder WithDescription(string? description)
        {
            _description = description;
            return this;
        }

        public ProductCreateCommandBuilder WithClientId(Guid clientId)
        {
            _clientId = clientId;
            return this;
        }
    }
}
