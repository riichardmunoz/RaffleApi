using System.ComponentModel.DataAnnotations;
using MediatR;
using Raffle.Application.DTO_s.AssignedNumber;

namespace Raffle.Application.Feature.AssignedNumber.Commands
{
    public record AssignedNumberCreateCommand(
        [Required] Guid ProductId, 
        [Required] Guid UserId
    ) : IRequest<AssignedNumberDto>;
}
