using CoolEvents.Service.Models;

namespace CoolEvents.Service;

public interface IUsersService
{
	IEnumerable<UserDto> GetAllUsers();
	int GetNumberOfUsers();
	UserDto GetUserById(Guid id);
}
