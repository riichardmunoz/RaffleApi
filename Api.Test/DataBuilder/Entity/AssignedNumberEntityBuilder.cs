using Raffle.Domain.Entities.AssignedNumber;
using Raffle.Domain.Entities.Product;
using Raffle.Domain.Entities.User;

namespace Api.Test.DataBuilder.Entity
{
    public class AssignedNumberEntityBuilder
    {
        private string _number;
        private Guid _userId;
        private Guid _productId;
        private DateTime _creationDateTime;
        private DateTime? _updateDateTime;
        private ProductEntity _product;
        private UserEntity _user;

        public AssignedNumberEntityBuilder()
        {
            _number = "00001";
            _userId = Guid.NewGuid();
            _productId = Guid.NewGuid();
            _creationDateTime = DateTime.UtcNow;
            _updateDateTime = null;
            _product = new ProductEntity();
            _user = new UserEntity();
        }

        public AssignedNumberEntity Build()
        {
            return new AssignedNumberEntity
            {
                Number = _number,
                UserId = _userId,
                ProductId = _productId,
                CreationDateTime = _creationDateTime,
                UpdateDateTime = _updateDateTime,
                Product = _product,
                User = _user
            };
        }

        public AssignedNumberEntityBuilder WithNumber(string number)
        {
            _number = number;
            return this;
        }

        public AssignedNumberEntityBuilder WithUserId(Guid userId)
        {
            _userId = userId;
            return this;
        }

        public AssignedNumberEntityBuilder WithProductId(Guid productId)
        {
            _productId = productId;
            return this;
        }

        public AssignedNumberEntityBuilder WithCreationDateTime(DateTime creationDateTime)
        {
            _creationDateTime = creationDateTime;
            return this;
        }

        public AssignedNumberEntityBuilder WithUpdateDateTime(DateTime? updateDateTime)
        {
            _updateDateTime = updateDateTime;
            return this;
        }

        public AssignedNumberEntityBuilder WithProduct(ProductEntity product)
        {
            _product = product;
            return this;
        }

        public AssignedNumberEntityBuilder WithUser(UserEntity user)
        {
            _user = user;
            return this;
        }
    }
}
