using AutoMapper;
using MediatR;
using Raffle.Application.DTO_s.AssignedNumber;
using Raffle.Domain.DTO_s.AssignedNumber;
using Raffle.Domain.IService;

namespace Raffle.Application.Feature.AssignedNumber.Commands
{
    public class AssignedNumberCreateCommandHandler 
        : IRequestHandler<AssignedNumberCreateCommand, AssignedNumberDto>
    {
        private readonly IAssignedNumberService _service;
        private readonly IMapper _mapper;

        public AssignedNumberCreateCommandHandler(
            IAssignedNumberService service, 
            IMapper mapper
        )
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<AssignedNumberDto> Handle(
            AssignedNumberCreateCommand command, 
            CancellationToken cancellationToken
        )
        {
            var request = new AssignedNumberCreateRequestDto()
            {
                ProductId = command.ProductId,
                UserId = command.UserId
            };

            return _mapper.Map<AssignedNumberDto>(
                await _service.CreateAssignedNumberAsync(request)
            );
        }
    }
}
