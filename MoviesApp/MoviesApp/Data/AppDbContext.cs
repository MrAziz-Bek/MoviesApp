using Microsoft.EntityFrameworkCore;
using MoviesApp.Data.Models;

namespace MoviesApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
    
    public DbSet<Movie> Movies { get; set; }
}