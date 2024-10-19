using Raffle.Domain.Extensions;

namespace Raffle.Raffle.Application.DTO_s.Product
{
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow.GetColombiaDateNow();
    }
}
