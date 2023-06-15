namespace CoolEvents.Data.Models;

public class Event : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string PhotoUrl { get; set; }
    public required DateTime Date { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

}
