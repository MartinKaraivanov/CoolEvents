using AutoMapper;
using CoolEvents.Data.Models;
using CoolEvents.Service.Models;

namespace CoolEvents.Service.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AppUser, UserDto>();
        CreateMap<Event, EventDto>();
        CreateMap<Ticket, TicketDto>();
    }
}
