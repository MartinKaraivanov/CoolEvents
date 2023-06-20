using CoolEvents.Service.Models;
using CoolEvents.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoolEvents.WebApp.Pages;

[Authorize]
public class IndexModel : PageModel
{
    private readonly IEventsService _eventsService;
    private readonly IUsersService _usersService;
    private readonly ITicketsService _ticketsService;
    private readonly ILogger<IndexModel> _logger;

    public int EventCount { get; set; }
    public int UserCount { get; set; }
    public int TicketCount { get; set; }

    public IndexModel(IEventsService eventsService, IUsersService usersService, ITicketsService ticketsService, ILogger<IndexModel> logger)
    {
        _eventsService = eventsService;
        _usersService = usersService;   
        _ticketsService = ticketsService;
        _logger = logger;
    }

    public void OnGet()
    {
        EventCount = _eventsService.GetNumberOfEvents();
        UserCount = _usersService.GetNumberOfUsers();
        TicketCount = _ticketsService.GetNumberOfTickets();
    }

}