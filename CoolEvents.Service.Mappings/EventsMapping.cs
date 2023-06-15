using CoolEvents.Data.Models;
using CoolEvents.Service.Models;
using System.Linq.Expressions;

namespace CoolEvents.Service.Mappings;

public static class EventsMapping
{
    public static Event ToEntity(this EventDto eventDto)
    {
        return new Event
        {
            Id = eventDto.Id,
            Name = eventDto.Name,
            Description = eventDto.Description,
            PhotoUrl = eventDto.PhotoUrl,
            Date = eventDto.Date
        };
    }

    public static EventDto ToDto(this Event @event)
    {
        return new EventDto
        {
            Id = @event.Id,
            Name = @event.Name,
            Description = @event.Description,
            PhotoUrl = @event.PhotoUrl,
            Date = @event.Date
        };
    }
}
