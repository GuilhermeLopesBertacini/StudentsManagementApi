using StudentsManagement.Business.Entities;

namespace StudentsManagement.Business.Interfaces
{
  public interface IStudentService : IBaseService<Student>
  {
    Student Enroll(Student student);
    Student UpdateName(Guid id, string firstName, string lastName);
    Student UpdateEmail(Guid id, string email);
    Student TransferToCourse(Guid id, Guid newCourseId);
  }
}
