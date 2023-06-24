namespace CoolEvents.Data.Seed;

public interface IDatabaseSeeder
{
    void SeedRoles(params string[] roleNames);
}
