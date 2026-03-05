using StudentsManagement.Api.DTOs.Course;
using StudentsManagement.Business.Entities;

namespace StudentsManagement.Api.Mappers
{
  public static class CourseMapper
  {
    public static Course ToEntity(CourseCreateRequest dto)
    {
      return new Course(dto.Name);
    }

    public static CourseResponse ToResponse(Course entity)
    {
      return new CourseResponse
      {
        Id = entity.Id,
        Name = entity.Name
      };
    }

    public static List<CourseResponse> ToResponseList(List<Course> entities)
    {
      return entities.Select(ToResponse).ToList();
    }
  }
}
