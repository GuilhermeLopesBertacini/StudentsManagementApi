using StudentsManagement.Business.Entities;
using StudentsManagement.Business.Interfaces;

namespace StudentsManagement.Infraestructure.Repositories
{
  public class CourseRepository : BaseRepository<Course>, ICourseRepository
  {
    public CourseRepository(AppDbContext context) : base(context) { }
  }
}
