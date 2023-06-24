using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoolEvents.Data.Seed;

public class DatabaseSeeder : IDatabaseSeeder
{
    private readonly CoolEventsDbContext _dbContext;

    public DatabaseSeeder(CoolEventsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SeedRoles(params string[] roleNames)
    {
        _dbContext.Database.Migrate();

        if (!_dbContext.Roles.Any())
        {
            foreach (var roleName in roleNames)
            {
                var currentRole = new IdentityRole { Name = roleName, NormalizedName = roleName.ToUpper()};

                _dbContext.Add(currentRole);
            }

            _dbContext.SaveChanges();
        }
    }
}
