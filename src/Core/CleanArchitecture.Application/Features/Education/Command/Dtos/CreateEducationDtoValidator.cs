using FluentValidation;

namespace CleanArchitecture.Application.Features.Education.Command.Dtos;

public sealed class CreateEducationDtoValidator : AbstractValidator<CreateEducationDto>
{
    public CreateEducationDtoValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("{PropertyName} is required!");
        RuleFor(x => x.Degree).NotEmpty().WithMessage("{PropertyName} is required!");
    }
}
