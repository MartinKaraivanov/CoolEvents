using CoolEvents.Service.Models;
using CoolEvents.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace CoolEvents.WebApp.Pages.Tickets;

[Authorize]
public class DeleteTicketModel : PageModel
{
    private readonly ITicketsService _ticketsService;

    public required TicketDto Ticket { get; set; }

    public required string ReturnPage { get; set; }

    public DeleteTicketModel(ITicketsService ticketsService)
    {
        _ticketsService = ticketsService;
    }

    public void OnGet(Guid id, string returnPage)
    {
        Ticket = _ticketsService.GetTicketById(id);
        ReturnPage = returnPage;
    }

    public async Task<IActionResult> OnPostAsync(Guid id, string returnPage)
    {
        if (ModelState.IsValid)
        {
            await _ticketsService.DeleteTicketAsync(id);

            return RedirectToPage($"./{returnPage}");
        }

        return Page();
    }
}
