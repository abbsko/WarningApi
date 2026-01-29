using Microsoft.EntityFrameworkCore;

namespace WarningApi.Business;

public class WarningDbContext : DbContext
{
    public DbSet<WeatherInfo> WeatherInfos => Set<WeatherInfo>();
    public DbSet<Warning> Warnings => Set<Warning>();
}
