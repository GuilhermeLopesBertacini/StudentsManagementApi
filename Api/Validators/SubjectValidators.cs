using FluentValidation;
using StudentsManagement.Api.DTOs.Subject;

namespace StudentsManagement.Api.Validators
{
  public class SubjectCreateRequestValidator : AbstractValidator<SubjectCreateRequest>
  {
    public SubjectCreateRequestValidator()
    {
      RuleFor(x => x.Name)
        .NotEmpty().WithMessage("Subject name is required.")
        .MaximumLength(50).WithMessage("Subject name must not exceed 50 characters.");
    }
  }
}
