using StudentsManagement.Business.Exceptions;

namespace StudentsManagement.Business.Entities
{
    public class Subject
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<CourseSubject> CourseSubjects { get; } = new List<CourseSubject>();

        // For EF
        private Subject() { }

        public Subject(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Subject name cannot be empty.");

            this.Id = Guid.NewGuid();
            this.Name = name.Trim();
        }

        public void Rename(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Subject name cannot be empty.");

            this.Name = name.Trim();
        }
    }
}