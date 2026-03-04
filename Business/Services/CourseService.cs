using StudentsManagement.Business.Entities;
using StudentsManagement.Business.Interfaces;

namespace StudentsManagement.Business.Services
{
  public class CourseService : BaseService<Course>, ICourseService
  {
    public CourseService(ICourseRepository courseRepository) : base(courseRepository) { }
  }
}
