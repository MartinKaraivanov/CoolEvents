using CoolEvents.Service.Models;
using CoolEvents.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace CoolEvents.WebApp.Pages.Tickets;

[Authorize]
public class YourTicketsIndexModel : PageModel
{
    private readonly ITicketsService _ticketsService;

    public IEnumerable<TicketDto> Tickets { get; set; } = new List<TicketDto>();

    public YourTicketsIndexModel(ITicketsService ticketsService)
    {
        _ticketsService = ticketsService;
    }

    public void OnGet()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ArgumentNullException.ThrowIfNull(userId);
        Tickets = _ticketsService.GetTicketsByUserId(Guid.Parse(userId));
    }
}
