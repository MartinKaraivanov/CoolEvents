using CoolEvents.Service.Models;
using CoolEvents.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace CoolEvents.WebApp.Pages.Events;

[Authorize]
public class EventDetailsModel : PageModel
{
    private readonly IEventsService _eventsService;

    [BindProperty]
    public required EventDto Event { get; set; }

    public EventDetailsModel(IEventsService eventsService)
    {
        _eventsService = eventsService;
    }

    public void OnGet(Guid id)
    {
        Event = _eventsService.GetEventById(id);
    }
}
