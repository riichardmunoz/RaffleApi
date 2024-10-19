using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raffle.Application.Feature.Product.Commands;
using Raffle.Raffle.Application.DTO_s.Product;

namespace Raffle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost()]
        public async Task<ProductDto> CreateProductAsync(
            [FromBody] ProductCreateCommand command
        )
        {
            return await mediator.Send(command);
        }
    }
}
