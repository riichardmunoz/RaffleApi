using System.ComponentModel.DataAnnotations;
using MediatR;
using Raffle.Raffle.Application.DTO_s.Product;

namespace Raffle.Application.Feature.Product.Commands
{
    public record ProductCreateCommand(
        [Required] string Name, 
        string? Description,
        [Required] Guid ClientId
    ) : IRequest<ProductDto>;
}
