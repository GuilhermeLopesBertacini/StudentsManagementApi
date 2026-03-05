using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Api.DTOs.Student;
using StudentsManagement.Api.Mappers;
using StudentsManagement.Business.Interfaces;

namespace StudentsManagement.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class StudentsController : ControllerBase
  {
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
      _studentService = studentService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      var students = _studentService.GetAll();
      return Ok(StudentMapper.ToResponseList(students));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
      var student = _studentService.GetById(id);
      return Ok(StudentMapper.ToResponse(student));
    }

    [HttpPost]
    public IActionResult Enroll([FromBody] StudentCreateRequest request)
    {
      var entity = StudentMapper.ToEntity(request);
      var created = _studentService.Enroll(entity);
      return CreatedAtAction(nameof(GetById), new { id = created.Id }, StudentMapper.ToResponse(created));
    }

    [HttpPatch("{id}/name")]
    public IActionResult UpdateName(Guid id, [FromBody] StudentUpdateNameRequest request)
    {
      var updated = _studentService.UpdateName(id, request.FirstName, request.LastName);
      return Ok(StudentMapper.ToResponse(updated));
    }

    [HttpPatch("{id}/email")]
    public IActionResult UpdateEmail(Guid id, [FromBody] StudentUpdateEmailRequest request)
    {
      var updated = _studentService.UpdateEmail(id, request.Email);
      return Ok(StudentMapper.ToResponse(updated));
    }

    [HttpPatch("{id}/transfer")]
    public IActionResult TransferToCourse(Guid id, [FromBody] StudentTransferRequest request)
    {
      var updated = _studentService.TransferToCourse(id, request.CourseId);
      return Ok(StudentMapper.ToResponse(updated));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
      _studentService.Delete(id);
      return NoContent();
    }
  }
}
