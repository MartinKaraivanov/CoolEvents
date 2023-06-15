using CoolEvents.Service.Models;
using CoolEvents.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoolEvents.WebApp.Pages.Events;

public class EventsIndexModel : PageModel
{
    private readonly IEventsService _eventsService;

    public IEnumerable<EventDto> Events { get; set; } = new List<EventDto>();

    public EventsIndexModel(IEventsService eventsService)
    {
        _eventsService = eventsService;
    }

    public void OnGet()
    {
        Events = _eventsService.GetAllEvents();

    }

}
