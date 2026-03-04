using StudentsManagement.Business.Exceptions;

namespace StudentsManagement.Business.Entities
{
    public class CourseSubject
    {
        public Guid CourseId { get; private set; }
        public Guid SubjectId { get; private set; }
        public Course Course { get; private set; }
        public Subject Subject { get; private set; }

        // For EF
        private CourseSubject() { }

        public CourseSubject(Guid courseId, Guid subjectId)
        {
            if (courseId == Guid.Empty)
                throw new DomainException("CourseId cannot be empty.");

            if (subjectId == Guid.Empty)
                throw new DomainException("SubjectId cannot be empty.");

            this.CourseId = courseId;
            this.SubjectId = subjectId;
        }
    }
}
