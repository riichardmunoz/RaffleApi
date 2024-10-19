using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Raffle.Domain.Entities.Product;
using Raffle.Raffle.Application.DTO_s.Product;

namespace Raffle.Application.Profiles.Product
{
    [ExcludeFromCodeCoverage]
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductDto>()
                .ReverseMap();
        }
    }
}
