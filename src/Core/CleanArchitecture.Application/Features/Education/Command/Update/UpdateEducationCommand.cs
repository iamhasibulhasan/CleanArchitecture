using CleanArchitecture.Application.Abstraction.MediatR;
using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.Features.Education.Command.Dtos;
using CleanArchitecture.Application.ServiceInterfaces.Users;

namespace CleanArchitecture.Application.Features.Education.Command.Update;

public sealed record UpdateEducationCommand(UpdateEducationDto model) : ICommand;
public sealed class UpdateEducationCommandHandler : ICommandHandler<UpdateEducationCommand>
{
    private readonly IEducationService _educationService;

    public UpdateEducationCommandHandler(IEducationService educationService)
    {
        _educationService = educationService;
    }

    public async Task<Result> Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
    {
        return await _educationService.Update(request.model, cancellationToken);
    }
}
