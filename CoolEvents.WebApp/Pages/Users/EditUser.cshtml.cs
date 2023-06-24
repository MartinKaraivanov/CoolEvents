using CoolEvents.Service.Models;
using CoolEvents.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CoolEvents.WebApp.Pages.Users;

[Authorize(Roles = "Admin")]
public class EditUserModel : PageModel
{
	private readonly IUsersService _usersService;

	[BindProperty]
	public required UserEditDto UserEditModel { get; set; }

	public EditUserModel(IUsersService usersService)
	{
		_usersService = usersService;
	}

	public void OnGet(string id)
	{
		UserEditModel = _usersService.GetUserEditById(id);
		UserEditModel.Password = "******";
	}

	public async Task<IActionResult> OnPostAsync()
	{
		if (ModelState.IsValid)
		{
			ArgumentNullException.ThrowIfNull(UserEditModel);

			await _usersService.UpdateUserEditAsync(UserEditModel);

			return RedirectToPage("./UsersIndex");
		}

		return Page();
	}
}
