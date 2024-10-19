using Raffle.Raffle.Application.DTO_s.Product;

namespace Api.Test.DataBuilder.DTO_s
{
    public class ProductDtoBuilder
    {
        private string _name;
        private string? _description;
        private DateTime _creationDateTime;

        public ProductDtoBuilder()
        {
            _name = "Default Product Name";
            _description = "Default Product Description";
            _creationDateTime = DateTime.UtcNow;
        }

        public ProductDto Build()
            => new()
            {
                Name = _name,
                Description = _description,
                CreationDateTime = _creationDateTime
            };

        public ProductDtoBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ProductDtoBuilder WithDescription(string? description)
        {
            _description = description;
            return this;
        }

        public ProductDtoBuilder WithCreationDateTime(DateTime creationDateTime)
        {
            _creationDateTime = creationDateTime;
            return this;
        }
    }

}
