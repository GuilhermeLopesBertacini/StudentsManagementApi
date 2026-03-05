using FluentValidation;
using StudentsManagement.Api.DTOs.Student;

namespace StudentsManagement.Api.Validators
{
  public class StudentCreateRequestValidator : AbstractValidator<StudentCreateRequest>
  {
    public StudentCreateRequestValidator()
    {
      RuleFor(x => x.FirstName)
        .NotEmpty().WithMessage("First name is required.")
        .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

      RuleFor(x => x.LastName)
        .NotEmpty().WithMessage("Last name is required.");

      RuleFor(x => x.Email)
        .NotEmpty().WithMessage("Email is required.")
        .EmailAddress().WithMessage("A valid email is required.")
        .Must(e => e.EndsWith("@faculdade.edu")).WithMessage("Email must end with @faculdade.edu.");

      RuleFor(x => x.CourseId)
        .NotEmpty().WithMessage("CourseId is required.");
    }
  }

  public class StudentUpdateNameRequestValidator : AbstractValidator<StudentUpdateNameRequest>
  {
    public StudentUpdateNameRequestValidator()
    {
      RuleFor(x => x.FirstName)
        .NotEmpty().WithMessage("First name is required.")
        .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

      RuleFor(x => x.LastName)
        .NotEmpty().WithMessage("Last name is required.");
    }
  }

  public class StudentUpdateEmailRequestValidator : AbstractValidator<StudentUpdateEmailRequest>
  {
    public StudentUpdateEmailRequestValidator()
    {
      RuleFor(x => x.Email)
        .NotEmpty().WithMessage("Email is required.")
        .EmailAddress().WithMessage("A valid email is required.")
        .Must(e => e.EndsWith("@faculdade.edu")).WithMessage("Email must end with @faculdade.edu.");
    }
  }

  public class StudentTransferRequestValidator : AbstractValidator<StudentTransferRequest>
  {
    public StudentTransferRequestValidator()
    {
      RuleFor(x => x.CourseId)
        .NotEmpty().WithMessage("CourseId is required.");
    }
  }
}
