using FluentValidation;

namespace CleanArchitecture.Application.Features.Users.Command.Dtos;

public sealed class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("{PropertyName} is required!");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("{PropertyName} is required!");
        RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("{PropertyName} is required!");
        RuleFor(x => x.Phone).NotEmpty().WithMessage("{PropertyName} is required!");
        RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} is required!");
    }
}
