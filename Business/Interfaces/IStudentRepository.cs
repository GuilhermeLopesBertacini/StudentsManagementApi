using StudentsManagement.Business.Entities;

namespace StudentsManagement.Business.Interfaces
{
  public interface IStudentRepository : IBaseRepository<Student>
  {
    Student? FindByEmail(string email);
  }
}
