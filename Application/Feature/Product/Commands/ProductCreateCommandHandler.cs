using AutoMapper;
using MediatR;
using Raffle.Domain.Entities.Product;
using Raffle.Domain.IService;
using Raffle.Raffle.Application.DTO_s.Product;

namespace Raffle.Application.Feature.Product.Commands
{
    public class ProductCreateCommandHandler
        : IRequestHandler<ProductCreateCommand, ProductDto>
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductCreateCommandHandler(
            IProductService service, 
            IMapper mapper
        )
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(
            ProductCreateCommand command, 
            CancellationToken cancellationToken
        )
        {
            var request = new ProductEntity()
            {
                Name = command.Name,
                Description = command.Description,
                ClientId = command.ClientId
            };

            return _mapper.Map<ProductDto>(
                await _service.CreateProductAsync(request)
            );
        }
    }
}
