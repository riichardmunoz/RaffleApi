using Raffle.Domain.Entities.AssignedNumber;
using Raffle.Domain.Entities.Base;
using Raffle.Domain.Entities.Client;
using Raffle.Domain.Extensions;

namespace Raffle.Domain.Entities.Product
{
    public class ProductEntity : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid ClientId { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow.GetColombiaDateNow();
        public DateTime? UpdateDateTime { get; set; }
        public virtual List<AssignedNumberEntity> AssignedNumbers { get; set; } = default!;
        public virtual ClientEntity Client { get; set; } = default!;
    }
}
