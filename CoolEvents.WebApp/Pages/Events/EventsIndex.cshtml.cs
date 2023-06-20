using CoolEvents.Service.Models;
using CoolEvents.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CoolEvents.WebApp.Pages.Events;

[Authorize]
public class EventsIndexModel : PageModel
{
    private readonly IEventsService _eventsService;

    public IEnumerable<EventDto> Events { get; set; } = new List<EventDto>();

    [BindProperty]
    public string SearchName { get; set; } = string.Empty;

    public EventsIndexModel(IEventsService eventsService)
    {
        _eventsService = eventsService;
    }

    public void OnGet(string? namePart)
    {
        if (string.IsNullOrEmpty(namePart))
        {
            Events = _eventsService.GetAllEvents();
        }
        else
        {
            Events = _eventsService.GetEventsByNamePart(namePart);
        }
    }

    public IActionResult OnPost()
    {
        return RedirectToPage("", new { namePart = SearchName });
    }
}
