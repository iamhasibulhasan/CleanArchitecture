using CleanArchitecture.Application.Abstraction.MediatR;
using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.ServiceInterfaces.Users;

namespace CleanArchitecture.Application.Features.Education.Command.Delete;

public sealed record DeleteEducationCommand(int id) : ICommand;
public sealed class DeleteEducationCommandHandler : ICommandHandler<DeleteEducationCommand>
{
    private readonly IEducationService _educationService;

    public DeleteEducationCommandHandler(IEducationService educationService)
    {
        _educationService = educationService;
    }

    public async Task<Result> Handle(DeleteEducationCommand request, CancellationToken cancellationToken)
    {
        return await _educationService.Delete(request.id, cancellationToken);
    }
}
