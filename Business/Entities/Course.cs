namespace StudentsManagement.Business.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Subject> CourseSubjects { get; set; } = new List<Subject>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}