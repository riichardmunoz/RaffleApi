using Raffle.Domain.Entities.AssignedNumber;
using Raffle.Domain.Entities.Base;
using Raffle.Domain.Extensions;

namespace Raffle.Domain.Entities.User
{
    public class UserEntity : BaseEntity<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow.GetColombiaDateNow();
        public DateTime? UpdateDateTime { get; set; }
        public virtual List<AssignedNumberEntity> AssignedNumbers { get; set; } = default!;
    }
}
