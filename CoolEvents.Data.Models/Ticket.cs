namespace CoolEvents.Data.Models;

public class Ticket : IEntity
{
    public required Guid Id { get; set; }
    public required Event Event { get; set; }
    public required AppUser User { get; set; }
}
