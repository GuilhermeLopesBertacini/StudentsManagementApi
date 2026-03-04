using StudentsManagement.Business.Entities;
using StudentsManagement.Business.Interfaces;

namespace StudentsManagement.Infraestructure.Repositories
{
  public class StudentRepository : BaseRepository<Student>, IStudentRepository
  {
    public StudentRepository(AppDbContext context) : base(context) { }

    public Student? FindByEmail(string email)
    {
      return _dbSet.FirstOrDefault(s => s.Email == email.Trim().ToLowerInvariant());
    }
  }
}
