using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoolEvents.WebApp.Pages.Users;

[Authorize(Roles = "Admin")]
public class UsersIndexModel : PageModel
{
    public void OnGet()
    {
    }
}
