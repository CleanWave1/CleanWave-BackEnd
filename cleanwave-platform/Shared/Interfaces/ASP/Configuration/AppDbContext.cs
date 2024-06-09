using Microsoft.EntityFrameworkCore;

namespace cleanwave_platform.Shared.Interfaces.ASP.Configuration;

public class AppDbContext(DbContextOptions) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        //Enable Audit Fields Interceptors
    }
}