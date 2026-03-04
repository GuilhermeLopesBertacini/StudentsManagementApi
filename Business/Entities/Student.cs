namespace StudentsManagement.Business.Entities
{
  public class Student
  {
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public Guid CourseId { get; private set;}
    public Course Course { get; private set; }
  }
}