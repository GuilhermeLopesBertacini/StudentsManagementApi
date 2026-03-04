using StudentsManagement.Business.Entities;
using StudentsManagement.Business.Exceptions;
using StudentsManagement.Business.Interfaces;

namespace StudentsManagement.Business.Services
{
  public class StudentService : BaseService<Student>, IStudentService
  {
    private readonly IStudentRepository _studentRepository;
    private readonly ICourseRepository _courseRepository;

    public StudentService(IStudentRepository studentRepository, ICourseRepository courseRepository)
      : base(studentRepository)
    {
      _studentRepository = studentRepository;
      _courseRepository = courseRepository;
    }

    public Student Enroll(Student student)
    {
      // Presença: FirstName não pode ser nulo ou vazio
      if (string.IsNullOrWhiteSpace(student.FirstName))
        throw new BadRequestException("First name is required.");

      // Extensão: FirstName deve ter no máximo 50 caracteres
      if (student.FirstName.Length > 50)
        throw new BadRequestException("First name must not exceed 50 characters.");

      // Domínio: e-mail deve terminar com @faculdade.edu
      if (!student.Email.EndsWith("@faculdade.edu"))
        throw new BadRequestException("Email must end with @faculdade.edu.");

      // Unicidade: e-mail não pode pertencer a outro aluno
      var existing = _studentRepository.FindByEmail(student.Email);
      if (existing != null)
        throw new BadRequestException($"Email '{student.Email}' is already in use.");

      // Verifica se o curso existe
      var course = _courseRepository.GetById(student.CourseId);
      if (course == null)
        throw new NotFoundException($"Course with Id {student.CourseId} not found.");

      return _studentRepository.Create(student);
    }

    public Student UpdateName(Guid id, string firstName, string lastName)
    {
      var student = GetById(id);
      student.UpdateName(firstName, lastName);
      _studentRepository.Update(student);
      return student;
    }

    public Student UpdateEmail(Guid id, string email)
    {
      var student = GetById(id);

      // Unicidade ao atualizar e-mail
      var existing = _studentRepository.FindByEmail(email);
      if (existing != null && existing.Id != student.Id)
        throw new BadRequestException($"Email '{email}' is already in use.");

      student.UpdateEmail(email);
      _studentRepository.Update(student);
      return student;
    }

    public Student TransferToCourse(Guid id, Guid newCourseId)
    {
      var student = GetById(id);

      var course = _courseRepository.GetById(newCourseId);
      if (course == null)
        throw new NotFoundException($"Course with Id {newCourseId} not found.");

      student.TransferToCourse(newCourseId);
      _studentRepository.Update(student);
      return student;
    }
  }
}
