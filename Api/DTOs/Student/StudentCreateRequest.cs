namespace StudentsManagement.Api.DTOs.Student
{
  public class StudentCreateRequest
  {
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid CourseId { get; set; }
  }
}
