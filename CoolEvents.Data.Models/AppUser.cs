using Microsoft.AspNetCore.Identity;

namespace CoolEvents.Data.Models;

public class AppUser : IdentityUser
{

    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

}