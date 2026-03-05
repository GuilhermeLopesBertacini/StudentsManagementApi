using FluentValidation;
using StudentsManagement.Api.DTOs.Course;

namespace StudentsManagement.Api.Validators
{
  public class CourseCreateRequestValidator : AbstractValidator<CourseCreateRequest>
  {
    public CourseCreateRequestValidator()
    {
      RuleFor(x => x.Name)
        .NotEmpty().WithMessage("Course name is required.")
        .MaximumLength(50).WithMessage("Course name must not exceed 50 characters.");
    }
  }
}
