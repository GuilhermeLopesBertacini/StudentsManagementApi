namespace StudentsManagement.Business.Entities
{
    public class Course
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<CourseSubject> CourseSubjects { get; } = new List<CourseSubject>();
        public ICollection<Student> Students { get; } = new List<Student>();
    }
}