using StudentsManagement.Api.DTOs.Subject;
using StudentsManagement.Business.Entities;

namespace StudentsManagement.Api.Mappers
{
  public static class SubjectMapper
  {
    public static Subject ToEntity(SubjectCreateRequest dto)
    {
      return new Subject(dto.Name);
    }

    public static SubjectResponse ToResponse(Subject entity)
    {
      return new SubjectResponse
      {
        Id = entity.Id,
        Name = entity.Name
      };
    }

    public static List<SubjectResponse> ToResponseList(List<Subject> entities)
    {
      return entities.Select(ToResponse).ToList();
    }
  }
}
