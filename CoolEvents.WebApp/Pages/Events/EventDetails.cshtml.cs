using CoolEvents.Service.Models;
using CoolEvents.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CoolEvents.WebApp.Pages.Events;

[Authorize]
public class EventDetailsModel : PageModel
{
    private readonly IEventsService _eventsService;
    private readonly ITicketsService _ticketsService;
    private readonly IUsersService _usersService;

    public required EventDto Event { get; set; }

    public EventDetailsModel(IEventsService eventsService, ITicketsService ticketsService, IUsersService usersService)
    {
        _eventsService = eventsService;
        _ticketsService = ticketsService;
        _usersService = usersService;
    }

    public void OnGet(Guid id)
    {
        Event = _eventsService.GetEventById(id);
    }

	public async Task<IActionResult> OnPostAsync(Guid id)
	{
        Event = _eventsService.GetEventById(id);

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ArgumentNullException.ThrowIfNull(userId);
        var userDto = _usersService.GetUserById(Guid.Parse(userId));
        var ticket = new TicketDto { Id = Guid.NewGuid(), Event = Event, User = userDto};

		await _ticketsService.CreateTicketAsync(ticket);

		return RedirectToPage("../Tickets/TicketBooked");
	}
}
