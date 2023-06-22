using CoolEvents.Data.Models;
using CoolEvents.Data;
using CoolEvents.Service.Models;
using CoolEvents.Service.Mappings;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace CoolEvents.Service;

public class UsersService : IUsersService
{
	private readonly IRepository<AppUser> _userRepository;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    
    public UsersService(IRepository<AppUser> userRepository, UserManager<AppUser> userManager, IMapper mapper)
	{
		_userRepository = userRepository;
        _userManager = userManager;
        _mapper = mapper;
    }

	public IEnumerable<UserDto> GetAllUsers()
	{
		return _userRepository.RetrieveMappedTo<UserDto>(x => true);
	}

	public int GetNumberOfUsers()
	{
		return _userRepository.Count();
	}

	public UserDto GetUserById(Guid id)
	{
		var user = _userRepository.RetrieveMappedTo<UserDto>(x => x.Id == id.ToString()).SingleOrDefault();

		ArgumentNullException.ThrowIfNull(user);

		return user;
	}

    public async Task CreateUserEditAsync(UserEditDto userEditDto)
    {
        AppUser appUser = new AppUser
        {
            Id = userEditDto.Id.ToString(),
            Email = userEditDto.Email,
            UserName = userEditDto.Email,
            FirstName = userEditDto.FirstName,
            LastName = userEditDto.LastName,
        };

        await _userManager.CreateAsync(appUser);
    }

    public IEnumerable<UserEditDto> GetAllUserEdits()
    {
        return _userRepository.RetrieveMappedTo<UserEditDto>(x => true);
    }

    public UserEditDto GetUserEditById(string id)
    {
        var user = _userRepository.RetrieveMappedTo<UserEditDto>(x => x.Id == id).SingleOrDefault();

        ArgumentNullException.ThrowIfNull(user);

        return user;
    }

    public async Task UpdateUserEditAsync(UserEditDto userEditDto)
    {
        var user = _userRepository.Retrieve(x => x.Id == userEditDto.Id.ToString()).SingleOrDefault();

        if (user == null)
        {
            throw new ArgumentException("Does not exist");
        }

        user.Email = userEditDto.Email;
        user.UserName = userEditDto.UserName;
        user.FirstName = userEditDto.FirstName;
        user.LastName = userEditDto.LastName;

        await _userManager.UpdateAsync(user);
    }
    public async Task DeleteUserEditAsync(string id)
    {
        var user = _userRepository.Retrieve(x => x.Id == id).SingleOrDefault();

        if (user == null)
        {
            throw new ArgumentException("Does not exist");
        }

        await _userRepository.RemoveAsync(user);
    }
}
