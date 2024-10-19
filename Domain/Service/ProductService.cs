using Raffle.Domain.Entities.Product;
using Raffle.Domain.Enums;
using Raffle.Domain.Exceptions;
using Raffle.Domain.Extensions;
using Raffle.Domain.Helpers;
using Raffle.Domain.IService;
using Raffle.Raffle.Domain.Exceptions;
using Raffle.Raffle.Domain.Ports;

namespace Raffle.Domain.Service
{
    [DomainService]
    public class ProductService : IProductService
    {
        private IQueryWrapper _queryWrapper;

        public ProductService(
            IQueryWrapper queryWrapper
        )
        {
            _queryWrapper = queryWrapper;
        }

        public async Task<ProductEntity> CreateProductAsync(
            ProductEntity request
        )
        {
            request.ValidateNullObject(
                string.Format(
                    MessagesExceptions.ArgumentNullOrEmpty, 
                    nameof(request)
                )
            );

            request.ClientId.CheckValidGuid();

            try
            {
                await _queryWrapper.ExecuteAsync(
                    ItemsMessageConstants.CreateProductRegistry
                        .GetDescription(),
                        new
                        {
                            Id = Guid.NewGuid(),
                            request.Name,
                            request.Description,
                            request.ClientId,
                            request.CreationDateTime,
                            request.UpdateDateTime
                        }
                );

                return request;
            }
            catch (Exception)
            {
                throw new RestClientException(
                    string.Format(
                        MessagesExceptions.CreateProductError,
                        request.Name
                    )
                );
            }
        }
    }
}
