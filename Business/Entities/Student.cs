using System.Text.RegularExpressions;
using StudentsManagement.Business.Exceptions;

namespace StudentsManagement.Business.Entities
{
  public class Student
  {
    private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public Guid CourseId { get; private set; }
    public Course Course { get; private set; }

    // For EF
    private Student() { }

    public Student(string firstName, string lastName, string email, Guid courseId)
    {
      SetFirstName(firstName);
      SetLastName(lastName);
      SetEmail(email);

      if (courseId == Guid.Empty)
        throw new DomainException("CourseId cannot be empty.");

      this.Id = Guid.NewGuid();
      this.CourseId = courseId;
    }

    public void TransferToCourse(Guid newCourseId)
    {
      if (newCourseId == Guid.Empty)
        throw new DomainException("New CourseId cannot be empty.");

      if (newCourseId == this.CourseId)
        throw new DomainException("Student is already enrolled in this course.");

      this.CourseId = newCourseId;
    }

    public void UpdateName(string firstName, string lastName)
    {
      SetFirstName(firstName);
      SetLastName(lastName);
    }

    public void UpdateEmail(string email)
    {
      SetEmail(email);
    }

    private void SetFirstName(string firstName)
    {
      if (string.IsNullOrWhiteSpace(firstName))
        throw new DomainException("First name cannot be empty.");

      this.FirstName = firstName.Trim();
    }

    private void SetLastName(string lastName)
    {
      if (string.IsNullOrWhiteSpace(lastName))
        throw new DomainException("Last name cannot be empty.");

      this.LastName = lastName.Trim();
    }

    private void SetEmail(string email)
    {
      if (string.IsNullOrWhiteSpace(email))
        throw new DomainException("Email cannot be empty.");

      if (!EmailRegex.IsMatch(email))
        throw new DomainException($"'{email}' is not a valid email address.");

      this.Email = email.Trim().ToLowerInvariant();
    }
  }
}