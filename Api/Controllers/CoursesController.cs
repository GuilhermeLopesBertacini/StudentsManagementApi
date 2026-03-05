using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Api.DTOs.Course;
using StudentsManagement.Api.Mappers;
using StudentsManagement.Business.Interfaces;

namespace StudentsManagement.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CoursesController : ControllerBase
  {
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
      _courseService = courseService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      var courses = _courseService.GetAll();
      return Ok(CourseMapper.ToResponseList(courses));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
      var course = _courseService.GetById(id);
      return Ok(CourseMapper.ToResponse(course));
    }

    [HttpPost]
    public IActionResult Create([FromBody] CourseCreateRequest request)
    {
      var entity = CourseMapper.ToEntity(request);
      var created = _courseService.Create(entity);
      return CreatedAtAction(nameof(GetById), new { id = created.Id }, CourseMapper.ToResponse(created));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
      _courseService.Delete(id);
      return NoContent();
    }
  }
}
