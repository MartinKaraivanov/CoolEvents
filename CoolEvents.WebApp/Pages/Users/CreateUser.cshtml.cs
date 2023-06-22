using CoolEvents.Service.Models;
using CoolEvents.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CoolEvents.WebApp.Pages.Users;

[Authorize(Roles = "Admin")]
public class CreateUserModel : PageModel
{
    private readonly IUsersService _usersService;

    [BindProperty]
    public required UserEditDto UserEditModel { get; set; }

    public CreateUserModel(IUsersService usersService)
    {
        _usersService = usersService;
    }

    public void OnGet()
    {
        UserEditModel = 
            new UserEditDto 
            { 
                Id = Guid.NewGuid().ToString(), 
                Email = string.Empty, 
                FirstName = string.Empty,  
                LastName = string.Empty,
                UserName = string.Empty,
                Password = string.Empty
            };
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            ArgumentNullException.ThrowIfNull(UserEditModel);

            await _usersService.CreateUserEditAsync(UserEditModel);

            return RedirectToPage("./UsersIndex");
        }

        return Page();
    }
}
