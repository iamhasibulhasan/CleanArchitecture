using CleanArchitecture.Application.Abstraction.MediatR;
using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.Features.Education.Command.Dtos;
using CleanArchitecture.Application.ServiceInterfaces.Users;

namespace CleanArchitecture.Application.Features.Education.Command.Create
{
    public sealed record CreateEducationCommand(CreateEducationDto model) : ICommand;
    public sealed class CreateEducationCommandHandler : ICommandHandler<CreateEducationCommand>
    {
        public readonly IEducationService _educationService;

        public CreateEducationCommandHandler(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public async Task<Result> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {
            return await _educationService.Create(request.model, cancellationToken);
        }
    }
}
