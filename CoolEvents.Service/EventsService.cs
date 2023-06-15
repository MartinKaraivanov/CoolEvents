using CoolEvents.Data;
using CoolEvents.Data.Models;
using CoolEvents.Service.Models;
using CoolEvents.Service.Mappings;

namespace CoolEvents.Service;

internal class EventsService : IEventsService
{
    private readonly IRepository<Event> _eventRepository;

    public EventsService(IRepository<Event> eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<EventDto> CreateEventAsync(EventDto eventDto)
    {
        Event @event = eventDto.ToEntity();

        var newEvent = await _eventRepository.AddAsync(@event);

        return newEvent.ToDto();
    }

    public IEnumerable<EventDto> GetAllEvents()
    {
        var events = _eventRepository.RetrieveAll().ToList();

        return events.Select(x => x.ToDto());
    }

    public async Task<EventDto> UpdateEventAsync(EventDto eventDto)
    {
        var @event = _eventRepository.RetrieveAll().SingleOrDefault(x => x.Id == eventDto.Id);

        if (@event == null)
        {
            throw new ArgumentException("Does not exist");
        }

        @event.Name = eventDto.Name;
        @event.Description = eventDto.Description;
        @event.PhotoUrl = eventDto.PhotoUrl;
        @event.Date = eventDto.Date;

        var newEvent = await _eventRepository.EditAsync(@event);

        return newEvent.ToDto();
    }

    public async Task DeleteEventAsync(Guid id)
    {
        var @event = _eventRepository.RetrieveAll().SingleOrDefault(x => x.Id == id);

        if (@event == null)
        {
            throw new ArgumentException("Does not exist");
        }

        await _eventRepository.RemoveAsync(@event);
    }
}
