using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Raffle.Application.DTO_s.AssignedNumber;
using Raffle.Domain.Entities.AssignedNumber;

namespace Raffle.Application.Profiles.AssignedNumber
{
    [ExcludeFromCodeCoverage]
    public class AssignedNumberProfile : Profile
    {
        public AssignedNumberProfile()
        {
            CreateMap<AssignedNumberEntity, AssignedNumberDto>()
                .ReverseMap();
        }
    }
}
