using Api.Test.DataBuilder.CQRS;
using Api.Test.DataBuilder.DTO_s;
using MediatR;
using NSubstitute;
using Raffle.Api.Controllers;

namespace Api.Test
{
    public class ProductControllerTest
    {
        private readonly ProductController _controller;
        private readonly IMediator _mediator;

        public ProductControllerTest()
        {
            _mediator = Substitute.For<IMediator>();
            _controller = new ProductController(_mediator);
        }

        [Fact]
        public async Task CreateProductAsync_ValidCommand_ShouldReturnProductDto()
        {
            // Arrange
            var command = new ProductCreateCommandBuilder()
                .Build();

            var expectedDto = new ProductDtoBuilder()
                .Build();

            _mediator.Send(command)
                .Returns(expectedDto);

            // Act
            var result = await _controller
                .CreateProductAsync(command);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDto.Name, result.Name);
            Assert.Equal(expectedDto.Description, result.Description);
            await _mediator.Received(1)
                .Send(command);
        }
    }
}
