namespace CoolEvents.Service.Models;

public class TicketDto
{
	public required Guid Id { get; set; }
	public required EventDto Event { get; set; }
	public required UserDto User { get; set; }
}
