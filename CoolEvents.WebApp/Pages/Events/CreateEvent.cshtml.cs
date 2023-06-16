using CoolEvents.Service;
using CoolEvents.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoolEvents.WebApp.Pages.Events;

[Authorize]
public class CreateEventModel : PageModel
{
    private readonly IEventsService _eventsService;

    [BindProperty]
    public required EventDto Event { get; set; }

    public CreateEventModel(IEventsService eventsService)
    {
        _eventsService = eventsService;
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            ArgumentNullException.ThrowIfNull(Event);

            await _eventsService.CreateEventAsync(Event);

            return RedirectToPage("./EventsIndex");
        }

        return Page();
    }
}
