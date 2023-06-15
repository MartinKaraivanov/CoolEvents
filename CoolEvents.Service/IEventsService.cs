using CoolEvents.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolEvents.Service;

public interface IEventsService
{
    Task<EventDto> CreateEventAsync(EventDto eventDto);
    IEnumerable<EventDto> GetAllEvents();
    //Task<IEnumerable<EventDto>> GetEventsByNameAsync(string name);
    Task<EventDto> UpdateEventAsync(EventDto eventDto);
    Task DeleteEventAsync(Guid id);
}
