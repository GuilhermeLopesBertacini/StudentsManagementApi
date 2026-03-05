using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Api.DTOs.Subject;
using StudentsManagement.Api.Mappers;
using StudentsManagement.Business.Interfaces;

namespace StudentsManagement.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SubjectsController : ControllerBase
  {
    private readonly ISubjectService _subjectService;

    public SubjectsController(ISubjectService subjectService)
    {
      _subjectService = subjectService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      var subjects = _subjectService.GetAll();
      return Ok(SubjectMapper.ToResponseList(subjects));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
      var subject = _subjectService.GetById(id);
      return Ok(SubjectMapper.ToResponse(subject));
    }

    [HttpPost]
    public IActionResult Create([FromBody] SubjectCreateRequest request)
    {
      var entity = SubjectMapper.ToEntity(request);
      var created = _subjectService.Create(entity);
      return CreatedAtAction(nameof(GetById), new { id = created.Id }, SubjectMapper.ToResponse(created));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
      _subjectService.Delete(id);
      return NoContent();
    }
  }
}
