using Raffle.Domain.Entities.Base;
using Raffle.Domain.Entities.Product;
using Raffle.Domain.Entities.User;
using Raffle.Domain.Extensions;

namespace Raffle.Domain.Entities.AssignedNumber
{
    public class AssignedNumberEntity : BaseEntity<Guid>
    {
        public string Number { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow.GetColombiaDateNow();
        public DateTime? UpdateDateTime { get; set; }
        public virtual ProductEntity Product { get; set; } = default!;
        public virtual UserEntity User { get; set; } = default!;
    }
}
