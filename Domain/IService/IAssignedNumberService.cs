using Raffle.Domain.DTO_s.AssignedNumber;
using Raffle.Domain.Entities.AssignedNumber;

namespace Raffle.Domain.IService
{
    public interface IAssignedNumberService
    {
        Task<AssignedNumberEntity> CreateAssignedNumberAsync(
             AssignedNumberCreateRequestDto request
         );
    }
}
