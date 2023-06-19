namespace CoolEvents.Data.Models;

public class Ticket : IEntity
{
    public required Guid Id { get; set; }
    public required Guid EventId { get; set; }
    public Event Event { get; set; } = null!;
    public required string UserId { get; set; } // todo: Guid
    public AppUser User { get; set; } = null!;
}
