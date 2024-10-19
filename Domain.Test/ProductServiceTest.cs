using Domain.Test.DataBuilder.Entity;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Raffle.Domain.Entities.Product;
using Raffle.Domain.Exceptions;
using Raffle.Domain.Service;
using Raffle.Raffle.Domain.Ports;

namespace Domain.Test
{
    public class ProductServiceTests
    {
        private readonly IQueryWrapper _queryWrapper;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _queryWrapper = Substitute.For<IQueryWrapper>();
            _productService = new ProductService(_queryWrapper);
        }

        [Fact]
        public async Task CreateProductAsync_Ok()
        {
            // Arrange
            var product = new ProductEntityBuilder()
                .Build();

            // Act
            var result = await _productService
                .CreateProductAsync(product);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.Description, result.Description);
            Assert.Equal(product.ClientId, result.ClientId);
            await _queryWrapper.Received(1)
                .ExecuteAsync(
                    Arg.Any<string>(),
                    Arg.Any<object>()
                );
        }

        [Fact]
        public async Task CreateProductAsync_NullProduct_ThrowsRestClientException()
        {
            // Arrange
            ProductEntity request = null!;
            string messageException = "El parámetro request no puede ser nulo ni estár vacio.";

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ValidationException>(
                () => _productService.CreateProductAsync(request)
            );

            Assert.Equal(messageException, exception.Message);
        }

        [Fact]
        public async Task CreateProductAsync_QueryWrapperThrowsException_ThrowsRestClientException()
        {
            // Arrange
            var product = new ProductEntityBuilder()
                .Build();
            string messageException = $"Ocurrió un error tratando de crear el producto {product.Name}";

            _queryWrapper.ExecuteAsync(
                Arg.Any<string>(), 
                Arg.Any<object>()
            ).Throws(new Exception("Database error"));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<RestClientException>(
                () => _productService.CreateProductAsync(product)
            );

            Assert.Contains(messageException, exception.Message);
        }
    }
}
