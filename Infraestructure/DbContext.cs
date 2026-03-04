using StudentsManagement.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace StudentsManagement.Infraestructure
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<CourseSubject> CourseSubjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Student>(e =>
      {
        e.ToTable("tb_students");
        
        e.Property(s => s.Email)
          .HasMaxLength(255)
          .IsRequired();
        
        e.HasIndex(s => s.Email)
          .IsUnique();
        
        e.HasOne(s => s.Course)
          .WithMany(c => c.Students)
          .HasForeignKey(s => s.CourseId);
      });

      modelBuilder.Entity<Course>(c =>
      {
        c.ToTable("tb_courses");

        c.Property(c => c.Name)
          .HasMaxLength(50);
      });

      modelBuilder.Entity<Subject>(s =>
      {
        s.ToTable("tb_subjects");

        s.Property(s => s.Name)
          .HasMaxLength(50);
      });

      modelBuilder.Entity<CourseSubject>(cs =>
      {
        cs.ToTable("tb_course_subject");

        cs.HasOne(cs => cs.Course)
          .WithMany(c => c.CourseSubjects)
          .HasForeignKey(cs => cs.CourseId);
        
        cs.HasOne(cs => cs.Subject)
          .WithMany(s => s.CourseSubjects)
          .HasForeignKey(cs => cs.SubjectId);
      });
    }

  }
}