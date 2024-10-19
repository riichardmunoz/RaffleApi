using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raffle.Application.DTO_s.AssignedNumber;
using Raffle.Application.Feature.AssignedNumber.Commands;

namespace Raffle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AssignedNumberController
    {
        private readonly IMediator mediator;

        public AssignedNumberController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost()]
        public async Task<AssignedNumberDto> CreateAssignedNumberAsync(
            [FromBody] AssignedNumberCreateCommand command
        )
        {
            return await mediator.Send(command);
        }
    }
}
