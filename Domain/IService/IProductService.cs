using Raffle.Domain.Entities.Product;

namespace Raffle.Domain.IService
{
    public interface IProductService
    {
        Task<ProductEntity> CreateProductAsync(
             ProductEntity request
         );
    }
}
