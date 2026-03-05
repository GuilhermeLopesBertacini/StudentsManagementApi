using StudentsManagement.Api.DTOs.Student;
using StudentsManagement.Business.Entities;

namespace StudentsManagement.Api.Mappers
{
  public static class StudentMapper
  {
    public static Student ToEntity(StudentCreateRequest dto)
    {
      return new Student(dto.FirstName, dto.LastName, dto.Email, dto.CourseId);
    }

    public static StudentResponse ToResponse(Student entity)
    {
      return new StudentResponse
      {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        Email = entity.Email,
        CourseId = entity.CourseId
      };
    }

    public static List<StudentResponse> ToResponseList(List<Student> entities)
    {
      return entities.Select(ToResponse).ToList();
    }
  }
}
