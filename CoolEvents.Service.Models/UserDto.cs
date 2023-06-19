namespace CoolEvents.Service.Models;

public class UserDto
{
	public required string Id { get; set; } // todo: Guid
	public required string FirstName { get; set; }
	public required string LastName { get; set; }
}
