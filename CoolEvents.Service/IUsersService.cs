using CoolEvents.Service.Models;

namespace CoolEvents.Service;

public interface IUsersService
{
	IEnumerable<UserDto> GetAllUsers();
	int GetNumberOfUsers();
	UserDto GetUserById(Guid id);
    Task CreateUserEditAsync(UserEditDto userEditDto);
    IEnumerable<UserEditDto> GetAllUserEdits();
    UserEditDto GetUserEditById(string id);
    Task UpdateUserEditAsync(UserEditDto userEditDto);
    Task DeleteUserEditAsync(string id);
}
