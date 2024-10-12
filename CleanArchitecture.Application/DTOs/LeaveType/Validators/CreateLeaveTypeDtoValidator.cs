using FluentValidation;

namespace CleanArchitecture.Application.DTOs.LeaveType.Validators
{
    public sealed class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(x => x.DefaultDays)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .GreaterThan(0)
                .LessThan(100);
        }
    }
}
