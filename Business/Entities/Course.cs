using StudentsManagement.Business.Exceptions;

namespace StudentsManagement.Business.Entities
{
    public class Course
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<CourseSubject> CourseSubjects { get; } = new List<CourseSubject>();
        public ICollection<Student> Students { get; } = new List<Student>();

        // For EF
        private Course() { }

        public Course(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Course name cannot be empty.");

            this.Id = Guid.NewGuid();
            this.Name = name.Trim();
        }

        public void Rename(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Course name cannot be empty.");

            this.Name = name.Trim();
        }

        public void EnrollStudent(Student student)
        {
            if (student is null)
                throw new DomainException("Student cannot be null.");

            if (this.Students.Any(s => s.Id == student.Id))
                throw new DomainException($"Student '{student.FirstName} {student.LastName}' is already enrolled in this course.");

            this.Students.Add(student);
        }

        public void AddSubject(Subject subject)
        {
            if (subject is null)
                throw new DomainException("Subject cannot be null.");

            if (this.CourseSubjects.Any(cs => cs.SubjectId == subject.Id))
                throw new DomainException($"Subject '{subject.Name}' is already assigned to this course.");

            var courseSubject = new CourseSubject(this.Id, subject.Id);
            this.CourseSubjects.Add(courseSubject);
        }

        public void RemoveSubject(Subject subject)
        {
            if (subject is null)
                throw new DomainException("Subject cannot be null.");

            var courseSubject = this.CourseSubjects.FirstOrDefault(cs => cs.SubjectId == subject.Id)
                ?? throw new DomainException($"Subject '{subject.Name}' is not assigned to this course.");

            this.CourseSubjects.Remove(courseSubject);
        }
    }
}