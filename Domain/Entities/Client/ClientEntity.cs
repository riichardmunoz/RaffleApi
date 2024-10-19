using Raffle.Domain.Entities.Base;
using Raffle.Domain.Entities.Product;
using Raffle.Domain.Extensions;

namespace Raffle.Domain.Entities.Client
{
    public class ClientEntity : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow.GetColombiaDateNow();
        public DateTime? UpdateDateTime { get; set; }
        public virtual List<ProductEntity> Products { get; set; } = default!;
    }
}
