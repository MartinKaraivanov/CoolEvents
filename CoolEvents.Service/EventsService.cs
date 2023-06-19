using CoolEvents.Data;
using CoolEvents.Data.Models;
using CoolEvents.Service.Models;
using CoolEvents.Service.Mappings;
using AutoMapper;

namespace CoolEvents.Service;

internal class EventsService : IEventsService
{
    private readonly IRepository<Event> _eventRepository;
    private readonly IMapper _mapper;

    public EventsService(IRepository<Event> eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<EventDto> CreateEventAsync(EventDto eventDto)
    {
        Event @event = new Event
        {
            Id = eventDto.Id,
            Name = eventDto.Name,
            Description = eventDto.Description,
            PhotoUrl = eventDto.PhotoUrl,
            Date = eventDto.Date
        };

        var newEvent = await _eventRepository.AddAsync(@event);

        return _mapper.Map<EventDto>(newEvent);
    }

    public IEnumerable<EventDto> GetAllEvents()
    {
        return _eventRepository.RetrieveMappedTo<EventDto>(x => true);
    }

    public IEnumerable<EventDto> GetEventsByNamePart(string namePart)
    {
        return _eventRepository.RetrieveMappedTo<EventDto>(x => x.Name.Contains(namePart));
    }

    public EventDto GetEventById(Guid id)
    {
		var e = _eventRepository.RetrieveMappedTo<EventDto>(x => x.Id == id).SingleOrDefault();

        ArgumentNullException.ThrowIfNull(e);

        return e;
	}

    public async Task<EventDto> UpdateEventAsync(EventDto eventDto)
    {
        var @event = _eventRepository.Retrieve(x => x.Id == eventDto.Id).SingleOrDefault();

        if (@event == null)
        {
            throw new ArgumentException("Does not exist");
        }

        @event.Name = eventDto.Name;
        @event.Description = eventDto.Description;
        @event.PhotoUrl = eventDto.PhotoUrl;
        @event.Date = eventDto.Date;

        var newEvent = await _eventRepository.EditAsync(@event);
         
        return _mapper.Map<EventDto>(newEvent);
    }

    public async Task DeleteEventAsync(Guid id)
    {
        var @event = _eventRepository.Retrieve(x => x.Id == id).SingleOrDefault();

        if (@event == null)
        {
            throw new ArgumentException("Does not exist");
        }

        await _eventRepository.RemoveAsync(@event);
    }
}
