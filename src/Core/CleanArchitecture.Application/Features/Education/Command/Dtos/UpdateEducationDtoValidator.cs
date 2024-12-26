using FluentValidation;

namespace CleanArchitecture.Application.Features.Education.Command.Dtos
{
    public sealed class UpdateEducationDtoValidator : AbstractValidator<UpdateEducationDto>
    {
        public UpdateEducationDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Degree).NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
