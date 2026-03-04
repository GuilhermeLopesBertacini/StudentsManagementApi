namespace StudentsManagement.Business.Entities
{
    public class CourseSubject
    {
        public Guid CourseId { get; set; }
        public Guid SubjectId { get; set; }
        public Course Course { get; }
        public Subject Subject { get; }
    }
}
