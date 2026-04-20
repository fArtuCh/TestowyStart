using Microsoft.EntityFrameworkCore;
using MyTestApp.ApiService.Models;

namespace MyTestApp.ApiService.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Wpis> Wpisy => Set<Wpis>();
}
