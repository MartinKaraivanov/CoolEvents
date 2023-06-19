using CoolEvents.Service.Models;

namespace CoolEvents.Service;

public interface IUsersService
{
	IEnumerable<UserDto> GetAllUsers();
	UserDto GetUserById(Guid id);
}
