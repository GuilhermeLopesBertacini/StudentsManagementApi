namespace StudentsManagement.Api.DTOs.Student
{
  public class StudentResponse
  {
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid CourseId { get; set; }
  }
}
