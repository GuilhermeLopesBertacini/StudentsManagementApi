using StudentsManagement.Business.Entities;
using StudentsManagement.Business.Interfaces;

namespace StudentsManagement.Business.Services
{
  public class SubjectService : BaseService<Subject>, ISubjectService
  {
    public SubjectService(ISubjectRepository subjectRepository) : base(subjectRepository) { }
  }
}
