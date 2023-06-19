using CoolEvents.Data.Models;
using CoolEvents.Data;
using CoolEvents.Service.Models;
using CoolEvents.Service.Mappings;

namespace CoolEvents.Service;

public class UsersService : IUsersService
{
	private readonly IRepository<AppUser> _userRepository;

	public UsersService(IRepository<AppUser> userRepository)
	{
		_userRepository = userRepository;
	}

	public IEnumerable<UserDto> GetAllUsers()
	{
		return _userRepository.RetrieveMappedTo<UserDto>(x => true);
	}

	public UserDto GetUserById(Guid id)
	{
		var user = _userRepository.RetrieveMappedTo<UserDto>(x => x.Id == id.ToString()).SingleOrDefault();

		ArgumentNullException.ThrowIfNull(user);

		return user;
	}
}
