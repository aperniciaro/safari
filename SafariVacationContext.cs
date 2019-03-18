using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace safari
{
  public partial class SafariVacationContext : DbContext
  {
    public SafariVacationContext()
    {
    }

    public SafariVacationContext(DbContextOptions<SafariVacationContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseNpgsql("server=localhost;database=SafariVacation");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { }

    public DbSet<Animal> SeenAnimals { get; set; }
  }
}
