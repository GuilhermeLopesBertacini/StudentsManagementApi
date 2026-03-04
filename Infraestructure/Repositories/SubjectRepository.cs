using StudentsManagement.Business.Entities;
using StudentsManagement.Business.Interfaces;

namespace StudentsManagement.Infraestructure.Repositories
{
  public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
  {
    public SubjectRepository(AppDbContext context) : base(context) { }
  }
}
