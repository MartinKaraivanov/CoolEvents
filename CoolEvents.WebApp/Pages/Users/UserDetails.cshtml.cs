using CoolEvents.Service.Models;
using CoolEvents.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace CoolEvents.WebApp.Pages.Users;

[Authorize(Roles = "Admin")]
public class UserDetailsModel : PageModel
{
    private readonly IUsersService _usersService;

    public required UserEditDto UserEditModel { get; set; }

    public UserDetailsModel(IUsersService usersService)
    {
        _usersService = usersService;
    }

    public void OnGet(string id)
    {
        UserEditModel = _usersService.GetUserEditById(id);
    }
}
