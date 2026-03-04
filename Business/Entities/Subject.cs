namespace StudentsManagement.Business.Entities
{
    public class Subject
  {
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public ICollection<CourseSubject> CourseSubjects { get; } = new List<CourseSubject>();
  }
}