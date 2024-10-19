using Raffle.Application.Feature.AssignedNumber.Commands;

namespace Api.Test.DataBuilder.CQRS
{
    public class AssignedNumberCreateCommandBuilder
    {
        private Guid _productId;
        private Guid _userId;

        public AssignedNumberCreateCommandBuilder()
        {
            _productId = Guid.NewGuid();
            _userId = Guid.NewGuid();
        }

        public AssignedNumberCreateCommand Build()
            => new(
                _productId, 
                _userId
            );

        public AssignedNumberCreateCommandBuilder WithProductId(Guid productId)
        {
            _productId = productId;
            return this;
        }

        public AssignedNumberCreateCommandBuilder WithUserId(Guid userId)
        {
            _userId = userId;
            return this;
        }
    }
}
