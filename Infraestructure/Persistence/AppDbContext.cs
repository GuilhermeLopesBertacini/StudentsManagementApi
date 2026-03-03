using Microsoft.EntityFrameworkCore;

namespace StudentsManagement.Infraestructure.Persistence
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    // public DbSet<Student> Students { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
      
    // }

  }
}