using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoolEvents.WebApp.Pages.Tickets;

[Authorize]
public class TicketDeletedModel : PageModel
{
    public void OnGet()
    {
    }
}
