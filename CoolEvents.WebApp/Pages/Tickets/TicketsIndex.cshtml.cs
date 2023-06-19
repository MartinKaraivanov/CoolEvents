using CoolEvents.Service.Models;
using CoolEvents.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoolEvents.WebApp.Pages.Tickets;

[Authorize(Roles = "Admin")]
public class TicketsIndexModel : PageModel
{
    private readonly ITicketsService _ticketsService;

    public IEnumerable<TicketDto> Tickets { get; set; } = new List<TicketDto>();

    public TicketsIndexModel(ITicketsService ticketsService)
    {
        _ticketsService = ticketsService;
    }

    public void OnGet()
    {
        Tickets = _ticketsService.GetAllTickets();
    }
}
