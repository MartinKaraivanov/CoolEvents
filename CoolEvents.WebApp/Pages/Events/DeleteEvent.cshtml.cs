using CoolEvents.Service.Models;
using CoolEvents.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoolEvents.WebApp.Pages.Events;

public class DeleteEventModel : PageModel
{
    private readonly IEventsService _eventsService;

    [BindProperty]
    public required EventDto Event { get; set; }

    public DeleteEventModel(IEventsService eventsService)
    {
        _eventsService = eventsService;
    }

    public void OnGet(Guid id)
    {
        Event = _eventsService.GetEventById(id);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            ArgumentNullException.ThrowIfNull(Event);

            await _eventsService.DeleteEventAsync(Event.Id);

            return RedirectToPage("./EventsIndex");
        }

        return Page();
    }
}
