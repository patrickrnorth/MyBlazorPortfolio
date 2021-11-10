using AutoMapper;
using Shared.Models;

namespace Server.Data;

internal sealed class DTOMappings : Profile
{
    public DTOMappings()
    {
        CreateMap<BarrierPostPhaseException, PostDTO>().ReverseMap();
    }
}


