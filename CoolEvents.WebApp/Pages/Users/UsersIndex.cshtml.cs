using CoolEvents.Service;
using CoolEvents.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoolEvents.WebApp.Pages.Users;

[Authorize(Roles = "Admin")]
public class UsersIndexModel : PageModel
{

    private readonly IUsersService _usersService;

    public IEnumerable<UserEditDto> Users { get; set; } = new List<UserEditDto>();

    public UsersIndexModel(IUsersService usersService)
    {
        _usersService = usersService;
    }

    public void OnGet()
    {
        Users = _usersService.GetAllUserEdits();
    }
}
